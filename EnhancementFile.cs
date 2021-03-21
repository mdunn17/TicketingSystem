using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketingSystem
{
    public class EnhancementFile
    {

        public string filePath { get; set; }
        public List<Enhancement> Enhancements { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        
        public EnhancementFile(string enhancementFilePath)
        {
            filePath = enhancementFilePath;
            Enhancements = new List<Enhancement>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    Enhancement enhancement = new Enhancement();
                    string line = sr.ReadLine();
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] ticketDetails = line.Split(',');
                        enhancement.ticketId = UInt64.Parse(ticketDetails[0]);
                        enhancement.summary = ticketDetails[1];
                        enhancement.status = ticketDetails[2];
                        enhancement.priority = ticketDetails[3];
                        enhancement.submitter = ticketDetails[4];
                        enhancement.assigned = ticketDetails[5];
                        enhancement.watching = ticketDetails[6];
                        enhancement.software = ticketDetails[7];
                        enhancement.cost = ticketDetails[8];
                        enhancement.reason = ticketDetails[9];
                        enhancement.estimate = ticketDetails[10];
                    }
                    else
                    {
                        enhancement.ticketId = UInt64.Parse(line.Substring(0, idx - 1));
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf('"');
                        enhancement.summary = line.Substring(0, idx);
                        line = line.Substring(idx + 2);

                        string[] details = line.Split(',');
                        enhancement.status = details[0];
                        enhancement.priority = details.Length > 1 ? details[1] : "priority unassigned";
                        enhancement.submitter = details.Length > 2 ? details[2] : "submitter unknown";
                        enhancement.assigned = details.Length > 3 ? details[3] : "no assigned employee";
                        enhancement.watching = details.Length > 4 ? details[4] : "no watchers";
                        enhancement.software = details.Length > 5 ? details [5] : "software undetermined";
                        enhancement.cost = details.Length > 6 ? details [6] : "cost undetermined";
                        enhancement.reason = details.Length > 7 ? details [7] : "reason not supplied";
                        enhancement.estimate = details.Length > 8 ? details [8] : "no estimate";

                    }
                    Enhancements.Add(enhancement);
                }  
                sr.Close();
                logger.Info("Tickets in file {Count}", Enhancements.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }



        public void AddEnhancement(Enhancement enhancement)
        {
            try
            {
                enhancement.ticketId = Enhancements.Max(m => m.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{enhancement.ticketId},{enhancement.summary},{enhancement.status},{enhancement.priority},{enhancement.submitter},{enhancement.assigned},{enhancement.watching},{enhancement.software},{enhancement.cost},{enhancement.reason},{enhancement.estimate}");
                sw.Close();

                Enhancements.Add(enhancement);
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