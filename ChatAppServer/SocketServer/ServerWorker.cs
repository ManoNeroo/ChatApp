using System;
using System.Collections.Generic;
using System.Net.Sockets;
using ChatAppServer.Handler;
using ReferenceData;
using ReferenceData.Utils;

namespace ChatAppServer.SocketServer
{
    public class ServerWorker : BaseThread
    {

        public Socket ClientSocket { get; set; }
        public Server Server { get; set; }
        public ServerWorker(Server server, Socket clientSocket)
        {
            Server = server;
            ClientSocket = clientSocket;
        }
        public override void Run()
        {
            try
            {
                handleClientSocket();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Server.RemoveWorker(this);
                ClientSocket.Close();
            }
        }

        private void handleClientSocket()
        {
            while (true)
            {
                SocketData data = receive();
                string dataType = data.DataType.ToUpper();
                if(dataType.Equals("CLOSE"))
                {
                    Server.RemoveWorker(this);
                    break;
                }else if(dataType.Equals("SIGNOUT")) 
                {
                    new SignOutHandler(this).Handle(data);
                    break;
                } else
                {
                    switch(dataType)
                    {
                        case "SIGNUP":
                            new SignUpHandler(this).Handle(data);
                            break;
                        case "SIGNIN":
                            new SignInHandler(this).Handle(data);
                            break;
                        case "LOADMESSAGE":
                            new LoadMessageHandler(this).Handle(data);
                            break;
                        case "MESSAGE":
                            new MessageHandler(this).Handle(data);
                            break;
                    }
                }
            }
            ClientSocket.Close();
        }
        public void send(object obj)
        {
            ClientSocket.Send(ChatAppUtils.Serialize(obj));
        }
        public SocketData receive()
        {
            byte[] data = new byte[79000000];
            ClientSocket.Receive(data);
            return (SocketData)ChatAppUtils.Deserialize(data);
        }

    }
}
