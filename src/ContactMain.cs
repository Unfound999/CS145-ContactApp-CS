using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace src;

class ContactMain
{
    //Main method uses a menu to handle each option for adding, viewing, removing, viewing all, and quitting. This is done through
    //a switch case inside of a do while loop.
    static void Main(string[] args)
    {
        BinarySearchTree<Contact> Tree = new BinarySearchTree<Contact>();
        bool running = true;
        do
        {
            Console.Write("Please enter which option you would like!:");
            Console.Write("Options include: \n\"AC\" to add a contact\n\"VC\" to view a contact\n\"RC\" to remove a contact\n\"VAC\" to view all contacts\n\"Q\" to quit!.");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "AC": AddContactMain(Tree); break;
                case "VC": ViewContact(Tree); break;
                case "RC": RemoveContact(Tree); break;
                case "VAC": ViewAllContacts(Tree); break;
                case "Q": running = false; break;
                default: Console.WriteLine("This is not a valid option!"); break;
            }
        } while (running);
    }

    //AddContactMain is a method that asks the user for key information for a contact. Then it creates a contact object with
    //all provided data and then adds that contact object to the tree with the add method.
    public static void AddContactMain(BinarySearchTree<Contact> Tree)
    {

        Console.Write("Please provide the first name of the contact:");
        string fName = Console.ReadLine();

        Console.Write("Please provide the last name of the contact:");
        string lName = Console.ReadLine();

        Console.Write("Please provide the email of the contact:");
        string email = Console.ReadLine();

        int zip;
        while (true)
            try
            {
                Console.Write("Please provide the zip code of the contact:");
                zip = Int32.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException e)
            {
                Console.Write("Sorry this is an invalid zip code!");
            }

        Console.Write("Please provide the phone number of the contact:");
        string pNum = Console.ReadLine();

        Console.Write("Please provide the address of the contact:");
        string address = Console.ReadLine();

        Contact person = new Contact(address, email, fName, lName, pNum, zip);

        try
        {
            Tree.Add(person);
            Console.Write("Contact Added!");
        }
        catch (DuplicateNodeException e)
        {
            Console.WriteLine("That contact already exists.");
        }
    }

    //ViewContact is a method that asks a person for identifying information about a person. Then it instantiates a contact object
    //with that info and it Gets that person using the tree class with the Get method. Lastly it shows the person to the user.
    public static void ViewContact(BinarySearchTree<Contact> Tree)
    {
        Console.Write("Please provide the first name of the contact:");
        string fName = Console.ReadLine();

        Console.Write("Please provide the last name of the contact:");
        string lName = Console.ReadLine();

        Console.Write("Please provide the phone number of the contact:");
        string pNum = Console.ReadLine();

        Contact person = new Contact(fName, lName, pNum);
        try
        {
            person = Tree.Get(person);
            Console.WriteLine(person);
        }
        catch (NodeNotFoundException e)
        {
            Console.WriteLine("That person doesn't exist");
        }
    }

    //removeContact is a method that asks the user for identifying information and then uses that information to create a
    //contact object. That contact object is then used to remove the person using the tree class with the remove method.
    public static void RemoveContact(BinarySearchTree<Contact> Tree)
    {
        Console.Write("Please provide the first name of the contact:");
        string fName = Console.ReadLine();

        Console.Write("Please provide the last name of the contact:");
        string lName = Console.ReadLine();

        Console.Write("Please provide the phone number of the contact:");
        string pNum = Console.ReadLine();

        Contact person = new Contact(fName, lName, pNum);
        try
        {
            Tree.Remove(person);
            Console.Write("Contact removed!");
        }
        catch (NodeNotFoundException e)
        {
            Console.WriteLine("That person doesn't exist");
        }
    }

    //ViewAllContacts is a method that creates a arraylist through the GetAllInOrder method, then it loops through a for loop which
    //prints out the every contacts information in the arraylist.
    public static void ViewAllContacts(BinarySearchTree<Contact> Tree)
    {

        List<Contact> allPeople = Tree.GetAllInOrder();

        foreach (Contact person in allPeople)
        {
            Console.WriteLine(person);
        }
    }
}

