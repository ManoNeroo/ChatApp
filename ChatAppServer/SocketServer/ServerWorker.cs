using System;
using System.Collections.Generic;
using System.Net.Sockets;
using ChatAppServer.Handler;
using ChatAppServer.Utils;
using ReferenceData;

namespace ChatAppServer.SocketServer
{
    public class ServerWorker : BaseThread
    {

        public Socket ClientSocket { get; set; }
        public Server Server { get; set; }
        //public List<ReferenceData.Entity.Conversation> ConversationList = new List<ReferenceData.Entity.Conversation>();
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
            ClientSocket.Send(ServerUtils.Serialize(obj));
        }
        public SocketData receive()
        {
            byte[] data = new byte[1024 * 102400];
            ClientSocket.Receive(data);
            return (SocketData)ServerUtils.Deserialize(data);
        }

    }
}
