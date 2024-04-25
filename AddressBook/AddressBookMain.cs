using AddressBook;
using System;
using System.ComponentModel.Design;
using System.Data;

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

        public List<Contact> GetContacts() { return ContactList; }

        public Contact GetContact(int id) { return ContactList[id]; }

        public void UpdateContact()
        {
            Console.WriteLine("Enter Name : ");
            string? name = Console.ReadLine();

            if (this.ContactList.Count() != 0)
            {
                var result = from item in this.ContactList
                             where item.FirstName.Equals(name)
                             select item;

                if (result.Any())
                {
                    foreach (var i in result)
                    {
                        Console.WriteLine("Record Found : " + i.FirstName);
                        i.AcceptContactRecord();
                    }
                }
                else
                {
                    Console.WriteLine("No Record Found!!!");
                }
            }
            else
            {
                Console.WriteLine("List is Empty!!!");
            }
        }

        public void DeleteContact()
        {
            if (this.ContactList.Count() != 0)
            {
                Console.WriteLine("Enter Name : ");
                string? name = Console.ReadLine();

                var result = from item in this.ContactList
                             where item.FirstName.Equals(name)
                             select item;

                if (result.Any())
                {
                    foreach (var i in result)
                    {
                        Console.WriteLine("Record Found : " + i.FirstName);
                        if (this.ContactList.Remove(i))
                        {
                            Console.WriteLine("Record Deleted Successfully!!!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error!!! While deleting record.!!!");
                        }

                        if (i == null)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Record Found!!!");
                }
            }
            else
            {
                Console.WriteLine("List is Empty!!!");
            }
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
            int choice = 0;
            AddressBookMain addressBook = new();
            addressBook.ContactList = new List<Contact>();

            while ((choice = MenuDriven()) != 0)
            {
                switch (choice)
                {

                    case 1:
                        Console.WriteLine("Add Record\n--------------");

                        Contact contact = new();
                        contact.AcceptContactRecord();
                        addressBook.ContactList.Add(contact);
                        break;

                    case 2:
                        Console.WriteLine("Display Record\n--------------");

                        foreach (var item in addressBook.ContactList)
                        {
                            item.DisplayContactRecord();
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
        }
    }
}