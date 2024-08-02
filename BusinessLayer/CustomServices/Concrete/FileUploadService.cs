using BusinessLayer.CustomServices.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CustomServices.Concrete
{
    public class FileUploadService : IFileUploadService
    {
        public async Task DeleteFileAsync(string? filePath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            await Task.CompletedTask;
        }

        public async Task<string> UpdateFileAsync(IFormFile newFile, string? existingFilePath, string? folderPath)
        {
            // Eski dosyayı sil
            await DeleteFileAsync(existingFilePath);

            // Yeni dosyayı yükle
            return await UploadFileAsync(newFile, folderPath);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string? folderPath)
        {


            if (file != null && file.Length > 0)
            {
                // Dosya adı ve yol oluşturma
                //var fileName = Path.GetFileName(file.FileName);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var fileExtension = Path.GetExtension(file.FileName);
                fileName = String.Concat(fileName, "_", Guid.NewGuid(), fileExtension);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath, fileName);

                // Dosyayı diske kaydetme
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Resim yolunu DTO'ya ekleme
                return $"/{folderPath}/{fileName}";
            }
            else
            {
                return "dosya seçilmedi";
            }




        }
    }
}
