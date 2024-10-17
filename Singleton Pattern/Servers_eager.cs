using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{
    internal class Servers_eager
    {
        private static Servers_eager instance = new Servers_eager();
        private object lockObject = new object();
        public List<string> serverList;

        private Servers_eager()
        {
            serverList = new List<string>();
        }

        public static Servers_eager Instance
        {
            get { return instance; }
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