using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace webApiTask.Helpers
{
    public class ImageHelper
    {
        public void SaveImage(int id, string base64String)
        {
            var path = ConfigurationManager.AppSettings["directoryRoot"];
            var directoryForUser = path + id.ToString();
            try
            {
                if (!Directory.Exists(directoryForUser))
                {
                    Directory.CreateDirectory(directoryForUser);

                }
                base64String = base64String.Replace("data:image/png;base64,", "");
                var img = Base64ToImage(base64String);
                img.Save(directoryForUser + "/profile.png", ImageFormat.Png);

            }
            catch
            {

            }

        }
        public string GetImage(int id)
        {
            var directory = ConfigurationManager.AppSettings["CDNBase"];

            return directory + id.ToString() + "/profile.png";
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}