using System;
using System.Collections.Generic;

namespace TicketingSystem
{
    public class Ticket
    {

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
        string _status;
        public string status
        {
            get
            {
                return this._status;
            }
            set
            {
                // if there is a comma(,) in the title, wrap it in quotes
                this._status = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }
        string _priority;
        public string priority
        {
            get
            {
                return this._priority;
            }
            set
            {
                // if there is a comma(,) in the title, wrap it in quotes
                this._priority = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }
        string _submitter;
        public string submitter
        {
            get
            {
                return this._submitter;
            }
            set
            {
                // if there is a comma(,) in the title, wrap it in quotes
                this._submitter = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }
        string _assigned;
        public string assigned
        {
            get
            {
                return this._assigned;
            }
            set
            {
                // if there is a comma(,) in the title, wrap it in quotes
                this._assigned = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }
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
            return $"Summary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\n";
            //sw.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", i, summary, status, priority, submitter, assigned, watching);
                    //i++;
        }
    }
}