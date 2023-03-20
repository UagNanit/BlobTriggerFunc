using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using FunctionBLOBtrigger.Repository;
using FunctionBLOBtrigger.Services;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FunctionBLOBtrigger.Data;

namespace FunctionBLOBtrigger
{
    public class FunctionBlobTriggerSendEmail
    {
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationContext _applicationContext;

        
        public FunctionBlobTriggerSendEmail(ILoggerFactory loggerFactory, IEmailSender emailSender, ApplicationContext applicationContext)
        {
            _logger = loggerFactory.CreateLogger<FunctionBlobTriggerSendEmail>();
            _emailSender = emailSender;
            _applicationContext = applicationContext;

        }
       


        [Function("FunctionBlobTriggerSendEmail")]
         public async Task Run([BlobTrigger("files-container/{name}.{extension}", Connection = "BlobConnectionString")] string myBlob, Uri uri, string name, string extension)
         {
             _logger.LogInformation($"C# Blob trigger function Processed blob \nName: {name} \nType: {extension} \nSize: {myBlob.Length} Bytes \n uri: {uri?.ToString()}");

            var obj = _applicationContext.DbModelDatas.FirstOrDefaultAsync(d => d.FileName == name + "." + extension).Result;
            if (obj != null) { 
                _logger.LogInformation("\nEmail: " + obj.Email);

                string sendTo = obj.Email;
                string subject = "Add file to the BLOB storage";
                string body = $"You are add file \nName: {name} \nType: {extension} \nSize: {myBlob.Length} Bytes \nUri: {uri?.ToString()}";

                await _emailSender.SendEmailAsync(sendTo, subject, body);
            }
            else
            {
                _logger.LogInformation("\nEmail: null" );

                string sendTo = "olegkrava7@gmail.com";
                string subject = "Add file to the BLOB storage";
                string body = $"You are add file \nName: {name} \nType: {extension} \nSize: {myBlob.Length} Bytes \nUri: {uri?.ToString()} \n Email: null";

                await _emailSender.SendEmailAsync(sendTo, subject, body);

            }
         }
    }
}


