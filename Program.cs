using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading;

namespace PhoneBookAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            //Console.WriteLine(connString);
            #endregion

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperContactInfo(conn);

            Console.WriteLine("Welcome to your very own wonderful phone book!"); //put some image here?
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("What would you like to do? Please choose an option: 1 - 5");
            Console.WriteLine();
            Thread.Sleep(500);

            Console.WriteLine("1 - Create a contact");
            Console.WriteLine("2 - Read all contacts");
            Console.WriteLine("3 - Update a contact");
            Console.WriteLine("4 - Delete a contact");
            Console.WriteLine("5 - End Application");

            int userInput = int.Parse(Console.ReadLine());

            //This is where they create contact but how can I have them skip certain ones.. or exit the program whenever they want?
            //should some of these default to something? or be required?
            //First and last should start with first letter capital but first name MUST be required. last name can be null?
            //phone number should include two dashes and if not entered - default to null
            //email address should include @(email service).com and if not entered - defaults to - null
            //address city and state - city needs to start with a capital and must have a comma separating it and state in caps - then null
            //bday must be in this format - 01/02/0123 - then null
            
            //Create a contact - DONE
            if(userInput == 1)
            {
                Console.WriteLine("Please enter the contacts first name:");
                string userFirst = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Please enter their last name:");
                string userLast = Console.ReadLine();
                Console.WriteLine();
                
                Console.WriteLine("Please enter their telephone number - ex: 123-123-1234");
                string userPhone = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Please enter their email address:");
                string userEmail = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Please enter their City and State - ex: Seattle, WA");
                string userAddress = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Please enter their date of birth - ex: dd/mm/yyyy");
                string userBday = Console.ReadLine();
                Console.WriteLine();

                repo.CreateContact(userFirst, userLast, userPhone, userEmail, userAddress, userBday);
            }

            //Display all contacts - DONE
            var contacts = repo.GetAllContacts();

            if (userInput == 2)
            {
                Console.WriteLine();
                foreach (var c in contacts)
                {
                    Console.WriteLine($"{c.idcontactInfo}  {c.FirstName}  {c.LastName}  {c.PhoneNumber}  {c.EmailAddress}  {c.CityAndState}  {c.BirthDate}");
                    Console.WriteLine();
                }
            }

            //Update existing contact



            //Delete a contact - DONE
            if (userInput == 4)
            {
                foreach (var c in contacts)
                {
                    Console.WriteLine("First, please see below list of contacts:");
                    Console.WriteLine($"{c.idcontactInfo}  {c.FirstName}  {c.LastName}  {c.PhoneNumber}  {c.EmailAddress}  {c.CityAndState}  {c.BirthDate}");
                    Console.WriteLine();
                }
                Console.WriteLine("You are sure you still want to delete?");
                string answer = Console.ReadLine();
                if (answer == "yes".ToLower())
                {
                    Console.WriteLine("Please provide ID of the contact you would like to remove:");
                    int contactID = int.Parse(Console.ReadLine());
                    repo.DeleteContact(contactID);
                    Console.WriteLine(contactID);
                }
                else if (answer == "no".ToLower())
                {
                    Console.WriteLine();
                    Console.WriteLine("Have a nice day");
                }
                else
                {
                    Console.WriteLine("Only yes or no are allowed");
                    //this forces the user to have to pick yes or no
                }
            }

            //Terminate program (supposedly they need to do it whenever they want and not just at option 5)
        }
    }
}
