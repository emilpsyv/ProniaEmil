﻿using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ProniaEmil.Extentions
{
    public static class FileExtention
    {
        public static bool IsValidType(this IFormFile file, string type)=>file.ContentType.Contains(type);
        public static bool IsValidLength(this IFormFile file, int kb) => file.Length <= kb * 1024;
        public static async Task< string >SaveFileAsync(this IFormFile file,string path )
        {
            string ext = Path.GetExtension(file.FileName);
            string newName = Path.GetRandomFileName();
            await using FileStream fs = new FileStream(Path.Combine(path, "imgs", "products", newName + ext), FileMode.Create);
            await file.CopyToAsync(fs);
            return  newName+ext;
        }
    }
}
    