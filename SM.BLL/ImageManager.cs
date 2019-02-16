using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SM.BLL
{
    public class ImageManager
    {
        public byte[] ConvertToByte(HttpPostedFileBase file)
        {
            byte[] imageData = null;

            if (file != null && file.ContentLength > 0)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" ||
                    file.ContentType == "image/png")
                {
                    if (file.ContentLength <= (1* 1024 * 1024))
                    {
                        imageData = new byte[file.ContentLength];
                        file.InputStream.Read(imageData, 0, file.ContentLength);
                    }
                    else
                    {
                        throw new Exception("File size should be less than 1 MB");
                    }
                }
                else
                {
                    throw new Exception("Error format, Recommend is jpg/png/jpeg");
                }
                return imageData;
            }
            return null;
        }
    }
}
