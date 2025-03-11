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

    public Contact(string fName, string lName, string phoneNum, string address, int zipCode, string email)
    {
        this.fName = fName;
        this.lName = lName;
        this.phoneNum = phoneNum;
        this.address = address;
        this.zipCode = zipCode;
        this.email = email;
    }

    public Contact(string fName, string lName, string phoneNum)
    {
        this.fName = fName;
        this.lName = lName;
        this.phoneNum = phoneNum;
    }



    //  override
    public int CompareTo(Contact inputName)
    {
        string chars = "abcdefghijklmnopqrstuvwxyz";
        bool fNameEnd = false;
        bool inputFNameEnd = false;
        int charCounter = 1;
        int fNameIndex;
        int inputFNameIndex;

        fNameIndex = chars.IndexOf(this.fName.ToLower().ToCharArray()[0]);
        inputFNameIndex = chars.IndexOf(inputName.fName.ToLower().ToCharArray()[0]);

        if (inputFNameIndex > fNameIndex)
        {
            return 1;
        } else if (inputFNameIndex < fNameIndex)
        {
            return -1;
        }

        while (true)
        {
            try
            {
                fNameIndex = chars.IndexOf(this.fName.ToLower().ToCharArray()[charCounter]);
            }
            catch (IndexOutOfRangeException e)
            {
                fNameEnd = true;
            }

            try
            {
                inputFNameIndex = chars.IndexOf(inputName.fName.ToLower().ToCharArray()[charCounter]);
            }
            catch (IndexOutOfRangeException e)
            {
                inputFNameEnd = true;
            }

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

    private int lNameCompare(Contact inputName)
    {
        string chars = "abcdefghijklmnopqrstuvwxyz";
        bool lNameEnd = false;
        bool inputLNameEnd = false;
        int charCounter = 1;
        int lNameIndex;
        int inputLNameIndex;

        lNameIndex = chars.IndexOf(this.lName.ToLower().ToCharArray()[0]);
        inputLNameIndex = chars.IndexOf(inputName.lName.ToLower().ToCharArray()[0]);

        if (inputLNameIndex > lNameIndex)
        {
            return 1;
        }
        else if (inputLNameIndex < lNameIndex)
        {
            return -1;
        }

        while (true)
        {
            try
            {
                lNameIndex = chars.IndexOf(this.lName.ToLower().ToCharArray()[charCounter]);
            }
            catch (IndexOutOfRangeException e)
            {
                lNameEnd = true;
            }

            try
            {
                inputLNameIndex = chars.IndexOf(inputName.lName.ToLower().ToCharArray()[charCounter]);
            }
            catch (IndexOutOfRangeException e)
            {
                inputLNameEnd = true;
            }

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

    //  override
    public bool equals(Contact obj)
    {
        if (this == obj)
        {
            return true;
        }
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

    //  override
    public String toString()
    {
        return String.Format("\"Name: %s %s, Email: %s, Phone: %s, Address: %s, Zip: %d\"", fName, lName, email, phoneNum, address, zipCode);
    }
}