﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SimonMips.FrontEnd.WebApi.UploadFile
{ 
    public class FileDescriptionShort
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<IFormFile> File { get; set; }
    }
}
