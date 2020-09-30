using System;
using System.IO;
using System.Collections.Generic;

namespace ServiceTickets_Classes
{
    class ServiceTicket
    {
      public UInt64 ticketId {get; set;}

      string _summary;

      public string summary{
          get{
          return this._summary;
          }
          set{
              this._summary = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
          }
      }

      public string yourName{
          get;
          set;
          }

        public string priority{
          get;
          set;
          }
          public string status{
          get;
          set;
          }
          public string assigned{
          get;
          set;
          }
          public List<string> employeeWatching {get; set;}
          public string watching{
          get;
          set;
          }

    }
}
