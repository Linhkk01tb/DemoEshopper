using System.Text;

namespace Eshopper.Helpers
{
    public class Util
    {
<<<<<<< HEAD
        public static string UploadHinh(IFormFile Hinh, string folder)
=======
        public async static Task<string> UploadHinh(IFormFile Hinh, string folder)
>>>>>>> developer
        {
            try
            {
                var fullpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, Hinh.FileName);
<<<<<<< HEAD
                using (var myfile = new FileStream(fullpath, FileMode.CreateNew))
                {
                    Hinh.CopyToAsync(myfile);
=======
                using (var myfile = new FileStream(fullpath, FileMode.OpenOrCreate))
                {
                    await Hinh.CopyToAsync(myfile);
>>>>>>> developer
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
