using System;
using System.IO;
using NLog.Web;
using System.Collections.Generic;
using System.Linq;

namespace TicketingSystem
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");

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
                Console.WriteLine("3) Search for a specific ticket.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);
                string type = "";

                if (choice == "1")
                {
                    Console.WriteLine("Please select Ticket Type:\n1 - Bug/Defect\n2 - Enhancement\n3 - Task");
                    type = Console.ReadLine();
                    
                    if (type == "1")
                    {
                        Console.WriteLine(defectFile.Defects.Count);
                        foreach(Defect d in defectFile.Defects)
                        {
                            Console.WriteLine(d.Display());
                        }
                    }
                    else if (type == "2")
                    {
                        Console.WriteLine(enhancementFile.Enhancements.Count);
                        foreach(Enhancement e in enhancementFile.Enhancements)
                        {
                            Console.WriteLine(e.Display());
                        }
                    }
                    else if (type == "3")
                    {
                        Console.WriteLine(taskFile.Task.Count);
                        foreach(Task t in taskFile.Task)
                        {
                            Console.WriteLine(t.Display());
                        }
                    }
                    
                    
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
                        
                        Console.WriteLine("Enter who is watching this ticket (seperate names by a | ):");
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

                        Console.WriteLine("Enter who is watching this ticket (seperate names by a | ):");
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

                        Console.WriteLine("Enter who is watching this ticket (seperate names by a | ):");
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
                        string date = day + " " + month + " " + year;
                        task.dueDate = date;

                        taskFile.AddTask(task);
                    }

                }else if (choice == "3")
                {
                    Console.WriteLine("Do you wish to search by\n1) Status\n2) Priority\n3) Submitter");
                    string searchType = Console.ReadLine();
                    if (searchType == "1")
                    {
                        Console.WriteLine("Enter the status you wish to search for:");
                        string input = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        var searchStatus1 = defectFile.Defects.Where(d => d.status.Contains(input));
                        Console.WriteLine($"There are {searchStatus1.Count()} defects with a matching status:");
                        foreach(Defect t in searchStatus1)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.severity}");
                        }

                        var searchStatus2 = enhancementFile.Enhancements.Where(e => e.status.Contains(input));
                        Console.WriteLine($"There are {searchStatus2.Count()} enhancements with a matching status:");
                        foreach(Enhancement t in searchStatus2)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.software}, {t.cost}, {t.reason}, {t.estimate}");
                        }

                        var searchStatus3 = taskFile.Task.Where(t => t.status.Contains(input));
                        Console.WriteLine($"There are {searchStatus3.Count()} tasks with a matching status:");
                        foreach(Task t in searchStatus3)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.projectName}, {t.dueDate}");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }else if (searchType == "2")
                    {
                        Console.WriteLine("Enter the priority you wish to search for:");
                        string input = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        var searchPriority1 = defectFile.Defects.Where(d => d.priority.Contains(input));
                        Console.WriteLine($"There are {searchPriority1.Count()} defects with a matching priority:");
                        foreach(Defect t in searchPriority1)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.severity}");
                        }

                        var searchPriority2 = enhancementFile.Enhancements.Where(e => e.priority.Contains(input));
                        Console.WriteLine($"There are {searchPriority2.Count()} enhancements with a matching priority:");
                        foreach(Enhancement t in searchPriority2)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.software}, {t.cost}, {t.reason}, {t.estimate}");
                        }

                        var searchPriority3 = taskFile.Task.Where(t => t.priority.Contains(input));
                        Console.WriteLine($"There are {searchPriority3.Count()} tasks with a matching priority:");
                        foreach(Task t in searchPriority3)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.projectName}, {t.dueDate}");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }else if (searchType == "3")
                    {
                        Console.WriteLine("Enter the submitter you wish to search for:");
                        string input = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        var searchSubmitter1 = defectFile.Defects.Where(d => d.submitter.Contains(input));
                        Console.WriteLine($"There are {searchSubmitter1.Count()} defects with a matching submitter:");
                        foreach(Defect t in searchSubmitter1)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.severity}");
                        }

                        var searchSubmitter2 = enhancementFile.Enhancements.Where(e => e.submitter.Contains(input));
                        Console.WriteLine($"There are {searchSubmitter2.Count()} enhancements with a matching submitter:");
                        foreach(Enhancement t in searchSubmitter2)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.software}, {t.cost}, {t.reason}, {t.estimate}");
                        }

                        var searchSubmitter3 = taskFile.Task.Where(t => t.submitter.Contains(input));
                        Console.WriteLine($"There are {searchSubmitter3.Count()} tasks with a matching submitter:");
                        foreach(Task t in searchSubmitter3)
                        {
                            Console.WriteLine($"{t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}, {t.watching}, {t.projectName}, {t.dueDate}");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                }
            } while (choice == "1" || choice == "2" || choice == "3");
        }
    }
}
