using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookSystem;

/// <summary>
/// This Class handles all contacts in an address book
/// </summary>
internal class AddressBook
{
    // Dictionary for storing contacts with unique name
    public readonly Dictionary<string, Contact> addresses;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddressBook"/> class.
    /// </summary>
    public AddressBook()
    {
        addresses = new Dictionary<string, Contact>();
    }

    /// <summary>
    /// Creates a new contact
    /// </summary>
    public void CreateContact()
    {
        AddContact(new Contact());
    }

    /// <summary>
    /// Adds the contact to the AddressBook
    /// </summary>
    /// <param name="contact">The Contact object.</param>
    public void AddContact(Contact contact)
    {
        string name = contact.FullName;
        if (name == null)
        {
            Console.WriteLine("Invalid Contact name");
            return;
        }
        if (addresses.Any(e => e.Value.Equals(contact)) is false)
        {
            addresses.Add(name, contact);
            Console.WriteLine("Contact Added Successfully");
        }
        else
            Console.WriteLine("Contact name already exists");
    }

    /// <summary>
    /// Adds multiple contacts
    /// </summary>
    public void AddMultipleContacts()
    {
        int numberOfContacts = UserInput.GetPositiveInt("Enter no of Contacts to add: ");
        for (int i = 0; i < numberOfContacts; i++)
            CreateContact();
    }

    /// <summary>
    /// Edits a contact in AddressBook.
    /// </summary>
    public void EditContact()
    {
        Console.Write("Enter Name of contact to edit: ");
        string name = UserInput.ReadString();
        if (addresses.ContainsKey(name))
        {
            Console.WriteLine("\nCurrent info of " + name);
            addresses[name].Display();
            Console.WriteLine("\nEdit info: ");
            Contact contact = new();
            string newName = contact.FullName;
            if (addresses.ContainsKey(newName) is false || newName == name)
            {
                addresses.Remove(name);
                addresses[newName] = contact;
                Console.WriteLine("Updated!!");
            }
            else
                Console.WriteLine("Contact name already exists. Failed to update changes");
        }
        else
            Console.WriteLine("The contact does not exist");
    }

    /// <summary>
    /// Deletes a contact from AddressBook.
    /// </summary>
    public void DeleteContact()
    {
        Console.Write("Enter Name of contact to delete: ");
        string name = UserInput.ReadString();
        if (addresses.ContainsKey(name))
        {
            addresses.Remove(name);
            Console.WriteLine("Contact removed");
        }
        else
            Console.WriteLine("Contact does not exist");
    }

    /// <summary>
    /// Displays the full list of contacts in the AddressBook.
    /// </summary>
    public void Display()
    {
        Console.WriteLine("List of Contacts:");
        foreach (var name in addresses.Keys)
            addresses[name].Display();
    }

    public void LookUp(string fullName)
    {
        if (addresses.ContainsKey(fullName))
            addresses[fullName].Display();
        else
            Console.WriteLine("Contact does not exist");
    }

    /// <summary>
    /// Filter results based on location
    /// </summary>
    public void DisplayFilteredList()
    {
        int option = 0;
        List<Contact> filterredList = new List<Contact>();
        Console.WriteLine("Filter Contact list in this AddressBook:");
        Console.WriteLine("1. Filter by state");
        Console.WriteLine("2. Filter by city");
        Console.Write("Option: ");
        do
        {
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Input must be Integer only");
            }
        } while (option != 1 && option != 2);
        switch (option)
        {
            case 1:
                Console.Write("Enter state: ");
                string state = Console.ReadLine();
                Console.WriteLine($"List of contacts in {state}");
                StateFilter(state, filterredList);
                break;
            case 2:
                Console.WriteLine("Enter City: ");
                string city = Console.ReadLine();
                Console.WriteLine($"List of contacts in {city}");
                CityFilter(city, filterredList);
                break;
            default:
                Console.WriteLine("Error!!!");
                break;
        }
    }

    /// <summary>
    /// Filter results by city
    /// </summary>
    public void CityFilter(string city, List<Contact> filteredList)
    {
        Dictionary<string, Contact>.Enumerator enumerator = addresses.GetEnumerator();
        while (enumerator.MoveNext())
            if (enumerator.Current.Value.City == city)
                filteredList.Add(enumerator.Current.Value);
    }

    /// <summary>
    /// Filter results by state
    /// </summary>
    public void StateFilter(string state, List<Contact> filteredList)
    {
        Dictionary<string, Contact>.Enumerator enumerator = addresses.GetEnumerator();
        while (enumerator.MoveNext())
            if (enumerator.Current.Value.State == state)
                filteredList.Add(enumerator.Current.Value);
    }
}