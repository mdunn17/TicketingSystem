using System;
using System.IO;
using NLog.Web;
using System.Collections.Generic;

namespace TicketingSystem
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");
            //string ticketFilePath = Directory.GetCurrentDirectory() + "\\ticketingSystem.txt";
            string defectFilePath = Directory.GetCurrentDirectory() + "\\Defects.csv";
            string enhancementFilePath = Directory.GetCurrentDirectory() + "\\Enhancements.csv";
            string taskFilePath = Directory.GetCurrentDirectory() + "\\Task.csv";
            string choice = "";
            
            DefectFile defectFile = new DefectFile(defectFilePath);
            EnhancementFile enhancementFile = new EnhancementFile(enhancementFilePath);
            TaskFile taskFile = new TaskFile(taskFilePath);

            //TicketFile ticketFile = new TicketFile(ticketFilePath);
            do
            {
                // ask user a question
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1) Read data from ticket file.");
                Console.WriteLine("2) Create a new ticket.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);
                string type = "";

                if (choice == "1")
                {
                    Console.WriteLine("Please select Ticket Type:\n1 - Bug/Defect\n2 - Enhancement\n3 - Task");
                    type = Console.ReadLine();
                    //MAKE A MENU FOR WHAT KIND OF TICKET TYPE THE WANT TO READ--------------------------------------------------------------------------------------------
                    if (type == "1")
                    {
                        foreach(Defect d in defectFile.Defects)
                        {
                            Console.WriteLine(d.Display());
                        }
                    }
                    else if (type == "2")
                    {
                        foreach(Enhancement e in enhancementFile.Enhancements)
                        {
                            Console.WriteLine(e.Display());
                        }
                    }
                    else if (type == "3")
                    {
                        foreach(Task t in taskFile.Task)
                        {
                            Console.WriteLine(t.Display());
                        }
                    }
                    //foreach(Ticket t in ticketFile.Tickets)
                    //{
                    //    Console.WriteLine(t.Display());
                    //}
                    
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Please select Ticket Type:\n1 - Bug/Defect\n2 - Enhancement\n3 - Task");
                    type = Console.ReadLine();

                    if(type == "1")
                    {
                        
                        Defect defect = new Defect();

                        Console.WriteLine("Enter the ticket summary:");
                        defect.summary = Console.ReadLine();

                        Console.WriteLine("Enter the ticket status:");
                        defect.status = Console.ReadLine();

                        Console.WriteLine("Enter the ticket priority:");
                        defect.priority = Console.ReadLine();

                        Console.WriteLine("Enter the ticket submitter name:");
                        defect.submitter = Console.ReadLine();

                        Console.WriteLine("Enter the name of the employee assigned to this ticket:");
                        defect.assigned = Console.ReadLine();

                        Console.WriteLine("Enter who is watching this ticket (seperate names by a comma):");
                        defect.watching = Console.ReadLine();

                        Console.WriteLine("Enter the severity of this defect:");
                        defect.severity = Console.ReadLine();

                        defectFile.AddDefect(defect);
                    }
                    else if(type == "2")
                    {
                        
                        Enhancement enhancement = new Enhancement();

                        Console.WriteLine("Enter the ticket summary:");
                        enhancement.summary = Console.ReadLine();

                        Console.WriteLine("Enter the ticket status:");
                        enhancement.status = Console.ReadLine();

                        Console.WriteLine("Enter the ticket priority:");
                        enhancement.priority = Console.ReadLine();

                        Console.WriteLine("Enter the ticket submitter name:");
                        enhancement.submitter = Console.ReadLine();

                        Console.WriteLine("Enter the name of the employee assigned to this ticket:");
                        enhancement.assigned = Console.ReadLine();

                        Console.WriteLine("Enter who is watching this ticket (seperate names by a comma):");
                        enhancement.watching = Console.ReadLine();

                        Console.WriteLine("Enter the software for this enhancement:");
                        enhancement.software = Console.ReadLine();

                        Console.WriteLine("Enter the Cost for this enhancement:");
                        enhancement.cost = Console.ReadLine();

                        Console.WriteLine("Enter the reason for this enhacement:");
                        enhancement.reason = Console.ReadLine();

                        Console.WriteLine("Enter the estimate for this enhancement:");
                        enhancement.estimate = Console.ReadLine();

                        enhancementFile.AddEnhancement(enhancement);
                    }
                    else if(type == "3")
                    {
                        
                        Task task = new Task();
                        

                        Console.WriteLine("Enter the ticket summary:");
                        task.summary = Console.ReadLine();

                        Console.WriteLine("Enter the ticket status:");
                        task.status = Console.ReadLine();

                        Console.WriteLine("Enter the ticket priority:");
                        task.priority = Console.ReadLine();

                        Console.WriteLine("Enter the ticket submitter name:");
                        task.submitter = Console.ReadLine();

                        Console.WriteLine("Enter the name of the employee assigned to this ticket:");
                        task.assigned = Console.ReadLine();

                        Console.WriteLine("Enter who is watching this ticket (seperate names by a comma):");
                        task.watching = Console.ReadLine();

                        Console.WriteLine("Enter the project name for this task:");
                        task.projectName = Console.ReadLine();

                        Console.WriteLine("Enter the due date for this task:");
                        Console.WriteLine("Day:");
                        string day = Console.ReadLine();
                        Console.WriteLine("Month:");
                        string month = Console.ReadLine();
                        Console.WriteLine("Year:");
                        string year = Console.ReadLine();
                        string date = day + " " + month + ", " + year;
                        task.dueDate = date;

                        taskFile.AddTask(task);
                    }

                }
            } while (choice == "1" || choice == "2");
        }
    }
}
