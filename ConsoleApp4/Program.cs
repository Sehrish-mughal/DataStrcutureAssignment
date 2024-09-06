using System.Text.RegularExpressions;

class Program
{
    static LinkedList<LinkedList<string>> Contacts = new LinkedList<LinkedList<string>>();
    static Dictionary<string, string> relationshipOptions = new Dictionary<string, string>
        {
            { "1", "Friend" },
            { "2", "Sister" },
            { "3", "Brother" }
        };
    static void Main()
    {
        addData();
       

        while (true)
        {
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Search");
            Console.WriteLine("3 - Display");
            Console.WriteLine("4 - Exit");
            Console.Write("Choose an option: ");
            int option = int.Parse(Console.ReadLine());

            

            if (option == 1)
            {
                addContacts();
            }
            else if (option == 2)
            {
                searchData();
            }
            else if (option == 3)
            {
                displayData();
            }
            else if (option == 4)
            {
                exitProgram();
                break;
            }
            else
            {
                Console.WriteLine("Write Option 1 or 2 or 3 or 4\n");
            }
        }

        
       
    }

    static void addContacts()
    {
        var personal_3 = new LinkedList<string>();
        string choice;
        //FirstName Input Field
        string firstName;
        do
        {
            Console.Write("Write FirstName :");
            firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("FirstName cannot be blank.");
            }
            else if (firstName.StartsWith(" ") || firstName.EndsWith(" ") || firstName.Contains("  "))
            {
                Console.WriteLine("FirstName cannot contain spaces.");
            }
            else if (!IsValidName(firstName))
            {
                Console.WriteLine("This field can only contains Alphabetic characters and must start with a letter");
            }


        } while (string.IsNullOrWhiteSpace(firstName) || !IsValidName(firstName));
        personal_3.AddLast(firstName);


