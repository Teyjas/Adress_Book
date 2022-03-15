namespace AddressBookSystem;

public delegate string GetLocation(Contact contact);
public delegate bool MatchLocation(Contact contact, string location);
/// <summary>
/// This class keeps collection of Address books
/// </summary>
public class AddressBookLibrary
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

    /// <summary>
    /// Displays the filtered list.
    /// </summary>
    public void DisplayFilteredList()
    {
        List<Contact> filteredList = LocationFilter();
        foreach (Contact contact in filteredList)
            contact.Display();
    }

    /// <summary>
    /// Filter results based on location
    /// </summary>
    public List<Contact> LocationFilter()
    {
        int option = 0;
        MatchLocation Match;
        List<Contact> filteredList = new();
        Console.WriteLine("Filter Contact list in full library of AddressBooks:");
        Console.WriteLine("1. Filter by state");
        Console.WriteLine("2. Filter by city");
        Console.Write("Option: ");
        while (option != 1 && option != 2)
            while (int.TryParse(Console.ReadLine(), out option) is false)
                Console.WriteLine("Input must be Integer only");
        if (option == 1)
        {
            Match = DelegatesList.StateMatch;
            Console.Write("Enter state: ");
        }
        else
        {
            Match = DelegatesList.CityMatch;
            Console.WriteLine("Enter City: ");
        }
        string location = Console.ReadLine();
        FilterList(location, filteredList, Match);
        return filteredList;
    }

    /// <summary>
    /// Filters the list.
    /// </summary>
    /// <param name="location">The location</param>
    /// <param name="filterList">The filter list.</param>
    /// <param name="Match">The match condition</param>
    public void FilterList(string location, List<Contact> filterList, MatchLocation Match)
    {
        foreach (AddressBook book in library.Values)
            book.FilterList(location, filterList, Match);
    }

    /// <summary>
    /// Searches in the filtered list
    /// </summary>
    public void SearchAndFilter()
    {
        Console.Write("Enter name of person to search: ");
        string fullName = Console.ReadLine();
        List<Contact> filteredList = LocationFilter();
        var searchResults = filteredList.FindAll(contact => contact.FullName == fullName);
        Console.WriteLine("Filtered Search Results: ");
        foreach (Contact contact in searchResults)
            contact.Display();
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
    /// <param name="Selector">The selector condition</param>
    /// <param name="Match">The match condition</param>
    /// <returns>Location wise count as dictonary</returns>
    public Dictionary<string, int> GetLocationCount(GetLocation Selector, MatchLocation Match)
    {
        Dictionary<string, int> locationCounts = new();
        var locationWiseCountCollection = library.Values.Select(x => x.GetLocationCount(Selector, Match)).ToList();
        foreach (var locationWiseCount in locationWiseCountCollection)
            foreach (var location in locationWiseCount)
                if (locationCounts.ContainsKey(location.Key))
                    locationCounts[location.Key] += location.Value;
                else
                    locationCounts.Add(location.Key, location.Value);
        return locationCounts;
    }
}

public static class DelegatesList
{
    public static readonly MatchLocation StateMatch = new((contact, state) => { return contact.State == state; });
    public static readonly MatchLocation CityMatch = new((contact, city) => { return contact.City == city; });
}