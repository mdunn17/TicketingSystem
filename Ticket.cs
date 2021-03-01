using System;
using System.Collections.Generic;

namespace TicketingSystem
{
    public class Ticket
    {
        public UInt64 ticketId { get; set; }
        // private field
        string _summary;
        public string summary
        {
            get
            {
                return this._summary;
            }
            set
            {
                // if there is a comma(,) in the title, wrap it in quotes
                this._summary = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        string _watching;
        public string watching
        {
            get
            {
                return this._watching;
            }
            set
            {
                // if there is a comma(,) in the title, wrap it in quotes
                this._watching = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }    


        public string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\n";
            //sw.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", i, summary, status, priority, submitter, assigned, watching);
                    //i++;
        }
    }
}