        //LastName Input Field
        string lastName;
        do
        {
            Console.Write("Write LastName :");
            lastName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("LastName cannot be blank.");
            }
            else if (lastName.Contains(" "))
            {
                Console.WriteLine("LastName cannot contain spaces.");
            }
            else if (!IsValidName(lastName))
            {
                Console.WriteLine("This field can only contains Alphabetic characters and must start with a letter");
            }


        } while (string.IsNullOrWhiteSpace(lastName) || !IsValidName(lastName));
        personal_3.AddLast(lastName);

        if (IsNameExist(Contacts, firstName, lastName))
        {
            Console.WriteLine("This Contact Already Exist.");
            lastName = null;
            //continue;
        }




        //Contact Input Field
        string phone;
        do
        {
            Console.Write("Write Contact :");
            phone = Console.ReadLine();

            if (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("Contact Field Cannot Be Empty.");

            }
            else if (phone.Contains(" "))
            {
                Console.WriteLine("Contact cannot contain spaces.");
            }
            else if (!IsValidNumber(phone))
            {
                Console.WriteLine("Contact Can Only be Numbers.");
            }
        } while (string.IsNullOrEmpty(phone) || !IsValidNumber(phone));

        personal_3.AddLast(phone);

        //Relationship Input Field
        Console.Write("Write Relationship :");
        Console.WriteLine("Select Relationship:");
        foreach (var pair in relationshipOptions)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value}");
        }

        int relationshipOption = int.Parse(Console.ReadLine());
        string selectedRelationship;


        switch (relationshipOption)
        {
            case 1:
                selectedRelationship = "Friend";
                break;
            case 2:
                selectedRelationship = "Sister";
                break;
            case 3:
                selectedRelationship = "Brother";
                break;
            default:
                Console.WriteLine("Invalid option selected, defaulting to 'Friend'.");
                selectedRelationship = "Friend";
                break;
        }

        personal_3.AddLast(selectedRelationship);

        //Email Input Field
        string email;
        do
        {
            Console.Write("Write Email: ");
            email = Console.ReadLine();

            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email Field Cannot Be Empty.");
            }
            else if (email.Contains(" "))
            {
                Console.WriteLine("Email cannot contain spaces.");
            }
            else if (!isValidemail(email))
            {
                Console.WriteLine("Invalid email format. Please enter a valid email address.");
            }
        } while (string.IsNullOrEmpty(email) || !isValidemail(email));
        personal_3.AddLast(email);

        //Marks Input Field
        string marks;
        do
        {
            Console.Write("Write Marks: ");
            marks = Console.ReadLine();
            if (!int.TryParse(marks, out _) || string.IsNullOrWhiteSpace(marks))
            {
                Console.WriteLine("Marks must be a valid integer and cannot be blank.");
            }
            else if (marks.Contains(" "))
            {
                Console.WriteLine("Marks cannot contain spaces.");
            }
        } while (!int.TryParse(marks, out _) || string.IsNullOrWhiteSpace(marks));

        personal_3.AddLast(marks);

        //Adding personal_3 LinkedList to main LinkedList(Contacts)

        Contacts.AddLast(personal_3);

        Console.WriteLine("Do you want to add Cotacts? (yes/no)");
        choice = Console.ReadLine();

        Console.WriteLine();
    }
    static void displayData()
    {
        Console.WriteLine("-----------------------------------Display Information---------------------------------------------------------------");
        Console.WriteLine(" ");

        Console.WriteLine("FirstName\tLastName\tContact\t\tRelationship\t\tEmail\t\t\tMarks");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

        foreach (var item in Contacts)
        {
            foreach (var c in item)
            {
                Console.Write(c + "\t\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine(" ");
    }
    static void addData()
    {
        var personal_1 = new LinkedList<string>();
        personal_1.AddLast("Sehrish");
        personal_1.AddLast("Mughal");
        personal_1.AddLast("0333-5162536");
        personal_1.AddLast("Sister");
        personal_1.AddLast("sehrish@gmail.com");
        personal_1.AddLast("100");

        var personal_2 = new LinkedList<string>();
        personal_2.AddLast("Beenish");
        personal_2.AddLast("Mughal");
        personal_2.AddLast("0333-9988776");
        personal_2.AddLast("Colleague");
        personal_2.AddLast("beenish@gmail.com");
        personal_2.AddLast("67");


        Contacts.AddLast(personal_1);
        Contacts.AddLast(personal_2);

    }

    static void searchData()
    {
        Console.WriteLine("1 - FirstName");
        Console.WriteLine("2 - LastName");
        Console.WriteLine("3 - Contact");
        Console.WriteLine("4 - Relationship");
        Console.WriteLine("5 - Email");
        Console.WriteLine("6 - Marks");
        Console.WriteLine(" ");
        Console.WriteLine("Chose an option: ");
        int searchOption = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the search term: ");
        string searchTerm = Console.ReadLine();

        int searchFieldIndex;
        switch (searchOption)
        {
            case 1:
                searchFieldIndex = 0; //firstname
                break;
            case 2:
                searchFieldIndex = 1; //lastname
                break;
            case 3:
                searchFieldIndex = 2; //contact
                break;
            case 4:
                searchFieldIndex = 3; //relationship
                break;
            case 5:
                searchFieldIndex = 4; //email
                break;
            case 6:
                searchFieldIndex = 5; //marks
                break;
            default:
                Console.WriteLine("Invalid Option!");
                return;

        }


        Console.WriteLine("FirstName\tLastName\tContact\t\tRelationship\t\tEmail\t\t\tMarks");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

        bool found = false;

        foreach (var items in Contacts)
        {
            string item = items.ElementAt(searchFieldIndex).ToString();


            if (item.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                found = true;
                Console.WriteLine(string.Join("\t\t", items));
            }
        }


        if (!found)
        {
            Console.WriteLine("No matching records found.\n");
        }
        else
        {
            Console.WriteLine();
        }
    }

    static void exitProgram()
    {

        Console.WriteLine("Exiting the program...");
        
    }

    static bool isValidemail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
        catch (Exception)
        {
            return false;
        }
    }
    static bool IsValidName(string name)
    {
        return Regex.IsMatch(name, @"^[A-Za-z][A-Za-z\s\-]*$");
    }
    static bool IsValidNumber(string phone)
    {
        return Regex.IsMatch(phone, @"^\d{4}-\d{7}$");
    }

    static bool IsNameExist(LinkedList<LinkedList<string>> Contacts, string name, string lname)
    {
        foreach (var items in Contacts)
        {
            var firstNameInLoop = items.ElementAt(0);
            var lastNameInLoop = items.ElementAt(1);

            if (firstNameInLoop.Equals(name, StringComparison.OrdinalIgnoreCase) && lastNameInLoop.Equals(lname, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

        }
        return false;
    }
}

