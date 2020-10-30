using System;
using System.IO;
using System.Collections.Generic;

namespace ServiceTickets_Classes
{
    public abstract class ServiceTicket
    {
        
        public string _summary;


        public string summary
        {
            get
            {
                return this._summary;
            }
            set
            {
                this._summary = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }

        

        public string priority
        {
            get;
            set;
        }
        public string status
        {
            get;
            set;
        }

        public string yourName
        {
            get;
            set;
        }
        public string assigned
        {
            get;
            set;
        }
        public List<string> employeeWatching { get; set; }
        

        public ServiceTicket()
        {
            employeeWatching = new List<string>();
        }

        public virtual string Display()
        {
            return $"Summary: {summary}\nStatus: {status}\nPriority Level: {priority}\nYour Name: {yourName}\nAssigned Employee {assigned}\nEmployees Watching {string.Join(", ", employeeWatching)} ";
        }

    }

    public class Bug : ServiceTicket {
        public UInt64 ticketId { get; set; }
        public string severity {get; set;}

        public override string Display()
        {
           return $"Ticket Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority Level: {priority}\nYour Name: {yourName}\nAssigned Employee: {assigned}\nEmployees Watching: {string.Join(", ", employeeWatching)}\nSeverity: {severity} "; 
        }
    }

    public class Enhancements : ServiceTicket{
        public UInt64 ticketId { get; set; }
        public string software {get; set;}
        public string cost {get; set;}
        public string reason {get; set;}
        public string estimate {get; set;}

       public override string Display()
        {
           return $"Ticket Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority Level: {priority}\nYour Name: {yourName}\nAssigned Employee: {assigned}\nEmployees Watching: {string.Join(", ", employeeWatching)}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}"; 
        }
    }

    public class Tasks : ServiceTicket{
        public UInt64 ticketId { get; set; }
        public string projectName {get; set;}
        public string dueDate {get; set;}
        
       public override string Display()
        {
           return $"Ticket Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority Level: {priority}\nYour Name: {yourName}\nAssigned Employee: {assigned}\nEmployees Watching: {string.Join(", ", employeeWatching)}\nProject Name: {projectName}\nDue Date: {dueDate}"; 
        }
    }
}
