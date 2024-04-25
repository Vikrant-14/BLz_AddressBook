using AddressBook;
using System;

namespace Assignment3
{
    class AddressBookMain
    {
        List<Contact>? ContactList;

        static AddressBookMain()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("================================\n");
        }

        public static void Main()
        {
            Contact contact1 = new Contact();
            contact1.AcceptContactRecord();
            contact1.DisplayContactRecord();
        }
    }
}