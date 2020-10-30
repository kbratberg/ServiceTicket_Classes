using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTickets_Classes
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
             
            
            logger.Info("Program started");

            
            string choice = "";
            do
            {
                // display choices to user
                Console.WriteLine("1) Add Bug/Defect service ticket");
                Console.WriteLine("2) Add Enhancement service ticket");
                Console.WriteLine("3) Add Task service ticket");
                Console.WriteLine("4) Display All Service Tickets");
                Console.WriteLine("5) Search for a ticket");
                Console.WriteLine("Enter to quit");
                // input selection
                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);

            
                    string ticketFilePath;

                    if(choice == "1"){
                    ticketFilePath = Directory.GetCurrentDirectory() + "\\ServiceTickets.csv";
                    TicketFile ticketFile = new TicketFile(ticketFilePath);
                    Bug serviceTicket = new Bug();
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
                            
                             Console.WriteLine("Enter employees watching. Enter 1 to quit");
                            
                            input = Console.ReadLine();
                           
                            if (input != "1" && input.Length > 0)
                            {
                                serviceTicket.employeeWatching.Add(input);
                            }
                        } while (input != "1");
                        
                        if (serviceTicket.employeeWatching.Count == 0)
                        {
                            serviceTicket.employeeWatching.Add("(no employee listed)");
                        }
                        Console.WriteLine("Enter Severity");
                        serviceTicket.severity = Console.ReadLine();
                         
                        ticketFile.AddBugTicket(serviceTicket);
                    }else if (choice == "2"){
                        ticketFilePath = Directory.GetCurrentDirectory() + "\\Enhancements.csv";
                        EnhancementsFile ticketFile = new EnhancementsFile(ticketFilePath);
                        Enhancements serviceTicket = new Enhancements();
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
                            
                             Console.WriteLine("Enter employees watching. Enter 1 to quit");
                            
                            input = Console.ReadLine();
                           
                            if (input != "1" && input.Length > 0)
                            {
                                serviceTicket.employeeWatching.Add(input);
                            }
                        } while (input != "1");
                        
                        if (serviceTicket.employeeWatching.Count == 0)
                        {
                            serviceTicket.employeeWatching.Add("(no employee listed)");
                        }

                        Console.WriteLine("Enter Software");
                        serviceTicket.software = Console.ReadLine();
                        
                        Console.WriteLine("Enter Cost");
                        serviceTicket.cost = Console.ReadLine();

                        Console.WriteLine("Enter Reason");
                        serviceTicket.reason = Console.ReadLine();

                        Console.WriteLine("Enter Estimate");
                        serviceTicket.estimate = Console.ReadLine();


                        ticketFile.AddEnhancementTicket(serviceTicket);
                        
                    }else if (choice == "3"){
                        ticketFilePath = Directory.GetCurrentDirectory() + "\\Tasks.csv";
                        TasksFile ticketFile = new TasksFile(ticketFilePath);
                        Tasks serviceTicket = new Tasks();
                    
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
                            
                             Console.WriteLine("Enter employees watching. Enter 1 to quit");
                            
                            input = Console.ReadLine();
                           
                            if (input != "1" && input.Length > 0)
                            {
                                serviceTicket.employeeWatching.Add(input);
                            }
                        } while (input != "1");
                        
                        if (serviceTicket.employeeWatching.Count == 0)
                        {
                            serviceTicket.employeeWatching.Add("(no employee listed)");
                        }

                        Console.WriteLine("Enter Project Name");
                        serviceTicket.projectName = Console.ReadLine();
                         
                        Console.WriteLine("Enter Due Date");
                        serviceTicket.dueDate = Console.ReadLine();
                         
                        ticketFile.AddTaskTicket(serviceTicket);
                      
                } else if (choice == "4")
                {
                    ticketFilePath = Directory.GetCurrentDirectory() + "\\ServiceTickets.csv";
                    TicketFile bugFile = new TicketFile(ticketFilePath);
                   
                    foreach(Bug b in bugFile.Tickets)
                    {
                        Console.WriteLine(b.Display());
                    }

                    ticketFilePath = Directory.GetCurrentDirectory() + "\\Enhancements.csv";
                    EnhancementsFile enhancementFile= new EnhancementsFile(ticketFilePath);

                    foreach(Enhancements e in enhancementFile.Tickets)
                    {
                        Console.WriteLine(e.Display());
                    }

                    ticketFilePath = Directory.GetCurrentDirectory() + "\\Tasks.csv";
                    TasksFile taskFile= new TasksFile(ticketFilePath);

                    foreach(Tasks t in taskFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                    }

                }else if(choice == "5"){
                    ticketFilePath = Directory.GetCurrentDirectory() + "\\ServiceTickets.csv";
                    TicketFile bugFile = new TicketFile(ticketFilePath);
                   
                    ticketFilePath = Directory.GetCurrentDirectory() + "\\Tasks.csv";
                    TasksFile taskFile= new TasksFile(ticketFilePath);
                    
                    
                    ticketFilePath = Directory.GetCurrentDirectory() + "\\Enhancements.csv";
                    EnhancementsFile enhancementFile= new EnhancementsFile(ticketFilePath);

                    // ask what to search
                    Console.WriteLine("What would you like to search\n1)Priority\n2)Status\n3)Submitter");
                    String searchChoice = Console.ReadLine();
                    do{
                    if(searchChoice == "1"){
                        Console.WriteLine("Enter Priority value");
                        String searchCriteria = Console.ReadLine();
                        var Enhancements = enhancementFile.Tickets.Where(e => e.priority.Contains(searchCriteria));
                        foreach(Enhancements e in enhancementFile.Tickets)
                        {
                            Console.WriteLine(e.Display());
                        }

                        var Bugs = bugFile.Tickets.Where(b => b.priority.Contains(searchCriteria));
                        foreach(Bug b in bugFile.Tickets)
                        {
                            Console.WriteLine(b.Display());
                        }

                        var Tasks = taskFile.Tickets.Where(t => t.priority.Contains(searchCriteria));
                        foreach(Tasks t in taskFile.Tickets)
                        {
                            Console.WriteLine(t.Display());
                        }
                        Console.WriteLine($"There are {Enhancements.Count() + Bugs.Count() + Tasks.Count()} service tickets found");
                    }else if(searchChoice == "2"){
                        Console.WriteLine("Enter Status value");
                        String searchCriteria = Console.ReadLine();
                        var Enhancements = enhancementFile.Tickets.Where(e => e.status.Contains(searchCriteria));
                        foreach(Enhancements e in enhancementFile.Tickets)
                        {
                            Console.WriteLine(e.Display());
                        }

                        var Bugs = bugFile.Tickets.Where(b => b.status.Contains(searchCriteria));
                        foreach(Bug b in bugFile.Tickets)
                        {
                            Console.WriteLine(b.Display());
                        }

                        var Tasks = taskFile.Tickets.Where(t => t.status.Contains(searchCriteria));
                        foreach(Tasks t in taskFile.Tickets)
                        {
                            Console.WriteLine(t.Display());
                        }
                        Console.WriteLine($"There are {Enhancements.Count() + Bugs.Count() + Tasks.Count()} service tickets found");
                    }else if(searchChoice == "3"){
                        Console.WriteLine("Enter Submitter to search");
                        String searchCriteria = Console.ReadLine();
                        var Enhancements = enhancementFile.Tickets.Where(e => e.yourName.Contains(searchCriteria));
                        foreach(Enhancements e in enhancementFile.Tickets)
                        {
                            Console.WriteLine(e.Display());
                        }

                        var Bugs = bugFile.Tickets.Where(b => b.yourName.Contains(searchCriteria));
                        foreach(Bug b in bugFile.Tickets)
                        {
                            Console.WriteLine(b.Display());
                        }

                        var Tasks = taskFile.Tickets.Where(t => t.yourName.Contains(searchCriteria));
                        foreach(Tasks t in taskFile.Tickets)
                        {
                            Console.WriteLine(t.Display());
                        }
                        Console.WriteLine($"There are {Enhancements.Count() + Bugs.Count() + Tasks.Count()} service tickets found");
                    }
                    
                    }while (searchChoice == "1" || searchChoice == "2" || searchChoice == "3"); 
                    
                }
            } while (choice == "1" || choice == "2" || choice =="3" || choice =="4" || choice == "5");

            logger.Info("Program ended");
        }
    }
}
        
