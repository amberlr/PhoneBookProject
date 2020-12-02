using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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

            var contactInfo = repo.GetAllContacts();

            Console.WriteLine("Welcome to your very own wonderful phone book!");
            Console.ReadLine();
            Console.WriteLine("What would you like to do?");

            //how can I do this so they choose an option?
            List<string> options = new List<string>();
            options.Add("1 - Create a contact");
            options.Add("2 - Read all contacts");
            options.Add("3 - Update a contact");
            options.Add("4 - Delete a contact");
            options.Add("5 - End Application");

            //This is where they create contact but how can I have them skip certain ones.. or exit the program whenever they want?
            Console.WriteLine("Please enter the contacts first name:");
            string userFirst = Console.ReadLine();

            Console.ReadLine();

            Console.WriteLine("Please enter their last name:");
            string userLast = Console.ReadLine();
            Console.ReadLine();

            Console.WriteLine("Please enter their telephone number:");
            string userPhone = Console.ReadLine();
            Console.ReadLine();

            Console.WriteLine("Please enter their email address:");
            string userEmail = Console.ReadLine();
            Console.ReadLine();

            Console.WriteLine("Please enter their City and State - ex: City, State");
            string userAddress = Console.ReadLine();
            Console.ReadLine();

            Console.WriteLine("Please enter their date of birth - ex: dd/mm/yyyy");
            string userBday = Console.ReadLine();
            Console.ReadLine();

            repo.CreateContact(userFirst, userLast, userPhone, userEmail, userAddress, userBday);

            //Display all contacts


            //Update existing contact


            //Delete a contact


            //Terminate program (supposedly they need to do it whenever they want and not just at option 5)
        }
    }
}
