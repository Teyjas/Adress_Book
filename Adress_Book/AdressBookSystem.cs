using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookSystem;


internal class AddressBook
{
    // class attributes
    private List<Contact> contacts;


    // Default constructor
    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    // Create new contact
    public void CreateContact()
    {
        contacts.Add(new Contact());
    }

    public void Display()
    {
        foreach (Contact contact in contacts)
            contact.Display();
    }
}