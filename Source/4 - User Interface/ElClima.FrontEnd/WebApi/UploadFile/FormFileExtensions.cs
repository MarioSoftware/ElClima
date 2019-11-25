using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SimonMips.FrontEnd.WebApi.UploadFile
{
    public static class FormFileExtensions
    {
        private const int DefaultBufferSize = 8 * 1024;

        /// <summary>
        /// Asynchronously saves the contents of an uploaded file.
        /// </summary>
        /// <param name="formFile">The <see cref="IFormFile"/>.</param>
        /// <param name="filename">The name of the file to create.</param>
        public static void SaveAs(
            this IFormFile formFile,
            string filename)
        {
            if (formFile == null)
            {
                throw new ArgumentNullException(nameof(formFile));
            }

            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                var inputStream = formFile.OpenReadStream();
                inputStream.CopyTo(fileStream);
            }
        }
    }
}
