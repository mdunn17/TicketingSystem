using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketingSystem
{
    public class TicketFile
    {

        public string filePath { get; set; }
        public List<Ticket> Tickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        public TicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();


            try
            {
                StreamReader sr = new StreamReader(filePath);

                sr.ReadLine();
                while (!sr.EndOfStream)
                {

                    Ticket ticket = new Ticket();
                    string line = sr.ReadLine();

                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {

                        string[] ticketDetails = line.Split(',');

                        ticket.summary = ticketDetails[1];
                        ticket.status = ticketDetails[2];
                        ticket.priority = ticketDetails[3];
                        ticket.submitter = ticketDetails[4];
                        ticket.assigned = ticketDetails[5];
                        ticket.watching = ticketDetails[6];
                    }
                    else
                    {

                        line = line.Substring(idx + 1);

                        idx = line.IndexOf('"');
                        ticket.summary = line.Substring(0, idx);

                        line = line.Substring(idx + 2);

                    }
                    Tickets.Add(ticket);
                }

                sr.Close();
                logger.Info("Tickets in file {Count}", Tickets.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }



        public void AddTicket(Ticket ticket)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.summary}, {ticket.status}, {ticket.priority}, {ticket.submitter}, {ticket.assigned}, {ticket.watching}");
                sw.Close();

                Tickets.Add(ticket);
                // log transaction
                logger.Info("Ticket added");
            } 
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}