
using AddressBookSystem;

Console.Title = "AddressBook System";
Console.WriteLine("----------AddressBook System----------");

// Creating Contact via AddressBook
Console.WriteLine("Creating new Contact in AddressBook");
AddressBook myContacts = new();
myContacts.CreateContact();
myContacts.Display();

// Adding Contact to AddressBook
Console.WriteLine("Adding new Contact in AddressBook");
Contact contact = new Contact("Teyjas", "+919513040209");
myContacts.AddContact(contact);
myContacts.Display();

Console.ReadKey();