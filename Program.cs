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
            string ticketFilePath = Directory.GetCurrentDirectory() + "\\ticketingSystem.txt";
            string choice = "";
            

            TicketFile ticketFile = new TicketFile(ticketFilePath);
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

                if (choice == "1")
                {
                    
                    foreach(Ticket t in ticketFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                    }
                    
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Please select Ticket Type:\n1 - Bug/Defect\n2 - Enhancement\n3 - Task");
                    string type = Console.ReadLine();

                    if(type == "1")
                    {
                        Ticket ticket = new Defect();

                        Console.WriteLine("Enter the ticket summary:");
                        ticket.summary = Console.ReadLine();

                        Console.WriteLine("Enter the ticket status:");
                        ticket.status = Console.ReadLine();

                        Console.WriteLine("Enter the ticket priority:");
                        ticket.priority = Console.ReadLine();

                        Console.WriteLine("Enter the ticket submitter name:");
                        ticket.submitter = Console.ReadLine();

                        Console.WriteLine("Enter the name of the employee assigned to this ticket:");
                        ticket.assigned = Console.ReadLine();

                        Console.WriteLine("Enter who is watching this ticket (seperate names by a comma):");
                        ticket.watching = Console.ReadLine();

                        Console.WriteLine("Enter the severity of this defect:");
                        ticket.severity = Console.ReadLine();

                        ticketFile.AddTicket(ticket);
                    }
                    else if(type == "2")
                    {
                        Ticket ticket = new Enhancement();

                        Console.WriteLine("Enter the ticket summary:");
                        ticket.summary = Console.ReadLine();

                        Console.WriteLine("Enter the ticket status:");
                        ticket.status = Console.ReadLine();

                        Console.WriteLine("Enter the ticket priority:");
                        ticket.priority = Console.ReadLine();

                        Console.WriteLine("Enter the ticket submitter name:");
                        ticket.submitter = Console.ReadLine();

                        Console.WriteLine("Enter the name of the employee assigned to this ticket:");
                        ticket.assigned = Console.ReadLine();

                        Console.WriteLine("Enter who is watching this ticket (seperate names by a comma):");
                        ticket.watching = Console.ReadLine();

                        Console.WriteLine("Enter the software for this enhancement:");
                        ticket.software = Console.ReadLine();

                        Console.WriteLine("Enter the Cost for this enhancement:");
                        ticket.cost = Console.ReadLine();

                        Console.WriteLine("Enter the reason for this enhacement:");
                        ticket.reason = Console.ReadLine();

                        Console.WriteLine("Enter the estimate for this enhancement:");
                        ticket.estimate = Console.ReadLine();

                        ticketFile.AddTicket(ticket);
                    }
                    else if(type == "3")
                    {
                        Ticket ticket = new Task();

                        Console.WriteLine("Enter the ticket summary:");
                        ticket.summary = Console.ReadLine();

                        Console.WriteLine("Enter the ticket status:");
                        ticket.status = Console.ReadLine();

                        Console.WriteLine("Enter the ticket priority:");
                        ticket.priority = Console.ReadLine();

                        Console.WriteLine("Enter the ticket submitter name:");
                        ticket.submitter = Console.ReadLine();

                        Console.WriteLine("Enter the name of the employee assigned to this ticket:");
                        ticket.assigned = Console.ReadLine();

                        Console.WriteLine("Enter who is watching this ticket (seperate names by a comma):");
                        ticket.watching = Console.ReadLine();

                        Console.WriteLine("Enter the project name for this task:");
                        ticket.projectName = Console.ReadLine();

                        Console.WriteLine("Enter the due date for this task:");
                        Console.WriteLine("Day:");
                        string day = Console.ReadLine();
                        Console.WriteLine("Month:");
                        string month = Console.ReadLine();
                        Console.WriteLine("Year:");
                        string year = Console.ReadLine();

                        ticket.dueDate = (day,month,year);

                        ticketFile.AddTicket(ticket);
                    }

                }
            } while (choice == "1" || choice == "2");
        }
    }
}
