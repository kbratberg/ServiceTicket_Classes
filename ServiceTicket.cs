using System;
using System.IO;
using System.Collections.Generic;

namespace ServiceTickets_Classes
{
    class ServiceTicket
    {
        public UInt64 ticketId { get; set; }

        string _summary;
        string _status;
        string _priority;
        string _yourName;
        string _assigned;

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

        public string yourName
        {
            get;
            set;
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

        public string Display()
        {
            return $"Ticket Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority Level: {priority}\nYour Name: {yourName}\nAssigned Employee {assigned}\nEmployees Watching {string.Join(", ", employeeWatching)} ";
        }

    }
}
