namespace AddressBookSystem;

// This class keeps collection of Address books
internal class AddressBookLibrary
{
    private readonly Dictionary<string, AddressBook> library;

    // Default Constructor
    public AddressBookLibrary()
    {
        library = new Dictionary<string, AddressBook>();
    }

    // Adds new AddressBook to library
    public void AddAddressBook()
    {
        string name = UserInput.GetName("Enter Name of AddressBook: ");
        if (library.ContainsKey(name) is false && String.IsNullOrEmpty(name) is false)
        {
            library.Add(name, new AddressBook());
            Console.WriteLine("AddressBook Added Successfully");
        }
        else if (String.IsNullOrEmpty(name))
            Console.WriteLine("Invalid name");
        else
            Console.WriteLine("AddressBook with that name already exists");
    }

    // Opens an existing AddressBook with menu option to interact with it
    public void OpenAddressBook()
    {
        string name = UserInput.GetName("Enter Name of AddressBook: ");
        if (library.ContainsKey(name))
            AddressBookMenu.List(name, library[name]);
        else
            Console.WriteLine("Addressbook with that name does not exist");
    }

    // Display all Address Books in the library
    public void Display()
    {
        Console.WriteLine("List of Address Books:");
        foreach (var name in library.Keys)
            Console.WriteLine(name);
    }
}
