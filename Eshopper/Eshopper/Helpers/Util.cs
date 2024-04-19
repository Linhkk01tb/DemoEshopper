using System.Text;

namespace Eshopper.Helpers
{
    public class Util
    {
        public static string UploadHinh(IFormFile Hinh, string folder)
        {
            try
            {
                var fullpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, Hinh.FileName);
                using (var myfile = new FileStream(fullpath, FileMode.CreateNew))
                {
                    Hinh.CopyToAsync(myfile);
                }
                return Hinh.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static string GenerateRandomKey(int length = 5)
        {
            var pattern = @"qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM!";
            var sub = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < length; i++)
            {
                sub.Append(pattern[rd.Next(0, pattern.Length)]);
            }
            return sub.ToString();
        }
    }
}
