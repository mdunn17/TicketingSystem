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
            string ticketFilePath = Directory.GetCurrentDirectory() + "ticketingSystem.txt";
            string choice;
            logger.Info("Program started");

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
                     if (File.Exists(ticketFile))
                    {
                        /*StreamReader sr = new StreamReader(ticketFile);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                        sr.Close();
                        */
                        foreach(Ticket t in ticketFile.Tickets)
                        {
                            Console.WriteLine(t.Display());
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    /*StreamWriter sw = new StreamWriter(ticketFile);
                    string resp;
                     do
                    {
                        int i = 1;
                        Console.WriteLine("Would you like to make a ticket? (Y/N)?");
                        resp = Console.ReadLine().ToUpper();

                        if (resp != "Y") { break; }

                        Console.WriteLine("Enter the ticket summary.");
                        string summary = Console.ReadLine();

                        Console.WriteLine("Enter the ticket status.");
                        string status = Console.ReadLine();

                        Console.WriteLine("Enter the ticket priority.");
                        string priority = Console.ReadLine();

                        Console.WriteLine("Enter the ticket submitter name.");
                        string submitter = Console.ReadLine();

                        Console.WriteLine("Enter the name of the employee assigned to this ticket.");
                        string assigned = Console.ReadLine();

                        Console.WriteLine("Enter who is watching this ticket, seperated by a |.");
                        string watching = Console.ReadLine();

                        sw.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", i, summary, status, priority, submitter, assigned, watching);
                        i++;
                    }
                    while (resp == "Y");
                    sw.Close();
                    */
                    
                    Ticketing ticket = new Ticket();
                    Console.WriteLine("Enter the ticket summary.");
                    ticket.summary = Console.ReadLine();

                    Console.WriteLine("Enter the ticket status.");
                    ticket.status = Console.ReadLine();

                    Console.WriteLine("Enter the ticket priority.");
                    ticket.priority = Console.ReadLine();

                    Console.WriteLine("Enter the ticket submitter name.");
                    ticket.submitter = Console.ReadLine();

                    Console.WriteLine("Enter the name of the employee assigned to this ticket.");
                    ticket.assigned = Console.ReadLine();

                    Console.WriteLine("Enter who is watching this ticket, seperated by a |.");
                    ticket.watching = Console.ReadLine();

                    //sw.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", i, summary, status, priority, submitter, assigned, watching);
                    //i++;

                }
            } while (choice == "1" || choice == "2");
        }
    }
}
