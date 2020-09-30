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

          public List<ServiceTicket> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    
        public TicketFile(string movieFilePath){

            filePath = movieFilePath;
            Tickets = new List<ServiceTicket>();
            try{
                StreamReader sr = new StreamReader(filePath);
                while(!sr.EndOfStream){
                    ServiceTicket serviceTicket = new ServiceTicket();
                    string line = sr.ReadLine();
                int idx = line.IndexOf('"');
                if(idx == -1){
                    string[] ticketDetails = line.Split(",");
                    
                    serviceTicket.ticketId = UInt64.Parse(ticketDetails[0]);
                    serviceTicket.summary = ticketDetails[1];
                    serviceTicket.status = ticketDetails[2];
                    serviceTicket.priority = ticketDetails[3];
                    serviceTicket.yourName = ticketDetails[4];
                    serviceTicket.assigned = ticketDetails[5];
                    serviceTicket.watching = ticketDetails[6].Split('|').ToList();
                }
                else{
                    serviceTicket.ticketId = UInt64.Parse(line.Substring(0, idx - 1));
                        // remove movieId and first quote from string
                        line = line.Substring(idx + 1);
                        // find the next quote
                        idx = line.IndexOf('"');
                        // extract the movieTitle
                        serviceTicket.summary = line.Substring(0, idx);
                        // remove title and last comma from the string
                        line = line.Substring(idx + 2);
                        // replace the "|" with ", "
                        idx = line.IndexOf(',');
                        serviceTicket.status = line.Substring(0, idx);

                        line = line.Substring(idx + 1);
                        idx = line.IndexOf(',');
                        serviceTicket.priority = line.Substring(0, idx);

                        line = line.Substring(idx + 1);
                        idx = line.IndexOf(',');
                        serviceTicket.yourName = line.Substring(0, idx);

                        line = line.Substring(idx + 1);
                        idx = line.IndexOf(',');
                        serviceTicket.assigned = line.Substring(0, idx);

                        line = line.Substring(idx + 1);
                        idx = line.IndexOf(',');
                        serviceTicket.watching = line.Split('|').ToList();
                }
                Tickets.Add(serviceTicket);
                }

                sr.Close();
                logger.Info("Tickets in File: {Count}", Tickets.Count);
            } catch(){

            }

            public void AddTicket(ServiceTicket serviceTicket){
                serviceTicket.ticketId = Tickets.Max(s => s.ticketId) + 1;

                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{serviceTicket.ticketId},{serviceTicket.summary},{serviceTicket.status},{serviceTicket.assigned},{string.Join('|', serviceTicket.employeeWatching)}");
                sw.Close();
                Tickets.Add(serviceTicket);
            }
        }
    
    }
}
