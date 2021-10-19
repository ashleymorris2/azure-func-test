﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServerlessFunc
{
    public static class BlobTest
    {
        [FunctionName("BlobTest")]
        public static async Task RunAsync([BlobTrigger("samples-workitems/{name}", Connection = "")] Stream myBlob,
            string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}