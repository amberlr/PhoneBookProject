using System;
using System.Collections.Generic;
using System.Text;


namespace PhoneBookAppProject
{
    public class ContactInfo
    {
        public ContactInfo()
        {

        }
        public int idcontactInfo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CityAndState { get; set; }
        public string BirthDate { get; set; }
    }
}
