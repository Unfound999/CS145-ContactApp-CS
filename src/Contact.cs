using System;

using System;

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



    // override
    public int CompareTo(Contact obj)
    {
        string chars = "abcdefghijklmnopqrstuvwxyz";
        bool fNameEnd = false;
        bool inputFNameEnd = false;
        int charCounter = 1;
        int fNameIndex;
        int inputFNameIndex;

        return 0;
    }
}
