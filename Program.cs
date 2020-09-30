using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace ServiceTickets_Classes
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
             string ticketFilePath = Directory.GetCurrentDirectory() + "\\ServiceTickets.csv";
            
            logger.Info("Program started");

            // Movie movie = new Movie
            // {
            //     movieId = 1,
            //     title = "Jeff's Killer Movie (2019)",
            //     genres = new List<string> { "Action", "Romance", "Comedy" }
            // };
            // Console.WriteLine(movie.Display());
            TicketFile ticketFile = new TicketFile(ticketFilePath);
            string choice = "";
            do
            {
                // display choices to user
                Console.WriteLine("1) Add Service TIcket");
                Console.WriteLine("2) Display All Service Tickets");
                Console.WriteLine("Enter to quit");
                // input selection
                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);

                
                if (choice == "1")
                {
                    
                       ServiceTicket serviceTicket = new ServiceTicket();
                    
                    Console.WriteLine("Enter ticket summary");
                    
                    serviceTicket.summary = Console.ReadLine();
                    
                   Console.WriteLine("Enter ticket status");
                   serviceTicket.status = Console.ReadLine();
                   Console.WriteLine("Enter ticket priority");
                   serviceTicket.priority = Console.ReadLine();
                   Console.WriteLine("Enter your name");
                   serviceTicket.yourName = Console.ReadLine();
                     Console.WriteLine("Enter assigned employee name");
                    serviceTicket.assigned = Console.ReadLine();
                   
                          // input watching
                        string input;
                        do
                        {
                            
                             Console.WriteLine("Enter employees watching. Ender 1 to quit");
                            
                            input = Console.ReadLine();
                           
                            if (input != "1" && input.Length > 0)
                            {
                                serviceTicket.employeeWatching.Add(input);
                            }
                        } while (input != "1");
                        
                        if (serviceTicket.employeeWatching.Count == 0)
                        {
                            serviceTicket.employeeWatching.Add("(no genres listed)");
                        }
                         
                        ticketFile.AddTicket(serviceTicket);
                    
                } else if (choice == "2")
                {
                   
                    foreach(ServiceTicket s in ticketFile.Tickets)
                    {
                        Console.WriteLine(s.Display());
                    }
                }
            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
        
