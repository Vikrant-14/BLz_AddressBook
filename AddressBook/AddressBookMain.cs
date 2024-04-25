using AddressBook;
using System;
using System.ComponentModel.Design;

namespace Assignment3
{
    class AddressBookMain
    {
        List<Contact>? ContactList { get; set; }

        static AddressBookMain()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("================================\n");
        }

        public static int MenuDriven()
        {
            int choice;
            try
            {
                Console.WriteLine("0. Enter Zero to Exit the Application.");
                Console.WriteLine("1. Enter One to Add Record.");
                Console.WriteLine("2. Enter Two To Display Record.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid Input : Enter number only");
            }

            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }
        public static void Main()
        {
            int choice = 0;
            AddressBookMain addressBook = new AddressBookMain();
            addressBook.ContactList = new List<Contact>();

            while ((choice = MenuDriven()) != 0)
            {
                switch (choice)
                {

                    case 1:
                        Console.WriteLine("Add Record\n--------------");

                        Contact contact = new Contact();
                        contact.AcceptContactRecord();
                        addressBook.ContactList.Add(contact);
                        break;
                    case 2:
                        foreach (var item in addressBook.ContactList)
                        {
                            item.DisplayContactRecord();
                        }
                        break;
                }
            }
        }
    }
}