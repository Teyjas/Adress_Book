namespace AddressBookSystem;


internal static class Menu
{
    public static void List()
    {
        int option;
        AddressBook myContacts = new();

        do
        {
            Console.Clear();
            Console.WriteLine("-------------Address Book System-------------");
            Console.WriteLine("Choose from following:\n");
            Console.WriteLine("1. Create and add contact");
            Console.WriteLine("2. Edit a contact");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Display Address Book");
            Console.WriteLine("5. Exit");
            option = UserInput.GetPositiveInt("Enter option(1-11): ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    myContacts.CreateContact();
                    break;
                case 2:
                    myContacts.EditContact();
                    break;
                case 3:
                    myContacts.DeleteContact();
                    break;
                case 4:
                    myContacts.Display();
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid Option!!!");
                    break;
            }
            if (option == 5)
                break;
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        } while (option != 5);
    }
}
