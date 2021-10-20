using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;

namespace ServerlessFunc
{
    public static class BlobTest
    {
        [FunctionName("BlobTest")]
        public static async Task RunAsync([BlobTrigger("csvblobtest/{name}")] Stream myBlob, string name, ILogger log)
        {
            var data = ParseCsv(myBlob);
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }


        private static List<String[]> ParseCsv(Stream blob)
        {
            using TextFieldParser textFieldParser = new TextFieldParser(blob);
            textFieldParser.TextFieldType = FieldType.Delimited;
            textFieldParser.SetDelimiters(",");

            var rows = new List<String[]>();

            while (!textFieldParser.EndOfData)
            {
                rows.Add(textFieldParser.ReadFields());
            }

            return rows;
        }
    }
}