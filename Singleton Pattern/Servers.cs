using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{

    internal class Servers
    {
        private static Lazy<Servers> instance = new Lazy<Servers>(() => new Servers());
        private object lockObject = new object();
        public List<string> serverList;
        public Servers()
        {
            serverList = new List<string>();
        }
        public static Servers Instance
        {
            get
            {
                return instance.Value;
            }
        }
        public bool Add(string server)
        {
            lock (lockObject)
            {
                if (server.Contains("http") || server.Contains("https"))
                {
                    foreach (string s in serverList) if (s == server) return false;

                    serverList.Add(server);
                    return true;
                }
                return false;
            }
        }
        public void print(string filter)
        {
            lock (lockObject)
            {
                foreach (string server in serverList)
                    if (server.Contains(filter + "://")) Console.WriteLine(server);
            }
        }
    }
}