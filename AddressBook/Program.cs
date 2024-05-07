using Assignment3;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {
        Dictionary<string, AddressBookMain>? AddressBookList;

        List<Contact> contacts;
        Dictionary<string, List<Contact>>? CityList; 

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
            Console.WriteLine("1. Enter One to Add New Address Book.");
            Console.WriteLine("2. Enter Two to Display Address Books.");
            Console.WriteLine("3. Enter Three to Search Person by City or State.");
            Console.WriteLine("4. Enter Four to Count number of people in City or State.");
            Console.WriteLine("5. Enter Five to Sort By Name.");
            Console.WriteLine("6. Enter Six to Sort By City.");
            Console.WriteLine("7. Enter Seven to Sort By State.");
            Console.WriteLine("8. Enter Eight to Sort By Zip Code.");
            //Console.WriteLine("9. Enter Nine to Sort By Option.");
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

        public void DisplayAddressBookDetails()
        {
            if (this.AddressBookList.Count == 0)
            {
                Console.WriteLine("Address Book is Empty.");
            }
            else
            {
                foreach (var item in this.AddressBookList)
                {
                    Console.WriteLine("Address Book Name : " + item.Key);
                    foreach (var i in item.Value.ContactList)
                    {
                        i.Value.DisplayContactRecord();
                    }
                }
            }
        }


        public void CheckCSV()
        {
            string filePath = "C:\\Users\\kirti\\Vikrant\\CDAC\\BridgeLabz_Assign\\Address Book\\data2.csv";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read the CSV file
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false, // Indicates that the file has a header row
                }))
                {
                    // Skip the header row
                    csv.Read();

                    // Process data rows
                    while (csv.Read())
                    {
                        IEnumerable<Contact> fields = csv.GetRecords<Contact>();


                        foreach (var field in fields)
                        {
                            field.DisplayContactRecord(); // Trim whitespace
                        }
                        Console.WriteLine(fields.Count());
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }

        //Reading State from CSV
        public void ReadStateFromCsv()
        {
           

                string filePath = "C:\\Users\\kirti\\Vikrant\\CDAC\\BridgeLabz_Assign\\Address Book\\data2.csv";

                using(var reader = new StreamReader(filePath))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture);
                    using (var csv =new CsvReader(reader,config))
                    {
                        
                        csv.Read();
                        csv.ReadHeader();

                        //while (csv.Read())
                        //{
                        //    var con = csv.GetRecord<Contact>();
                        //    Console.WriteLine(con.ToString());
                        //}

                        config.HasHeaderRecord = true; // Assuming CSV has a header row

                        // Read a single record from the CSV file and map it to a Contact object
                        Contact contact = csv.GetRecord<Contact>();

                        // Do something with the contact object
                        if (contact != null)
                        {
                            Console.WriteLine($"First Name: {contact.FirstName}, Last Name: {contact.LastName}");
                        }
                        else
                        {
                            Console.WriteLine("No more records.");
                        }

                        //csv.Context.RegisterClassMap<ContactMap>();

                        ////var contacts = csv.GetRecord<Contact>();
                        //IEnumerable<Contact> records = csv.GetRecords<Contact>();

                        //foreach (var i in records)
                        //{
                        //    Console.WriteLine(i.ToString());
                        //}
                    }
                }

                //var config = new CsvConfiguration(CultureInfo.InvariantCulture);

                //using (var reader = new StreamReader(filePath))
                //using (var csv = new CsvReader(reader, config))
                //{
                //    // Configure CsvReader to use the header names from the CSV file
                //    config.HasHeaderRecord = true;

                //    // Read the records
                //    IEnumerable<Contact> records = csv.GetRecords<Contact>();

                //    // Process the records
                //    foreach (var record in records)
                //    {
                //        // Do something with each record
                //        //Console.WriteLine($"First Name: {record.FirstName}, Last Name: {record.LastName}");
                //        record.DisplayContactRecord();
                //    }
                //}

                //using (var reader = new CsvReader(File.OpenText(filePath), CultureInfo.InvariantCulture))
                //{
                //    reader.Configuration.HasHeaderRecord = false;

                //    reader.Context.RegisterClassMap<ContactMap>();

                //    IEnumerable<Contact> records = reader.GetRecords<Contact>();
                //    foreach (var i in records)
                //    {
                //        i.ToString();
                //    }
                //}

           
        }

        //Writing data into CSV file
        public void SaveStateInCsv()
        {
            try
            {
                string filePath = "C:\\Users\\kirti\\Vikrant\\CDAC\\BridgeLabz_Assign\\Address Book\\data2.csv";

                bool append = true;
                var config = new CsvConfiguration(CultureInfo.InvariantCulture);
                //config.HasHeaderRecord;

                using (var writer = new StreamWriter(filePath,append))
                using(var csv = new CsvWriter(writer, config))
                {
                    csv.Context.RegisterClassMap<ContactMap>();
                    if (!config.HasHeaderRecord)
                    {
                        csv.WriteHeader<Contact>();
                        csv.NextRecord();
                    }
                   
                    foreach (var item in this.AddressBookList)
                    {
                        foreach (var i in item.Value.ContactList)
                        {
                            csv.WriteRecord(i.Value);
                            csv.NextRecord();

                        }
                    }
                };

                Console.WriteLine("File Updated Successfully.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

        public void SearchByCityOrState(string cityOrState)
        {
            foreach (var item in this.AddressBookList)
            {
                foreach (var i in item.Value.ContactList)
                {
                    if ((i.Value.City == cityOrState) || (i.Value.State == cityOrState))
                    {
                        Console.WriteLine($"Full Name : {i.Value.FirstName} {i.Value.LastName}");
                    }
                }
            }
        }

        public void CountPeopleByCityOrState(string cityOrState)
        {
            int count = 0;

            foreach (var item in this.AddressBookList)
            {
                foreach (var i in item.Value.ContactList)
                {
                    if ((i.Value.City == cityOrState) || (i.Value.State == cityOrState))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"Number of persons in {cityOrState} = {count}");
        }

        public void SortByName()
        {
            foreach (var item in this.AddressBookList)
            {
                foreach (var i in item.Value.ContactList.Values.OrderBy(x => x.FirstName))
                {
                    i.DisplayContactRecord();
                }
            }
        }

        public void SortByCity()
        {
            foreach (var item in this.AddressBookList)
            {
                foreach (var i in item.Value.ContactList.Values.OrderBy(x => x.City))
                {
                    i.DisplayContactRecord();
                }
            }
        }

        public void SortByState()
        {
            foreach (var item in this.AddressBookList)
            {
                foreach (var i in item.Value.ContactList.Values.OrderBy(x => x.State))
                {
                    i.DisplayContactRecord(); 
                }
            }
        }

        public void SortByZipCode()
        {
            foreach (var item in this.AddressBookList)
            {
                foreach (var i in item.Value.ContactList.Values.OrderBy(x => x.Zip))
                {
                    i.DisplayContactRecord();
                }
            }
        }
        
        public static void Main()
        {
            Program p1 = new();

            int choice = 0;
            int choice1 = 0;


            p1.AddressBookList = new Dictionary<string, AddressBookMain>();


            p1.contacts = new List<Contact>();
            p1.CityList = new Dictionary<string, List<Contact>>();

            while ((choice1 = UserInput()) != 0)
            {
                switch (choice1)
                {
                    case 1:
                        AddressBookMain addressBook = new();

                        Console.WriteLine("Add Address Book\n--------------");
                        Console.WriteLine("Enter the Name of the Name of Address Book : ");

                        addressBook.AddressBookName = Console.ReadLine();

                        if (p1.AddressBookList.ContainsKey(addressBook.AddressBookName))
                        {
                            Console.WriteLine($"An element with Address Book = {addressBook.AddressBookName} already exists.");
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
                                            p1.contacts.Add(contact);//new uc9
                                        }
                                        catch (ArgumentException)
                                        {
                                            Console.WriteLine($"An element with Key = {contact.FirstName} already exists.");
                                        }
                                    }
                                    if (!p1.AddressBookList.Keys.Contains(addressBook.AddressBookName))
                                    {
                                         p1.AddressBookList.Add(addressBook.AddressBookName, addressBook);//exception : record is already added on same key
                                    }

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

                    case 2:
                        Console.WriteLine("Display Address Book Details");

                        p1.DisplayAddressBookDetails();

                        break;

                    case 3:
                        if (p1.AddressBookList.Count == 0)
                        {
                            Console.WriteLine("Address Book is Empty.");
                        }
                        else
                        {
                            Console.WriteLine("Enter City or State Name to search the person. : ");
                            string? cityOrState = Console.ReadLine();

                            p1.SearchByCityOrState(cityOrState);
                        }

                        break;

                    case 4:
                        if (p1.AddressBookList.Count == 0)
                        {
                            Console.WriteLine("Address Book is Empty.");
                        }
                        else
                        {
                            Console.WriteLine("Enter City or State : ");
                            string? cityOrState = Console.ReadLine();

                            p1.CountPeopleByCityOrState(cityOrState);
                        }
                        break;

                    case 5:
                        if (p1.AddressBookList.Count == 0)
                        {
                            Console.WriteLine("Address Book is Empty.");
                        }
                        else
                        {
                            p1.SortByName();
                        }
                        break;

                    case 6:
                        if (p1.AddressBookList.Count == 0)
                        {
                            Console.WriteLine("Address Book is Empty.");
                        }
                        else
                        {
                            p1.SortByCity();
                        }
                        break;

                    case 7:
                        if (p1.AddressBookList.Count == 0)
                        {
                            Console.WriteLine("Address Book is Empty.");
                        }
                        else
                        {
                            p1.SortByState();
                        }
                        break; 
                    
                    case 8:
                        if (p1.AddressBookList.Count == 0)
                        {
                            Console.WriteLine("Address Book is Empty.");
                        }
                        else
                        {
                            p1.SortByZipCode();
                        }
                        break;

                    //case 9:
                    //    if (p1.AddressBookList.Count == 0)
                    //    {
                    //        Console.WriteLine("Address Book is Empty.");
                    //    }
                    //    else
                    //    {
                    //        foreach (var item in p1.AddressBookList)
                    //        {
                    //            foreach (var i in item.Value.ContactList)
                    //            {
                    //                i.Contact.Sort();
                    //            }
                    //        }
                    //    }
                    //    break;
                }
            }

            p1.SaveStateInCsv();
            //p1.ReadStateFromCsv();
            p1.CheckCSV();
        }
    }
}