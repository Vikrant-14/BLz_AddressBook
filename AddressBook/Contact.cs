using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Contact
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
            return $"{this.FirstName} {this.LastName}, {this.Email}; {this.Address}, {this.City}, {this.State} , {this.Zip} \n {this.PhoneNumber}";
        }
    }
}