using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookSystem;


internal class Contact
{
    private string firstName;
    private string lastName;
    private string email;
    private string phone;
    private string city;
    private string state;
    private string zip;
    private string address;

    // Default Constructor
    public Contact()
    {
        GetContactInfo();
    }

    // Parameterised Constructor: Takes necessary info in parameters
    public Contact(string firstName, string phone)
    {
        this.firstName = firstName;
        this.phone = phone;
    }

    // Gets contact info from user
    private void GetContactInfo()
    {
        firstName = GetString("First name: ");
        Console.Write("Last Name: ");
        lastName = Console.ReadLine();
        Console.Write("Email: ");
        email = Console.ReadLine();
        phone = GetNumber("Phone: ");
        Console.Write("City: ");
        city = Console.ReadLine();
        Console.Write("State: ");
        state = Console.ReadLine();
        zip = GetZip("Zip: ");
        Console.Write("Address: ");
        address = Console.ReadLine();
    }

    // Ensures the input is non-null string
    private static string GetString(string message)
    {
        string input;
        do
        {
            Console.Write(message);
            input = Console.ReadLine();
        } while (input == null);
        return input;
    }

    // Ensures the input matches phone patterns
    private static string GetNumber(string message)
    {
        string input;
        do
        {
            Console.Write(message);
            input = Console.ReadLine();
        } while (PhoneCheck(input) is false);
        return input;
    }

    // Ensures the input matches zipcode patterns
    private static string GetZip(string message)
    {
        string input;
        do
        {
            Console.Write(message);
            input = Console.ReadLine();
        } while (ZipCheck(input) is false);
        return input;
    }

    // Checks if input matches zip pattern
    private static bool ZipCheck(string input)
    {
        string zipPattern = @"(^[0-9]{6}$)";
        Regex number = new Regex(zipPattern);
        Match match = number.Match(input);
        if (match.Success || String.IsNullOrEmpty(input))
            return true;
        return false;
    }

    // Checks if input matches phone pattern
    private static bool PhoneCheck(string input)
    {
        string phonePattern = @"(^[0-9]{10}$)|(^\+{1}[0-9]{2}[0-9]{10}$)|(^[0-9]{3}[-]{0,1}[0-9]{8}$)";
        Regex number = new Regex(phonePattern);
        Match match = number.Match(input);
        if (match.Success)
            return true;
        return false;
    }

    // Displays full contact 
    public void Display()
    {
        Console.WriteLine("Name: " + firstName + " " + lastName);
        Console.WriteLine("Email: " + email);
        Console.WriteLine("Phone: " + phone);
        Console.WriteLine("City: " + city);
        Console.WriteLine("State: " + state);
        Console.WriteLine("Zip: " + zip);
        Console.WriteLine("Address: " + address);
    }
}
