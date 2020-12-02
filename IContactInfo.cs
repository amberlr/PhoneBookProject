using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookAppProject
{
    public interface IContactInfo
    {
        IEnumerable<Contacts> GetAllContacts();
        void CreateContact(string newFirstName, string newLastName, string newPhoneNum, string newEmail, string newCityState, string newBirthDate);
        //read?
        void UpdateContact(string newFirstName, string newLastName, string newPhoneNum, string newEmail, string newCityState, string newBirthDate);
        void DeleteContact(int contactID);
    }
}
