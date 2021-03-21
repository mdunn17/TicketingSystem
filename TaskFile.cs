using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketingSystem
{
    public class TaskFile
    {

        public string filePath { get; set; }
        public List<Task> Task { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TaskFile(string taskFilePath)
        {
            filePath = taskFilePath;
            Task = new List<Task>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    string line = sr.ReadLine();
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] ticketDetails = line.Split(',');
                        task.ticketId = UInt64.Parse(ticketDetails[0]);
                        task.summary = ticketDetails[1];
                        task.status = ticketDetails[2];
                        task.priority = ticketDetails[3];
                        task.submitter = ticketDetails[4];
                        task.assigned = ticketDetails[5];
                        task.watching = ticketDetails[6];
                        task.projectName = ticketDetails[7];
                        task.dueDate = ticketDetails[8];
                    }
                    else
                    {
                        task.ticketId = UInt64.Parse(line.Substring(0, idx - 1));
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf('"');
                        task.summary = line.Substring(0, idx);
                        line = line.Substring(idx + 2);
                        idx = line.IndexOf(",");
                        task.status = line.Substring(0, idx);
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf(",");
                        task.priority = line.Substring(0, idx);
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf(",");
                        task.submitter = line.Substring(0, idx);
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf(",");
                        task.assigned = line.Substring(0, idx);
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf(",");
                        task.watching = line.Substring(0, idx);
                        line = line.Substring(idx + 2);
                        idx = line.IndexOf(",");
                        task.projectName = line.Substring(0, idx);
                        line = line.Substring(idx + 2);
                        idx = line.IndexOf(",");
                        task.dueDate = line.Substring(0, idx);

                    }
                    Task.Add(task);
                }  
                sr.Close();
                logger.Info("Tickets in file {Count}", Task.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }



        public void AddTask(Task task)
        {
            try
            {
                task.ticketId = Task.Max(m => m.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{task.ticketId},{task.summary},{task.status},{task.priority},{task.submitter},{task.assigned},{task.watching},{task.projectName},{task.dueDate}");
                sw.Close();

                Task.Add(task);
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