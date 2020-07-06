using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Utils
{
    public class ServerUtils
    {
        public static byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            byte[] bytes = stream.ToArray();
            stream.Flush();
            return bytes;
        }

        public static object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            stream.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
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
