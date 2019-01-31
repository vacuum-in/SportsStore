using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using Scanner;

namespace SportsStore.Controllers
{
    public class DebugController : Controller
    {
        public ViewResult Index()
        {
            Debug dbg = new Debug();

            PortScanner scan = new PortScanner("localhost", 80, 1433);


            return View();
        }
    }
}