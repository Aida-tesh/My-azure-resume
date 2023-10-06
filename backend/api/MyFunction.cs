using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;
using Microsoft.Azure.CosmosDB;
using Azure.Cosmos;


namespace Company.Function
{
    public static class MyFunction
    {
        [FunctionName("MyFunction")]
        public static  HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"My-azure-resume-db", collectionName:"MyCounter", ConnectionStringSetting = "AzureResumeConnectionsStrings", Id = "1", PartitionKey = "1")]  Counter MyCounter,
            [CosmosDB(databaseName:"My-azure-resume-db", collectionName: "MyCounter", ConnectionStringSetting = "AzureResumeConnectionsStrings", Id = "1", PartitionKey = "1")] out Counter outMyCounter, ILogger log)
         
         
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            outMyCounter = MyCounter;
            outMyCounter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(MyCounter);

             return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
    
}

