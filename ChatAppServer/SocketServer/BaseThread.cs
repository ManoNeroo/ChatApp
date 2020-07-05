using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAppServer.SocketServer
{
    public abstract class BaseThread
    {
        private Thread _thread;

        protected BaseThread()
        {
            _thread = new Thread(new ThreadStart(this.Run));
        }

        
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;
        public bool IsBackground { get => _thread.IsBackground; set => _thread.IsBackground = value; }

        
        public abstract void Run();
    }
}
