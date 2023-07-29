using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.RegularExpressions;

namespace OrganicShop.Extension
{
    public static class Extension
    {
        public static string ToVND(this double donGia)
        {
            return donGia.ToString("#,##0") + "VND";
        }
        public static string ToTitleCase(string str)
        {
            string result = str;
            if(!string.IsNullOrEmpty(str)) { 
                var words = str.Split(' ');
                for(int index=0; index<words.Length; index++)
                {
                    var s = words[index];
                    if(s.Length > 0)
                    {
                        words[index] = s[0].ToString().ToUpper() + s.Substring(1);
                    }
                }
                result = string.Join(" ", words);
            
            }
            return result;
        }
        public static string ToUrlFriendly(this string url)
        {
            var result = url.ToLower().Trim();
            result = Regex.Replace(result, "aàảãáạăằẳẵắặâầẩẫấậ", "a");
            result = Regex.Replace(result, "èẽéẹeêềểễếệ", "e");
            result = Regex.Replace(result, "oòỏõóọôồổỗốộơờởỡớợ", "o");
            result = Regex.Replace(result, "ùúụũủuừứửữựư", "u");
            result = Regex.Replace(result,"íìịĩi", "i");
            result = Regex.Replace(result, "ýỳỷỹỵy", "y");
            result = Regex.Replace(result, "đ", "d");
            result = Regex.Replace(result, "[^a-z0-9-]", "");
            result = Regex.Replace(result, "(-)+", "-");



            return result;


        }
    }
}
