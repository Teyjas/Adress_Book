using System.Text.RegularExpressions;

namespace AddressBookSystem;

/// <summary>
/// This class is used for input checks when entering contact info
/// </summary>
internal static class UserInput
{
    /// <summary>
    /// Reads the string.
    /// <para>To avoid null reference assignment warning</para>
    /// </summary>
    /// <returns></returns>
    public static string ReadString()
    {
        string input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
            return "";
        return input;
    }

    /// <summary>
    /// Gets a name.
    /// <para>Ensures the input is non-null string</para>
    /// </summary>
    /// <param name="message">The message to display to user.</param>
    /// <returns>The name entered by user</returns>
    public static string GetName(string message)
    {
        string input;
        do
        {
            Console.Write(message);
            input = ReadString();
        } while (input == null);
        return input;
    }

    /// <summary>
    /// Gets a number.
    /// <para>Ensures the input matches phone patterns</para>
    /// </summary>
    /// <param name="message">The message to display to user.</param>
    /// <returns>The number entered by user</returns>
    public static string GetNumber(string message)
    {
        string input;
        do
        {
            Console.Write(message);
            input = ReadString();
        } while (PhoneCheck(input) is false && input != "");
        return input;
    }

    /// <summary>
    /// Gets the zip.
    /// <para>Ensures the input matches zipcode patterns</para>
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns>The zip code entered by user</returns>
    public static string GetZip(string message)
    {
        string input;
        do
        {
            Console.Write(message);
            input = ReadString();
        } while (ZipCheck(input) is false);
        return input;
    }

    /// <summary>
    /// Gets the positive int.
    /// <para>Ensures user input is positve integer</para>
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns>An integer >= 0</returns>
    public static int GetPositiveInt(string message)
    {
        int n;
        string input;
        bool IS_INT32;
        do
        {
            do
            {
                Console.Write(message);
                input = ReadString();
                IS_INT32 = Int32.TryParse(input, out n);
            } while (IS_INT32 is false);
        } while (n < 0);
        return n;
    }

    /// <summary>
    /// Phones the check.
    /// <para>Checks if input matches phone pattern</para>
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>true if a match. Else false</returns>
    public static bool PhoneCheck(string input)
    {
        string phonePattern = @"(^[0-9]{10}$)|(^\+{1}[0-9]{2}[0-9]{10}$)|(^[0-9]{3}[-]{0,1}[0-9]{8}$)";
        Regex number = new(phonePattern);
        Match match = number.Match(input);
        if (match.Success)
            return true;
        return false;
    }

    /// <summary>
    /// Zips the check.
    /// <para>Checks if input matches zip pattern</para>
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>true if a match. Else false</returns>
    public static bool ZipCheck(string input)
    {
        string zipPattern = @"(^[0-9]{6}$)";
        Regex number = new(zipPattern);
        Match match = number.Match(input);
        if (match.Success || String.IsNullOrEmpty(input))
            return true;
        return false;
    }
}