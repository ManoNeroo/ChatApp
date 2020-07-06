using ChatApp.Handler;
using ReferenceData;
using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatApp.Utils
{

    public class ChatClient
    {
        public string ServerName { get; set; }
        public int ServerPort { get; set; }
        public Socket Socket { get; set; }
        public bool IsConnected { get; set; }
        public ChatClient(string serverName, int serverPort)
        {
            ServerName = serverName;
            ServerPort = serverPort;
        }

        public void Connect()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ServerName), ServerPort);
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket.Connect(ipep);
                IsConnected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                IsConnected = false;
            }
        }

        public void Close()
        {
            if(IsConnected)
            {
                send(new SocketData("CLOSE", null));
                IsConnected = false;
            }
        }
        public bool SignUp(SocketData data)
        {
            if (data.DataType.ToUpper().Equals("SIGNUP"))
            {
                send(data);
                SocketData response = receive();
                if ((bool)response.Data)
                {
                    return true;
                }
            }
            return false;
        }
        public Account SignIn(SocketData data)
        {
            if (data.DataType.ToUpper().Equals("SIGNIN"))
            {
                send(data);
                SocketData response = receive();
                return (Account)response.Data;
            }
            return null;
        }

        public void SignOut(Account acc)
        {
            if(IsConnected)
            {
                SocketData data = new SocketData("SIGNOUT", acc);
                send(data);
                IsConnected = false;
            }
        }

        public void startReadResponse(ReadResponseHandler handler)
        {
            Thread t = new Thread(() =>
            {
                handler.readResponseLoop();
            });
            t.IsBackground = true;
            t.Start();
        }
        public void send(object obj)
        {
            if(IsConnected)
            {
                Socket.Send(serialize(obj));
            }
        }
        public SocketData receive()
        {
            byte[] data = new byte[92160000];
            if (IsConnected)
            {
                Socket.Receive(data);
            }
            return (SocketData)deserialize(data);
        }
        private byte[] serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            byte[] bytes = stream.ToArray();
            stream.Flush();
            return bytes;
        }

        private object deserialize(byte[] data)
        {
            object obj;
            MemoryStream stream = new MemoryStream(data);
            stream.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                obj = formatter.Deserialize(stream);
            }catch(Exception e)
            {
                Console.WriteLine(e);
                obj = null;
            }
            return obj;
        }
        public string Test(SocketData data)
        {
            send(data);
            SocketData response = receive();
            return (string)response.Data;
        }
    }
}
