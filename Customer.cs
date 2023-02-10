using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    // Customer class which contains information of a customer and its policies.
    public class Customer
    {
        // Object of Insurance class is created.
        Insurance i = new Insurance();

        // Customer's attributes
        public int Customer_id;
            public string Customer_Name;
            public string Email_Id;
            public string Password;
            public string Address;
            public long Contact_Number;
            public string Nominee_Name;
            public string Customer_relationship;
            public string Policy_Number;
            public string Policy_Type;
            public string Date;
            public string title;
            public string sum_Assured;
            public string Premium;
            public string Term;
            public string Next_Due;

        // Default Constructor.
        public Customer()
        {
        }

        // Constructor with customer's id, name, email id, password, address, contact number, nominee name and customer relationship as parameters.
        public Customer(int Customer_id, string Customer_Name, string Email_Id, string Password, string Address, long Contact_Number, string Nominee_Name, string Customer_relationship)
        {
            this.Customer_id = Customer_id;
            this.Customer_Name = Customer_Name;
            this.Email_Id = Email_Id;
            this.Password = Password;
            this.Address = Address;
            this.Contact_Number = Contact_Number;
            this.Nominee_Name = Nominee_Name;
            this.Customer_relationship = Customer_relationship;
        }

        // Constructor with customer's id, name, policy type, title, premium, sum assured, nominee name, email id, contact number and next due as parameters.
        public Customer(int Customer_id, string Customer_Name, string policy_type, string title, string Premium, string sum_Assured, string Nominee_Name, string Email_Id, long Contact_Number, string Next_Due)
        {
                this.Customer_id = Customer_id;
                this.Customer_Name = Customer_Name;
                this.Email_Id = Email_Id;
                this.title = title;
                this.sum_Assured = sum_Assured;
                this.Next_Due = Next_Due;
                this.Premium = Premium;
                this.Contact_Number = Contact_Number;
                this.Nominee_Name = Nominee_Name;
                this.Policy_Type = policy_type;
        }

        // This method assigns values to various parameters and adds a new policy
        public void Assign_Value(string custid, string sum_assured, string policy_type, string p_remium, string term, string t_itle)
        {
            // Creating a random number generator and getting current date and time
            Random rand = new Random();
            DateTime dt = DateTime.Now;
            DateTime dt2 = dt.AddMonths(1);

            // Generating a random policy number, getting the date and next due date as strings
            string Policy_Number = Convert.ToString(rand.Next(0000000, 9999999));
            string Date = dt.ToShortDateString();
            string Next_Due = dt2.ToShortDateString();

            // Adding a new policy with all the parameters
            int n = i.AddPolicy(custid, Policy_Number, policy_type, Date, sum_assured, p_remium, term, t_itle, Next_Due);
            if (n == 1)
            {
                Console.WriteLine(Policy_Number + " - Policy Taken Successfully\n");
            }
            else
            {
                Console.WriteLine("Policy Taken Successfully\n");
            }
        }


        public void show()
        {
            // Display header for the customer information
            Console.WriteLine("CustomerId     |CustomerName   |PolicyType     |Title          |Status  |Premium |Sum Assured |NomineeName    |Email                    |Phone       |NextDue");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            // Show information for the current customer object
            Console.WriteLine($"{Customer_id,-16}{Customer_Name,-16}{Policy_Type,-16}{title,-16}{"Active",-9}{Premium,-9}{sum_Assured,-13}{Nominee_Name,-16} {Email_Id,-25}{Contact_Number,-13}{Next_Due}\n\n");
        }

        public void showAll()
        {
            // Fetch all customer information
            List<Customer> l = i.fetchCustomer();
            // Display header for the customer information
            Console.WriteLine("CustomerId     |CustomerName   |PolicyType     |Title          |Status  |Premium |Sum Assured |NomineeName    |Email                    |Phone       |NextDue");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            // Loop through the list of customers and show information for each customer
            foreach (var Cus in l)
            {
                Console.WriteLine($"{Cus.Customer_id,-16}{Cus.Customer_Name,-16}{Cus.Policy_Type,-16}{Cus.title,-16}{"Active",-9}{Cus.Premium,-9}{Cus.sum_Assured,-13}{Cus.Nominee_Name,-16} {Cus.Email_Id,-25}{Cus.Contact_Number,-13}{Cus.Next_Due}");
            }
            Console.WriteLine("\n\n");
        }

        // The showAll method takes a customer ID as a parameter and retrieves a list of Customer objects using the `fetchCustomer` method.
        public void showAll(string cust_id)
        {
            // Retrieve a list of Customer objects with the specified customer ID.
            List<Customer> l = i.fetchCustomer(cust_id);

            // Print a header for the customer information.
            Console.WriteLine("CustomerId     |CustomerName   |PolicyType     |Title          |Status  |Premium |Sum Assured |NomineeName    |Email                    |Phone       |NextDue");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");

            // Loop through each Customer object in the list and print its information.
            foreach (var Cus in l)
            {
                Console.WriteLine($"{Cus.Customer_id,-16}{Cus.Customer_Name,-16}{Cus.Policy_Type,-16}{Cus.title,-16}{"Active",-9}{Cus.Premium,-9}{Cus.sum_Assured,-13}{Cus.Nominee_Name,-16} {Cus.Email_Id,-25}{Cus.Contact_Number,-13}{Cus.Next_Due}");
            }

            // Print a blank line at the end of the output.
            Console.WriteLine("\n\n");
        }


    }
}