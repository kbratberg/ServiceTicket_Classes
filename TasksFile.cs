using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ServiceTickets_Classes
{
    public class TasksFile
    {
          public string filePath { get; set; }

          public List<Tasks> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    
        public TasksFile(string ticketFilePath){
            Tickets = new List<Tasks>();
            filePath = ticketFilePath;
            Tasks serviceTicket = new Tasks();
            try{
                StreamReader sr = new StreamReader(filePath);
                while(!sr.EndOfStream){
                    
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
                    serviceTicket.employeeWatching = ticketDetails[6].Split('|').ToList();
                    serviceTicket.projectName = ticketDetails[7];
                    serviceTicket.dueDate = ticketDetails[8];
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
                        String employeesWatching = line.Substring(0, idx);
                        serviceTicket.employeeWatching = employeesWatching.Split('|').ToList();

                        line =line.Substring(idx + 1);
                        idx = line.IndexOf(',');
                        serviceTicket.projectName = line.Substring(0, idx);

                        line =line.Substring(idx + 1);
                        serviceTicket.dueDate = line.Substring(0);
                }
                Tickets.Add(serviceTicket);
                }
                
                sr.Close();
                logger.Info("Tasks in File: {Count}", Tickets.Count);
            } catch(Exception ex)
            {
                logger.Error(ex.Message);
            }

        }
        
            public void AddTaskTicket(Tasks serviceTicket){
                serviceTicket.ticketId = Tickets.Max(t => t.ticketId) + 1;

                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{serviceTicket.ticketId},{serviceTicket.summary},{serviceTicket.status},{serviceTicket.priority},{serviceTicket.yourName},{serviceTicket.assigned},{string.Join('|', serviceTicket.employeeWatching)},{serviceTicket.projectName},{serviceTicket.dueDate}");
                sw.Close();
                Tickets.Add(serviceTicket);
            }
    
    }
}
