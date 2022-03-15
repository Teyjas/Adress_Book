namespace AddressBookSystem;

/// <summary>
/// This class keeps collection of Address books
/// </summary>
internal class AddressBookLibrary
{
    private readonly Dictionary<string, AddressBook> library;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddressBookLibrary"/> class.
    /// </summary>
    public AddressBookLibrary()
    {
        library = new Dictionary<string, AddressBook>();
    }

    /// <summary>
    /// Adds an address book to the library.
    /// </summary>
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

    /// <summary>
    /// Opens an existing AddressBook with menu option to interact with it
    /// </summary>
    public void OpenAddressBook()
    {
        string name = UserInput.GetName("Enter Name of AddressBook: ");
        if (library.ContainsKey(name))
            AddressBookMenu.List(name, library[name]);
        else
            Console.WriteLine("Addressbook with that name does not exist");
    }

    /// <summary>
    /// Display all Address Books in the library
    /// </summary>
    public void Display()
    {
        Console.WriteLine("List of Address Books:");
        foreach (var name in library.Keys)
            Console.WriteLine(name);
    }
}