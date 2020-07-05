using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData
{
    [Serializable]
    public class SocketData
    {
        public string DataType { get; set; }
        public object Data { get; set; }
        public SocketData(string type, object data)
        {
            DataType = type;
            Data = data;
        }
    }
}
