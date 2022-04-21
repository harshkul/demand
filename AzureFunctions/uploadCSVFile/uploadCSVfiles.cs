using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Blob;
using Azure.Storage.Blobs;

namespace PaymentServices
{
    public static class uploadCSVfiles
    {
        [FunctionName("uploadCSVfiles")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Blob("elcsvfiles", FileAccess.ReadWrite,Connection="AzureWebJobsStorage")] BlobContainerClient outputBlob,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation($"File Upload request recevied at {DateTime.Now.ToString()}");

            string fileName = String.Empty;

            for (int i = 0; i < req.Form.Files.Count; i++)
            {
                fileName = req.Query["fileName"];
                var file = req.Form.Files[i];
                var fileNameL = file.FileName;
                Stream stream = file.OpenReadStream();

                outputBlob.UploadBlobAsync(fileNameL, stream).Wait();

            }


            string responseMessage = string.IsNullOrEmpty(fileName) && req.Form.Files.Count == 0
                ? "This HTTP triggered function executed successfully. but there is no file to upload."
                : $"File, {fileName} is uploaded successfully.";


            log.LogInformation(responseMessage);
            return new OkObjectResult(responseMessage);
        }
    }
}
