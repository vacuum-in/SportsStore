using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;
using NetTools;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace SportsStore.Models
{
    public class Debug
    {



        string hostname = System.Environment.MachineName;
        int cpu = System.Environment.ProcessorCount;
        string username = System.Environment.UserName;
        string os = (System.Environment.OSVersion).ToString();
        string domain = System.Environment.UserDomainName;
        string dns = System.Net.Dns.GetHostName();
        ICMPScan png = new ICMPScan();
        private void GetInfo()
        {
            string[] ips = new string[30];
            var dns1 = System.Net.Dns.GetHostEntry(dns);
            string fqdn = dns1.HostName;
            int i = 0;
            foreach (var ip in dns1.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ips[i] = ip.ToString();
                    i++;
                }
            }
            for (int j = 0; j < ips.Length; j++)
            {
                string currentIP = GetIpMask(ips[j]);
                if (currentIP != String.Empty)
                {
                    png.PingLan(currentIP)
                }
            }

            
       //     png.PingLan();
        }
        private string GetIpMask(string fullip)
        {
            string emty = String.Empty;
            Regex regex = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            if (regex.IsMatch(fullip))
            {
                Regex regex2 = new Regex(@"(\d{1,3}\.\d{1,3}\.\d{1,3}\.)\d{1,3}");
                Match matches = regex2.Match(fullip);
              //  Console.WriteLine("Matches ip {0}", matches.Groups[1].Value);
                return matches.Groups[1].Value;
            }
            return String.Empty;
        }

        //    ViewBag.hostname = ("Hostname: " + hostname); 
        //        ViewBag.OS = ("OS Version is " + os);
        //        ViewBag.ww = (domain + "\\" + username);
        //}
    }
}
