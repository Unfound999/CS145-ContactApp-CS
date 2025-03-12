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
    public static void main(string[] args)
    {
        Scanner input = new Scanner(System.in);
        BinarySearchTree<Contact> Tree = new BinarySearchTree<>();
        boolean running = true;
        do
        {
            Console.Write("Please enter which option you would like!:");
            Console.Write("Options include: \"AC\" to add a contact, \"VC\" to view a contact \"RC\" to remove a contact, \"VAC\" to view all contacts, or \"Q\" to quit!.");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "AC": addContactMain(Tree); break;
                case "VC": viewContact(Tree); break;
                case "RC": removeContact(Tree); break;
                case "VAC": viewAllContacts(Tree); break;
                case "Q": running = false; break;
                default: Console.WriteLine("This is not a valid option!"); break;
            }
        } while (running);
    }

    //addContactMain is a method that asks the user for key information for a contact. Then it creates a contact object with
    //all provided data and then adds that contact object to the tree with the add method.
    public static void addContactMain(BinarySearchTree<Contact> Tree)
    {
        Scanner input = new Scanner(System.in);

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
                zip = input.nextInt();
                break;
            }
            catch (InputMismatchException e)
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
            Tree.add(person);
            Console.Write("Contact Added!");
        }
        catch (DuplicateNodeException e)
        {
            Console.WriteLine("That contact already exists.");
        }
    }

    //ViewContact is a method that asks a person for identifying information about a person. Then it instantiates a contact object
    //with that info and it Gets that person using the tree class with the Get method. Lastly it shows the person to the user.
    public static void viewContact(BinarySearchTree<Contact> Tree)
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

    //viewAllContacts is a method that creates a arraylist through the GetAllInOrder method, then it loops through a for loop which
    //prints out the every contacts information in the arraylist.
    public static void viewAllContacts(BinarySearchTree<Contact> Tree)
    {

        List<Contact> allPeople = Tree.GetAllInOrder();

        foreach (Contact person in allPeople)
        {
            Console.WriteLine(person);
        }
    }
}

