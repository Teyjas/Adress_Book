
using AddressBookSystem;

Console.Title = "AddressBook System";
Console.WriteLine("----------AddressBook System----------");

AddressBook myContacts = new();
myContacts.CreateContact();
myContacts.Display();

Console.ReadKey();