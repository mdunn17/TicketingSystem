using System;
using System.Collections.Generic;

namespace TicketingSystem
{
    public abstract class Ticket
    {
        // private field
        public UInt64 ticketId { get; set; }
        string _summary;
        public string summary
        {
            get
            {
                return this._summary;
            }
            set
            {
                // if there is a comma(,) in the summary, wrap it in quotes
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
                // if there is a comma(,) in the watchers, wrap it in quotes
                this._watching = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }    
        public virtual string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\n";
        }
    }

    public class Defect : Ticket
    {
        public string severity { get; set; }
        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\nSeverity: {severity}\n";
        }
    }
    public class Enhancement : Ticket
    {
        public string software { get; set; }
        public string cost { get; set; }
        string _reason;
        public string reason
        {
            get
            {
                return this._reason;
            }
            set
            {
                // if there is a comma(,) in the title, wrap it in quotes
                this._reason = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }
        public string estimate { get; set; }
        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}";
        }
    }
    public class Task : Ticket
    {
        public string projectName { get; set; }
        string _dueDate;
        public string dueDate
        {
            get
            {
                return this._dueDate;
            }
            set
            {
                // if there is a comma(,) in the watchers, wrap it in quotes
                this._dueDate = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }
        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\nProject Name: {projectName}\nDue Date: {dueDate}";
        }
    }

}