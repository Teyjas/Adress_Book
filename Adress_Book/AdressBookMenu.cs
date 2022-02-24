namespace AddressBookSystem;

// This class handles the menu for address book
internal static class AddressBookMenu
{
    public static void List(string addressBookName, AddressBook addressBook)
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("-------------Address Book: " + addressBookName + "-------------");
            Console.WriteLine("Choose from following:\n");
            Console.WriteLine("1. Create and add contact");
            Console.WriteLine("2. Edit a contact");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Display Address Book");
            Console.WriteLine("5. Exit to library");
            option = UserInput.GetPositiveInt("Enter option(1-5): ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    addressBook.CreateContact();
                    break;
                case 2:
                    addressBook.EditContact();
                    break;
                case 3:
                    addressBook.DeleteContact();
                    break;
                case 4:
                    addressBook.Display();
                    break;
                case 5:
                    Console.WriteLine("Exiting to library...");
                    break;
                default:
                    Console.WriteLine("Invalid Option!!!");
                    break;
            }
            if (option == 5)
                break;
            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
        } while (option != 5);
    }
}
