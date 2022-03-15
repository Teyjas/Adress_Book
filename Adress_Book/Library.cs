namespace AddressBookSystem;

/// <summary>
/// This class handles the menu for Address books library
/// </summary>
internal class LibraryMenu
{
    /// <summary>
    /// Lists the menu options for the library of Address Books.
    /// </summary>
    public static void List()
    {
        int option;
        AddressBookLibrary mylibrary = new();
        do
        {
            Console.Clear();
            Console.WriteLine("-------------Address Books Library-------------");
            Console.WriteLine("Choose from following:\n");
            Console.WriteLine("1. Create New Address Book");
            Console.WriteLine("2. Open an AddressBook");
            Console.WriteLine("3. Display all Address Books in library");
            Console.WriteLine("4. Filter contact list by city/state");
            Console.WriteLine("5. Search and filter by location");
            Console.WriteLine("6. Get location wise count of contacts");
            Console.WriteLine("7. Exit");
            option = UserInput.GetPositiveInt("Enter option(1-7): ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    mylibrary.AddAddressBook();
                    break;
                case 2:
                    mylibrary.OpenAddressBook();
                    break;
                case 3:
                    mylibrary.Display();
                    break;
                case 4:
                    mylibrary.DisplayFilteredList();
                    break;
                case 5:
                    mylibrary.SearchAndFilter();
                    break;
                case 6:
                    mylibrary.DisplayCountByLocation();
                    break;
                case 7:
                    Console.WriteLine("Exiting Application...");
                    break;
                default:
                    Console.WriteLine("Invalid Option!!!");
                    break;
            }
            if (option == 7)
                break;
            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
        } while (option != 7);
    }
}