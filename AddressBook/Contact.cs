using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AddressBook
{
    internal class Contact : IComparable<Contact>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }


        public void AcceptContactRecord()
        {
            Console.Write("Enter your First Name : ");
            this.FirstName = Console.ReadLine();

            Console.Write("Enter your Last Name : ");
            this.LastName = Console.ReadLine();

            Console.Write("Enter your Email : ");
            this.Email = Console.ReadLine();

            Console.Write("Enter your Address : ");
            this.Address = Console.ReadLine();

            Console.Write("Enter your City : ");
            this.City = Console.ReadLine();

            Console.Write("Enter your State : ");
            this.State = Console.ReadLine();

            Console.Write("Enter your City ZIP Code : ");
            this.Zip = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Phone Number : ");
            this.PhoneNumber = Convert.ToInt64(Console.ReadLine());
        }

        public int CompareTo(Contact? other)
        {
            Console.WriteLine("1.Enter One to sort By City. ");
            Console.WriteLine("2.Enter Two to sort By State. ");
            Console.WriteLine("3.Enter Three to sort By ZipCode. ");
            Console.WriteLine("Enter option to sort by : ");
            int option = Convert.ToInt32(Console.ReadLine());

            if(option == 1) 
            {
                return this.City.CompareTo(other.City);
            }
            else if(option == 2) 
            {
                return this.State.CompareTo(other.State);
            }
            else if(option == 3)
            {
                if (this.Zip > other.Zip)
                {
                    return 1;
                }
                else if (this.Zip == other.Zip)
                {
                    return 0;
                }
            }

            return 0;
        }

        public void DisplayContactRecord()
        {
            Console.WriteLine("================================");
            Console.WriteLine("First Name : " + this.FirstName);
            Console.WriteLine("Last Name : " + this.LastName);
            Console.WriteLine("Email : " + this.Email);
            Console.WriteLine("Address : " + this.Address);
            Console.WriteLine("City : " + this.City);
            Console.WriteLine("State : " + this.State);
            Console.WriteLine("ZIP : " + this.Zip);
            Console.WriteLine("Phone Number : " + this.PhoneNumber);
            Console.WriteLine("================================");
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName},\n {this.Email};\n {this.Address}, \n {this.City}, {this.State},\n {this.Zip} \n {this.PhoneNumber}";
        }
    }

    internal class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.Email).Name("Email");
            Map(m => m.Address).Name("Address");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.Zip).Name("Zip Code");
            Map(m => m.PhoneNumber).Name("Phone Number");
        }
    }
}