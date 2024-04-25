using Assignment3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {
        Dictionary<string, AddressBookMain> AddressBookList;
        static Program()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("================================\n");
        }

        public static int UserInput()
        {
            int choice = 0;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("0. Enter Zero to Exit the Application.");
            Console.WriteLine("1. Enter One to Add New AddressBook.");
            Console.WriteLine("--------------------------------------");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input : Enter number only!!!");
            }

            return choice;

        }

        public static int MenuDriven()
        {
            int choice = 0;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("0. Enter Zero to Exit the Application.");
            Console.WriteLine("1. Enter One to Add Record.");
            Console.WriteLine("2. Enter Two To Display Record.");
            Console.WriteLine("3. Update Exisiting Record");
            Console.WriteLine("4. Delete Record");
            Console.WriteLine("--------------------------------------");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input : Enter number only!!!");
            }

            return choice;
        }
        public static void Main()
        {
            Program p1 = new Program();

            int choice = 0;
            int choice1 = 0;

            AddressBookMain addressBook = new();
            p1.AddressBookList = new Dictionary<string, AddressBookMain>();

            while ((choice1 = UserInput()) != 0)
            {
                switch (choice1)
                {
                    case 1:
                        Console.WriteLine("Add Address Book\n--------------");

                        //addressBook.AddAddressBook();
                        Console.WriteLine("Enter the Name of the Name of Address Book : ");
                        addressBook.AddressBookName = Console.ReadLine();

                        if (p1.AddressBookList.ContainsKey(addressBook.AddressBookName))
                        {
                            Console.WriteLine($"An element with Key = {addressBook.AddressBookName} already exists.\"");
                            break;
                        }

                        addressBook.ContactList = new Dictionary<string, Contact>();

                        while ((choice = MenuDriven()) != 0)
                        {
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Add Record\n--------------");

                                    Contact contact = new();
                                    contact.AcceptContactRecord();


                                    if (!addressBook.ContactList.ContainsKey(contact.FirstName))
                                    {
                                        try
                                        {
                                            addressBook.ContactList.Add(contact.FirstName, contact);
                                        }
                                        catch (ArgumentException)
                                        {
                                            Console.WriteLine($"An element with Key = {contact.FirstName} already exists.");
                                        }
                                    }



                                    p1.AddressBookList.Add(addressBook.AddressBookName, addressBook);


                                    break;

                                case 2:
                                    Console.WriteLine("Display Record\n--------------");

                                    foreach (var item in addressBook.ContactList)
                                    {
                                        item.Value.DisplayContactRecord();
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Update Record\n--------------");

                                    addressBook.UpdateContact();
                                    break;

                                case 4:
                                    Console.WriteLine("Delete Record\n--------------");

                                    addressBook.DeleteContact();
                                    break;
                            }
                        }


                        break;
                }
            }
        }
    }
}