namespace AddressBookSystem;

/// <summary>
/// This Class handles all contacts in an address book
/// </summary>
public class AddressBook
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

    /// <summary>
    /// Look up the contact details of the specified name
    /// </summary>
    public void LookUp(string fullName)
    {
        if (addresses.ContainsKey(fullName))
            addresses[fullName].Display();
        else
            Console.WriteLine("Contact does not exist");
    }

    /// <summary>
    /// Display filtered results based on location
    /// </summary>
    public void DisplayFilteredList()
    {
        List<Contact> filteredList = LocationFilter();
        foreach (Contact contact in filteredList)
            contact.Display();
    }

    /// <summary>
    /// filter by Location
    /// </summary>
    /// <returns>A list of contacts</returns>
    public List<Contact> LocationFilter()
    {
        int option = 0;
        MatchLocation Match;
        List<Contact> filteredList = new List<Contact>();
        Console.WriteLine("Filter Contact list in full library of AddressBooks:");
        Console.WriteLine("1. Filter by state");
        Console.WriteLine("2. Filter by city");
        Console.Write("Option: ");
        while (option != 1 && option != 2)
            while (int.TryParse(Console.ReadLine(), out option) is false)
                Console.WriteLine("Input must be Integer only");
        if (option == 1)
        {
            Match = new MatchLocation((contact, state) => { return contact.State == state; });
            Console.Write("Enter state: ");
        }
        else
        {
            Match = new MatchLocation((contact, city) => { return contact.City == city; });
            Console.WriteLine("Enter City: ");
        }
        string location = Console.ReadLine();
        FilterList(location, filteredList, Match);
        return filteredList;
    }

    /// <summary>
    /// Filters the list.
    /// </summary>
    /// <param name="location">The location.</param>
    /// <param name="filterList">The filter list.</param>
    /// <param name="Match">The match delegate</param>
    public void FilterList(string location, List<Contact> filterList, MatchLocation Match)
    {
        foreach (Contact contact in addresses.Values)
            if (Match(contact, location))
                filterList.Add(contact);
    }

    /// <summary>
    /// Displays the count of contacts by location.
    /// </summary>
    public void DisplayCountByLocation()
    {
        Console.WriteLine("Count of contacts at the library level:");
        var cityWiseCount = GetLocationCount(contact => { return contact.City; }, DelegatesList.CityMatch);
        var stateWiseCount = GetLocationCount(contact => { return contact.State; }, DelegatesList.StateMatch);
        Console.WriteLine("\nCity wise count: ");
        foreach (var city in cityWiseCount)
            Console.WriteLine($"City: {city.Key}, No of contacts: {city.Value}");
        Console.WriteLine("\nState wise count: ");
        foreach (var state in stateWiseCount)
            Console.WriteLine($"State: {state.Key}, No of contacts: {state.Value}");
    }

    /// <summary>
    /// Gets the location count.
    /// </summary>
    /// <param name="Selector">The selector.</param>
    /// <param name="Match">The match.</param>
    /// <returns>returns location wise count as dictionary</returns>
    public Dictionary<string, int> GetLocationCount(GetLocation Selector, MatchLocation Match)
    {
        Dictionary<string, int> counts = new();
        var locationList = addresses.Values.Select(x => Selector(x)).Distinct().ToList();
        foreach (var location in locationList)
            counts.Add(location, addresses.Values.Count(contact => Match(contact, location)));
        return counts;
    }

    /// <summary>
    /// Menu option for sorting the contact list
    /// </summary>
    public void SortOptions()
    {
        int option = 0;
        Console.WriteLine("Sorting Options:");
        Console.WriteLine("1. Sort by Name");
        Console.WriteLine("2. Sort by City");
        Console.WriteLine("3. Sort by State");
        Console.WriteLine("4. Sort by Zip");
        Console.Write("Option: ");
        if (int.TryParse(Console.ReadLine(), out option))
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Sorting by Name\n");
                    Sort(x => x.Value.FullName);
                    break;
                case 2:
                    Console.WriteLine("Sorting by City\n");
                    Sort(x => x.Value.City);
                    break;
                case 3:
                    Console.WriteLine("Sorting by State\n");
                    Sort(x => x.Value.State);
                    break;
                case 4:
                    Console.WriteLine("Sorting by Zip\n");
                    Sort(x => x.Value.Zip);
                    break;
                default:
                    Console.WriteLine("Option must be in (1-4)!!!");
                    break;
            }
        }
        else
            Console.WriteLine("Invalid option!");
    }

    /// <summary>
    /// Sorts the contact list using the specified sort condition.
    /// </summary>
    /// <param name="sortCondition">The sort condition.</param>
    private void Sort(Func<KeyValuePair<string, Contact>, string> sortCondition)
    {
        Console.WriteLine("Sorted List:");
        var sorted = addresses.OrderBy(sortCondition);
        foreach (var contact in sorted)
            Console.WriteLine("\n" + contact.Value);
    }
}