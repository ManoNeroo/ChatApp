using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ChatApp.Utils
{
    public class ClientUtils
    {
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        public static byte[] ConvertFileToByte(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] bytes = System.IO.File.ReadAllBytes(fileName);
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;
        }
    }
}
