namespace AddressBookSystem;

/// <summary>
/// This class handles the menu for address book
/// </summary>
internal static class AddressBookMenu
{
    /// <summary>
    /// Lists the menu option for an Address Book.
    /// </summary>
    /// <param name="addressBookName">Name of the address book.</param>
    /// <param name="addressBook">The object of AddressBook</param>
    public static void List(string addressBookName, AddressBook addressBook)
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("-------------Address Book: " + addressBookName + "-------------");
            Console.WriteLine("Choose from following:\n");
            Console.WriteLine("1. Create and add contact");
            Console.WriteLine("2. Add multiple contacts");
            Console.WriteLine("3. Edit a contact");
            Console.WriteLine("4. Delete a contact");
            Console.WriteLine("5. Look up a contact");
            Console.WriteLine("6. Display Address Book");
            Console.WriteLine("7. Filter contact list by city/state");
            Console.WriteLine("8. Display no of contacts by location");
            Console.WriteLine("9. Exit to library");
            option = UserInput.GetPositiveInt("Enter option(1-9): ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    addressBook.CreateContact();
                    break;
                case 2:
                    addressBook.AddMultipleContacts();
                    break;
                case 3:
                    addressBook.EditContact();
                    break;
                case 4:
                    addressBook.DeleteContact();
                    break;
                case 5:
                    Console.Write("Enter name of contact to look up: ");
                    string fullname = Console.ReadLine();
                    addressBook.LookUp(fullname);
                    break;
                case 6:
                    addressBook.Display();
                    break;
                case 7:
                    addressBook.DisplayFilteredList();
                    break;
                case 8:
                    addressBook.DisplayCountByLocation();
                    break;
                case 9:
                    Console.WriteLine("Exiting to library...");
                    break;
                default:
                    Console.WriteLine("Invalid Option!!!");
                    break;
            }
            if (option == 9)
                break;
            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
        } while (option != 9);
    }
}