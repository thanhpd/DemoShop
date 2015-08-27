using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingTech.Helper
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path)
            : base(path)
        { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return name.Replace("\"", string.Empty);
        }

        public override async Task ExecutePostProcessingAsync()
        {
            await base.ExecutePostProcessingAsync();

            // By this time the file would have been uploaded to the location you provided
            // and also the dictionaries like FormData and FileData would be populated with information
            // that you can use like below

            string targetFileName = FormData["cat-name"];

            // get the uploaded file's name
            string currentFileName = FileData[0].LocalFileName;

            //TODO: rename the file
            
        }
    }
}