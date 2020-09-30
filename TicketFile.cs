using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ServiceTickets_Classes
{
    public class TicketFile
    {
          public string filePath { get; set; }

          public List<string> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    
        public TicketFile(string movieFilePath){

            filePath = movieFilePath;
            
            try{
                StreamReader sr = new StreamReader(filePath);

               

                while(!sr.EndOfStream){
                    string line = sr.ReadLine();
                    Tickets.Add(line);
                }
            } catch(){
                
            }
        }
    
    }
}
