using System.Text;
using System.Text.RegularExpressions;

namespace OrganicShop.Helpper
{
    public static class Utilities
    {
        public static int PAGE_SIZE = 20;
        public static void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if(!folderExists)
                Directory.CreateDirectory(path);
        }
        public static string GetRandomKey(int length = 5)
        {
            //Chuoi mau (pattern)
            string pattern = @"0123456789zxcvbnmasdfghjklqwertyuiop[]{}:~!@#$%^&*()+";
            Random rd = new Random();
            StringBuilder sb = new StringBuilder();
            for(int i=0; i < length; i++)
            {
                sb.Append(pattern[rd.Next(0,pattern.Length)]);
            }
            return sb.ToString();
        }
        public static string SEOUrl (string url)
        {
            url = url.ToLower().Trim();
            url = Regex.Replace(url, @"[aàảãáạăằẳẵắặâầẩẫấậ]", "a");
            url = Regex.Replace(url, @"[èẽéẹeêềểễếệ]", "e");
            url = Regex.Replace(url, @"[oòỏõóọôồổỗốộơờởỡớợ]", "o");
            url = Regex.Replace(url, @"[ùúụũủuừứửữựư]", "u");
            url = Regex.Replace(url, @"[íìịĩi]", "i");
            url = Regex.Replace(url, @"[ýỳỷỹỵy]", "y");
            url = Regex.Replace(url, @"[đ]", "d");
            url = Regex.Replace(url.Trim(), @"[^0-9a-z-\s]", "").Trim();
            url = Regex.Replace(url.Trim(), @"\s+", "-");
            url = Regex.Replace(url, @"\s", "-");
            while (true)
            {
                if(url.IndexOf("--") != -1)
                {
                    url = url.Replace("--", "-");
                }
                else
                {
                    break;
                }
            }
            return url;

        }
        public static async Task<string> UpLoadFile(IFormFile file,string sDirectory,string? newname = null)
        {
            try
            {
                if (newname == null) newname = file.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", sDirectory);
                CreateIfMissing(path);
                string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", sDirectory,newname);
                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
                var fileExt = Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt.ToLower()))
                {
                    return null;
                }
                else
                {
                    using(var stream = new FileStream(pathFile, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return newname;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
