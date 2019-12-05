using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Timers;


namespace NewsParser
{
    class Program
    {
        static IndexWebsiteParser parser;
        static Timer timer;

        static void Main(string[] args)
        {
            parser = new FacenewsParser(); 
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(Tick);
            timer.Interval = 3600000;

            GetNews();

            Console.ReadKey();
        }

        static void GetNews()
        {
            timer.Enabled = false;
            parser.ReadAllNewPages();
            timer.Enabled = true;
        }

        static void Tick(object source, ElapsedEventArgs e)
        {
            GetNews();
        }
    }
}
