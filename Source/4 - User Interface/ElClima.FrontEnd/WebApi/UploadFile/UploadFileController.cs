﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SimonMips.FrontEnd.WebApi.UploadFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ElClima.FrontEnd.WebApi.UploadFile
{
    public class UploadFileController
    {
        private readonly IHostingEnvironment _env;

        public UploadFileController(IHostingEnvironment env)
        {
            _env = env;
        }

        [Route("/api/UploadFile/Add")]
        [HttpPost] 
        public void UploadFiles(FileDescriptionShort fileDescriptionShort)
        {
            var names = new List<string>();
            var contentTypes = new List<string>();

            foreach (var file in fileDescriptionShort.File)
            {
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition)
                        .FileName.ToString().Trim('"');

                    contentTypes.Add(file.ContentType);

                    names.Add(fileName);

                    var webRoot = _env.WebRootPath;

                    var extension = Path.GetExtension(Path.GetFileName(fileName));

                    var fileName2 = Path.Combine(webRoot + "\\UploadedFiles\\",
                        fileDescriptionShort.Name + extension);

                    file.SaveAs(fileName2);
                }
            }

        }
    }
}
