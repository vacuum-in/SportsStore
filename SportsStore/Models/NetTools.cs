using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace NetTools
{
    class ICMPScan
    {
        public List<string> PingLan(string ip)
        {
            System.Net.NetworkInformation.Ping pngs = new System.Net.NetworkInformation.Ping();

            List<string> addresses = new List<string>();

            for (int i = 0; i < 255; i++)
            {
                string listhost = ip + i;

                try
                {
                    var status = pngs.Send(listhost, 1).Status;
                    if (status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        string curr = "Host " + listhost + " available";
                        addresses.Add(curr);
                    }
                }
                catch (InvalidOperationException e)
                {
                }
            }
            return addresses;
        }
    }
}
