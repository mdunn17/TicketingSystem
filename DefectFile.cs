using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketingSystem
{
    public class DefectFile
    {

        public string filePath { get; set; }
        public List<Defect> Defects { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        public DefectFile(string defectFilePath)
        {
            filePath = defectFilePath;
            Defects = new List<Defect>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Defect defect = new Defect();
                    string line = sr.ReadLine();
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] ticketDetails = line.Split(',');
                        defect.ticketId = UInt64.Parse(ticketDetails[0]);
                        defect.summary = ticketDetails[1];
                        defect.status = ticketDetails[2];
                        defect.priority = ticketDetails[3];
                        defect.submitter = ticketDetails[4];
                        defect.assigned = ticketDetails[5];
                        defect.watching = ticketDetails[6];
                        defect.severity = ticketDetails[7];
                    }
                    else
                    {
                        defect.ticketId = UInt64.Parse(line.Substring(0, idx - 1));
                        line = line.Substring(idx);
                        idx = line.LastIndexOf('"');
                        defect.summary = line.Substring(0, idx + 1);
                        line = line.Substring(idx + 2);

                        string[] details = line.Split(',');
                        defect.status = details[0];
                        defect.priority = details.Length > 1 ? details[1] : "priority unassigned";
                        defect.submitter = details.Length > 2 ? details[2] : "submitter unknown";
                        defect.assigned = details.Length > 3 ? details[3] : "no assigned employee";
                        defect.watching = details.Length > 4 ? details[4] : "no watchers";
                        defect.severity = details.Length > 5 ? details [5] : "severity unassigned";

                    }
                    Defects.Add(defect);
                }  
                sr.Close();
                logger.Info("Tickets in file {Count}", Defects.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }



        public void AddDefect(Defect defect)
        {
            try
            {
                defect.ticketId = Defects.Max(d => d.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{defect.ticketId},{defect.summary},{defect.status},{defect.priority},{defect.submitter},{defect.assigned},{defect.watching},{defect.severity}");
                sw.Close();

                Defects.Add(defect);
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