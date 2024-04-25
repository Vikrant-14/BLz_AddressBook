using AddressBook;
using System;
using System.ComponentModel.Design;
using System.Data;

namespace Assignment3
{
    class AddressBookMain
    {
        public string? AddressBookName;
        public Dictionary<string, Contact>? ContactList { get; set; }

        public Dictionary<string, Contact> GetContacts() { return ContactList; }

        //public Contact GetContact() { return ContactList.Values; }

        public void UpdateContact()
        {
            Console.WriteLine("Enter Name : ");
            string? name = Console.ReadLine();

            if (this.ContactList.Count() != 0)
            {
                var result = from item in this.ContactList
                             where item.Value.FirstName.Equals(name)
                             select item;

                if (result.Any())
                {
                    foreach (var i in result)
                    {
                        Console.WriteLine("Record Found : " + i.Value.FirstName);
                        i.Value.AcceptContactRecord();
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
                             where item.Value.FirstName.Equals(name)
                             select item;

                if (result.Any())
                {
                    foreach (var i in result)
                    {
                        Console.WriteLine("Record Found : " + i.Value.FirstName);
                        if (this.ContactList.Remove(i.Key))
                        {
                            Console.WriteLine("Record Deleted Successfully!!!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error!!! While deleting record.!!!");
                        }

                        if (i.Key == null)
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



    }
}