using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleApp4
{

    public class Program
    {
        public static List<Customer> customer = new List<Customer>();

        static void Main(string[] args)
        {
            Customer c = new Customer();
            Insurance i = new Insurance();
            Random rand = new Random();
            i.Create_Table_Customer();
            i.Create_Table_Policy();

        label1:
            try
            {

                Console.WriteLine("1.Customer Registeration\n2.Select Policy Type\n3.View Customer Details\n4.View All Customer Details\n5.Exit\n");
                long Switch_Input = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("\n");

                switch (Switch_Input)
                {
                    case 1:
                        {
                            int Input1 = rand.Next(1111111, 9999999);

                        // Loop to validate the customer name
                        label3:
                            Console.Write("Enter the Customer_Name [Max 50 Characters] : ");
                            string Input2 = Console.ReadLine();
                            if (Input2.Length > 50 || Input2.Length < 2)
                            {
                                Console.WriteLine("Invalid Input");
                                goto label3;
                            }

                        // Loop to validate the email
                        label4:
                            Console.Write("Enter your Email_Id : ");
                            string Input3 = Console.ReadLine();
                            if (Input3.Length < 6)
                            {
                                Console.WriteLine("Invalid Input");
                                goto label4;
                            }

                        // Loop to validate the password
                        label5:
                            Console.Write("Enter the Password [Max 30 Characters] : ");
                            string Input4 = Console.ReadLine();
                            if (Input4.Length > 30 || Input4.Length < 4)
                            {
                                Console.WriteLine("Invalid Input");
                                goto label5;
                            }

                        // Loop to validate the address
                        label6:
                            Console.Write("Enter the Address [Max 100 Characters] : ");
                            string Input5 = Console.ReadLine();
                            if (Input5.Length > 100 || Input5.Length < 5)
                            {
                                Console.WriteLine("Invalid Input");
                                goto label6;
                            }

                        // Loop to validate the contact number
                        label7:
                            Console.Write("Enter the Contact_Number : ");
                            long Input6 = Convert.ToInt64(Console.ReadLine());
                            if (Input6.ToString().Length != 10)
                            {
                                Console.WriteLine("Invalid Input");
                                goto label7;
                            }

                        // Loop to validate the nominee name
                        label8:
                            Console.Write("Enter the Nominee Name [Max 50 Characters] : ");
                            string Input7 = Console.ReadLine();
                            if (Input7.Length > 50 || Input7.Length < 2)
                            {
                                Console.WriteLine("Invalid Input");
                                goto label8;
                            }

                        // Loop to validate the relationship with nominee
                        label9:
                            Console.Write("Enter the Relationship with the Nominee [Max 50 Characters] : ");
                            string Input8 = Console.ReadLine();
                            if (Input8.Length > 50 || Input8.Length < 2)
                            {
                                Console.WriteLine("Invalid Input");
                                goto label9;
                            }

                            // Creating a customer object with the inputs
                            Customer Customer_Obj = new Customer(Input1, Input2, Input3, Input4, Input5, Input6, Input7, Input8);

                            // Adding the customer to the database and checking the result
                            int n = i.AddCustomer(Input1.ToString(), Input2, Input3, Input4, Input5, Input6.ToString(), Input
                
                            // To check the customer is already present or not
                            if (n!=0)
                            {
                                Console.WriteLine("\n" + n + " Customer Registration is successful\n" + "Your Customer Id : " + Input1 + "\n");
                            }
                            else
                            {
                                Console.WriteLine("\nCustomer is already Registered with same address , contact or email.\n");
                            }
                            break;

                        }

                    case 2:
                        {
                        label14:
                            Console.Write("Enter the seven digit Customer_id : ");
                            string Cust_Id1 = Console.ReadLine();
                            if (Cust_Id1.Length != 7) { Console.WriteLine("Invalid Input"); goto label14; }
                            string id = i.fetchCustomerid(Cust_Id1);
                            if (Cust_Id1!=id)
                            {
                                Console.WriteLine("Customer is not registered...\n");
                                goto label1;
                            }

                                string S_Assured;
                                string Prem_ium;
                                string T_erm;
                                string Pol_type;
                                string title;

                            label10:
                                Console.WriteLine("\nSelect the policy type Given below - \n1.General insurance\n2.Health insurance\n3.Motor insurance\n");
                                int P_in = Convert.ToInt32(Console.ReadLine());

                                switch (P_in)
                                {
                                    case 1:
                                        {
                                        label11:
                                            Console.WriteLine("Select any one General insurance policy from below options - ");
                                            Console.WriteLine("1. Title - janand SumAssured - 300000   Premium - 1567   Term - 2 Years\n" +
                                                "2. Title - BimaGold SumAssured - 700000   Premium - 3347   Term - 3 Years\n" +
                                                "3. Title - ChildCareer SumAssured - 1200000   Premium - 5466   Term - 5 Years\n");
                                            int T_in = Convert.ToInt32(Console.ReadLine());

                                            if (T_in != 1 && T_in != 2 && T_in != 3)
                                            {
                                                Console.WriteLine("Please Select from the below Choice ");

                                                goto label11;
                                            }

                                            if (T_in == 1)
                                            {
                                                title = "Janand";
                                                S_Assured = "300000";
                                                Prem_ium = "1567";
                                                T_erm = "2";
                                                Pol_type = "General";
                                            }
                                            else if (T_in == 2)
                                            {
                                                S_Assured = "700000";
                                                Prem_ium = "3347";
                                                T_erm = "3";
                                                Pol_type = "General";
                                                title = "BimaGold";
                                            }
                                            else
                                            {
                                                S_Assured = "1200000";
                                                Prem_ium = "5466";
                                                T_erm = "5";
                                                Pol_type = "General";
                                               title = "ChildCarrer";
                                            }
                                            c.Assign_Value(Cust_Id1, S_Assured, Pol_type, Prem_ium, T_erm, title);
                                            break;

                                        }
                                    case 2:
                                        {
                                        label12:
                                        Console.WriteLine("Select any one Health insurance policy from below options - ");
                                        Console.WriteLine("1. Title - janand SumAssured - 300000   Premium - 1567   Term - 2 Years\n" +
                                            "2. Title - BimaGold SumAssured - 700000   Premium - 3347   Term - 3 Years\n" +
                                            "3. Title - ChildCareer SumAssured - 1200000   Premium - 5466   Term - 5 Years\n");
                                        int T_in = Convert.ToInt32(Console.ReadLine());
                                            if (T_in != 1 && T_in != 2 && T_in != 3)
                                            {
                                                Console.WriteLine("Please Select from the below Choice ");

                                                goto label12;
                                            }

                                        if (T_in == 1)
                                        {
                                            title = "Janand";
                                            S_Assured = "300000";
                                            Prem_ium = "1567";
                                            T_erm = "2";
                                            Pol_type = "Health";
                                        }
                                        else if (T_in == 2)
                                        {
                                            S_Assured = "700000";
                                            Prem_ium = "3347";
                                            T_erm = "3";
                                            Pol_type = "Health";
                                            title = "BimaGold";
                                        }
                                        else
                                        {
                                            S_Assured = "1200000";
                                            Prem_ium = "5466";
                                            T_erm = "5";
                                            Pol_type = "Health";
                                            title = "ChildCarrer";
                                        }

                                        c.Assign_Value(Cust_Id1,  S_Assured, Pol_type, Prem_ium, T_erm, title);

                                            break;
                                        }
                                    case 3:
                                        {
                                        label13:
                                        Console.WriteLine("Select any one Motor insurance policy from below options - ");
                                        Console.WriteLine("1. Title - janand SumAssured - 300000   Premium - 1567   Term - 2 Years\n" +
                                            "2. Title - BimaGold SumAssured - 700000   Premium - 3347   Term - 3 Years\n" +
                                            "3. Title - ChildCareer SumAssured - 1200000   Premium - 5466   Term - 5 Years\n");
                                        int T_in = Convert.ToInt32(Console.ReadLine());
                                            if (T_in != 1 && T_in != 2 && T_in != 3)
                                            {
                                                Console.WriteLine("Please Select from the below Choice");

                                                goto label13;
                                            }
                                        if (T_in == 1)
                                        {
                                            title = "Janand";
                                            S_Assured = "300000";
                                            Prem_ium = "1567";
                                            T_erm = "2";
                                            Pol_type = "Motor";
                                        }
                                        else if (T_in == 2)
                                        {
                                            S_Assured = "700000";
                                            Prem_ium = "3347";
                                            T_erm = "3";
                                            Pol_type = "Motor";
                                            title = "BimaGold";
                                        }
                                        else
                                        {
                                            S_Assured = "1200000";
                                            Prem_ium = "5466";
                                            T_erm = "5";
                                            Pol_type = "Motor";
                                            title = "ChildCarrer";
                                        }
                                        c.Assign_Value(Cust_Id1,  S_Assured, Pol_type, Prem_ium, T_erm, title);
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Please Select from the below Choice "); goto label10;
                                }

                            break;
                        }

                    case 3:
                        {
                        label15:
                            Console.Write("Enter the seven digit Customer_id : ");
                            string Cust_Id = Console.ReadLine();
                            Console.WriteLine();
                            if (Cust_Id.Length != 7) { Console.WriteLine("Invalid Input"); goto label15; }
                            string id = i.fetchCustomerid(Cust_Id);
                            if (Cust_Id != id)
                            {
                                Console.WriteLine("Customer is not registered...\n");
                                goto label1;
                            }
                            else
                            {
                                c.showAll(Cust_Id);
                            }
                            break;
                        }
                    case 4:
                        {
                            c.showAll();
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("Welcome Back!");
                            Console.ReadKey();
                            return;
                        }

                    default:
                        Console.WriteLine("Please Select from the below Choice ");
                        break;

                }

                goto label1;

            }
            catch (FormatException)
            {
                Console.WriteLine("Entered value is not a number.");
                
            }
            catch(CustomerNotFound e )
            {
                Console.WriteLine(e.Message);
            }
            catch (CustomerAlreadyPresent e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            goto label1;
        }

    }

    // Definition of the exception class "CustomerAlreadyPresent"
    // that inherits from the base class "Exception".
    class CustomerAlreadyPresent : Exception
    {
        // Constructor that takes a string message as an argument
        // and passes it to the base class constructor.
        public CustomerAlreadyPresent(string msg) : base(msg)
        {
            // Empty constructor body
        }
    }

    // Definition of the exception class "CustomerNotFound"
    // that inherits from the base class "Exception".
    class CustomerNotFound : Exception
    {
        // Constructor that takes a string message as an argument
        // and passes it to the base class constructor.
        public CustomerNotFound(string msg) : base(msg)
        {
            // Empty constructor body
        }
    }

}