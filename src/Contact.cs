using System;

namespace src;

public class Contact : IComparable<Contact>
{
    private string fName;
    private string lName;
    private string phoneNum;
    private string address;
    private int zipCode;
    private string email;

    //  Constructor for Contact object
    public Contact(string fName, string lName, string phoneNum, string address, int zipCode, string email)
    {
        this.fName = fName;
        this.lName = lName;
        this.phoneNum = phoneNum;
        this.address = address;
        this.zipCode = zipCode;
        this.email = email;
    }

    //  Constuctor for a comparison Contact object for the compareTo method
    public Contact(string fName, string lName, string phoneNum)
    {
        this.fName = fName;
        this.lName = lName;
        this.phoneNum = phoneNum;
    }



     /*  overrides compareTo method from Comparable class
      *  Checks, letter by letter, if two first names in Contact objects are the same 
      *  If they are the same, and both first names still have a letters, try again
      *  If one first name has less characters than the other or the names have a differing character, return a value
      *  If both first names have the same amount of the same letters, call the lNameCompare method
     */
    public int CompareTo(Contact inputName)
    {
        string chars = "abcdefghijklmnopqrstuvwxyz";
        bool fNameEnd = false;
        bool inputFNameEnd = false;
        int charCounter = 1;
        int fNameIndex;
        int inputFNameIndex;

        //  grabs value of first letter of both first names
        fNameIndex = chars.IndexOf(this.fName.ToLower().ToCharArray()[0]);
        inputFNameIndex = chars.IndexOf(inputName.fName.ToLower().ToCharArray()[0]);

        // checks if first letters in both first names are the same
        if (inputFNameIndex > fNameIndex)
        {
            return 1;
        } else if (inputFNameIndex < fNameIndex)
        {
            return -1;
        }

        // runs through every letter in both names until there is a differing character, a name ends, or both names have the same amount of same letters.
        while (true)
        {
            //  grabs next character, if there are no new characters to grab the first name has ended
            try
            {
                fNameIndex = chars.IndexOf(this.fName.ToLower().ToCharArray()[charCounter]);
            }
            catch (IndexOutOfRangeException e)
            {
                fNameEnd = true;
            }

            //  grabs next character, if there are no new characters to grab the last name has ended
            try
            {
                inputFNameIndex = chars.IndexOf(inputName.fName.ToLower().ToCharArray()[charCounter]);
            }
            catch (IndexOutOfRangeException e)
            {
                inputFNameEnd = true;
            }

            //  checks if either of the names have ended and then checks if the individual characters are the same
            //  if both first names are the same, call lNameCompare method
            if (fNameEnd && inputFNameEnd)
            {
                return lNameCompare(inputName);
            }
            else if (inputFNameEnd)
            {
                return 1;
            }
            else if (fNameEnd)
            {
                return -1;
            }
            else
            {
                if (inputFNameIndex > fNameIndex)
                {
                    return 1;
                }
                else if (inputFNameIndex < fNameIndex)
                {
                    return -1;
                }
            }
            charCounter++;
        }
    }

    /*  Checks, letter by letter, if two last names in Contact objects are the same 
     *  If they are the same, and both last names still have a letters, try again
     *  If one last name has less characters than the other or the names have a differing character, return a value
     *  If both  lastnames have the same amount of the same letters, return a value of 0
    */
    private int lNameCompare(Contact inputName)
    {
        string chars = "abcdefghijklmnopqrstuvwxyz";
        bool lNameEnd = false;
        bool inputLNameEnd = false;
        int charCounter = 1;
        int lNameIndex;
        int inputLNameIndex;

        //  grabs value of first letter of both first names
        lNameIndex = chars.IndexOf(this.lName.ToLower().ToCharArray()[0]);
        inputLNameIndex = chars.IndexOf(inputName.lName.ToLower().ToCharArray()[0]);

        // checks if first letters in both first names are the same
        if (inputLNameIndex > lNameIndex)
        {
            return 1;
        }
        else if (inputLNameIndex < lNameIndex)
        {
            return -1;
        }

        // runs through every letter in both names until there is a differing character, a name ends, or both names have the same amount of same letters.
        while (true)
        {
            //  grabs next character, if there are no new characters to grab the first name has ended
            try
            {
                lNameIndex = chars.IndexOf(this.lName.ToLower().ToCharArray()[charCounter]);
            }
            catch (IndexOutOfRangeException e)
            {
                lNameEnd = true;
            }

            //  grabs next character, if there are no new characters to grab the last name has ended
            try
            {
                inputLNameIndex = chars.IndexOf(inputName.lName.ToLower().ToCharArray()[charCounter]);
            }
            catch (IndexOutOfRangeException e)
            {
                inputLNameEnd = true;
            }

            //  checks if either of the names have ended and then checks if the individual characters are the sam
            //  if both last names are the same, return a 0 value
            if (lNameEnd && inputLNameEnd)
            {
                return 0;
            }
            else if (inputLNameEnd)
            {
                return 1;
            }
            else if (lNameEnd)
            {
                return -1;
            }
            else
            {
                if (inputLNameIndex > lNameIndex)
                {
                    return 1;
                }
                else if (inputLNameIndex < lNameIndex)
                {
                    return -1;
                }
            }
            charCounter++;
        }
    }

    /*  overrides equals method
     *  checks if both objects are the same object and if so, return true
     *  checks if inputted object is a Contact object and if so
     *  checks if both objects contain the same first name, last name, and phonenumber
     */
    public bool equals(Contact obj)
    {
        if (this == obj)
        {
            return true;
        }
        //  checks if object is of type Contact and if so
        //  checks if first name, last name, and phone numbers between the two objects are the same
        if (obj.GetType() == typeof(Contact))
        {
            Contact trueObj = (Contact)obj;
            if (this.fName == trueObj.fName && this.lName == trueObj.lName && this.phoneNum == trueObj.phoneNum && this.address == trueObj.address && this.zipCode == trueObj.zipCode && this.email == trueObj.email)
            {
                return true;
            }
        }
        return false;
    }

    //  overrides toString method
    //  prints out all data within Contact object
    public String toString()
    {
        return String.Format("\"Name: %s %s, Email: %s, Phone: %s, Address: %s, Zip: %d\"", fName, lName, email, phoneNum, address, zipCode);
    }
}