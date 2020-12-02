using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;
using Microsoft.Azure.KeyVault.Models;

namespace PhoneBookAppProject
{
    public class DapperContactInfo : IContactInfo
    {
        private readonly IDbConnection _connection;

        public DapperContactInfo(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Contacts> GetAllContacts()
        {
            return _connection.Query<Contacts>("SELECT * FROM contactinfo;");
        }
        public void CreateContact(string newFirstName, string newLastName, string newPhoneNum, string newEmail, string newCityState, string newBirthDate)
        {
            //how do I make some of these for each method optional?
            _connection.Execute("INSERT INTO contactinfo (FirstName, LastName, PhoneNumber, EmailAddress, CityAndState, BirthDate) " +
                "VALUES (@firstName, @lastNane, @phoneNumber, @email, @cityState, @birthDate);",
                new { firstName = newFirstName, lastName = newLastName, phoneNumber = newPhoneNum, email = newEmail, 
                      cityState = newCityState, birthDate = newBirthDate });
        }
        public void UpdateContact(string newFirstName, string newLastName, string newPhoneNum, string newEmail, string newCityState, string newBirthDate)
        {
            //same as comment above but how can I make all go based off idcontactInfo
            _connection.Execute("UPDATE contactinfo SET FirstName = @changeFName WHERE idcontactInfo = @id;",
                new { changeFName = newFirstName, id = });
        }
        public void DeleteContact(int contactID)
        {
            _connection.Execute("DELETE FROM contactinfo WHERE idcontactInfo = @id;",
                new { id = contactID });
        }
    }
}
