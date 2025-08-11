using Microsoft.Data.SqlClient;
namespace Answer1
{
    internal class Program
    {
        static string conStr = @"server=.;database=answer1;integrated security=true;TrustServerCertificate=true";

        static void Main(string[] args)
        {
            Console.WriteLine("Select Employee Type:");
            string type = Console.ReadLine();

            if (type == "contract")
            {
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Reporting Manager:");
                string manager = Console.ReadLine();

                Console.WriteLine("Enter Contract Date :");
                DateTime contractDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Duration :");
                int duration = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Charges:");
                decimal charges = decimal.Parse(Console.ReadLine());

                InsertContractEmployee(name, manager, contractDate, duration, charges);
            }
            else if (type == "payroll")
            {
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Reporting Manager:");
                string manager = Console.ReadLine();
                Console.WriteLine("Enter Joining Date :");
                DateTime joinDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Experience :");
                int exp = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Basic Salary:");
                decimal basic = decimal.Parse(Console.ReadLine());

                InsertPayrollEmployee(name, manager, joinDate, exp, basic);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

        static void InsertContractEmployee(string name, string manager, DateTime contractDate, int duration, decimal charges)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string query = @"INSERT INTO Employee (Name, ReportingManager, Type, ContractDate, DurationInMonths, Charges)
                         VALUES (@name, @mgr, 'Contract', @cdate, @dur, @charges)";

            SqlCommand comd = new SqlCommand(query, con);
            comd.Parameters.AddWithValue("@name", name);
            comd.Parameters.AddWithValue("@mgr", manager);
            comd.Parameters.AddWithValue("@cdate", contractDate);
            comd.Parameters.AddWithValue("@dur", duration);
            comd.Parameters.AddWithValue("@charges", charges);

            comd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Contract employee inserted.");
        }

        static void InsertPayrollEmployee(string name, string manager, DateTime joiningDate, int exp, decimal basic)
        {
            decimal da = 0, hra = 0, pf = 0, net = 0;

            if (exp > 10)
            {
                da = 0.10m * basic;
                hra = 0.085m * basic;
                pf = 6200;
            }
            else if (exp > 7)
            {
                da = 0.07m * basic;
                hra = 0.065m * basic;
                pf = 4100;
            }
            else if (exp > 5)
            {
                da = 0.041m * basic;
                hra = 0.038m * basic;
                pf = 1800;
            }
            else
            {
                da = 0.019m * basic;
                hra = 0.020m * basic;
                pf = 1200;
            }

            net = basic + da + hra - pf;

            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string query = @"INSERT INTO Employee (Name, ReportingManager, Type, JoiningDate, ExperienceYears, BasicSalary, DA, HRA, PF, NetSalary)
                         VALUES (@name, @mgr, 'Payroll', @jdate, @exp, @basic, @da, @hra, @pf, @net)";

            SqlCommand comd = new SqlCommand(query, con);
            comd.Parameters.AddWithValue("@name", name);
            comd.Parameters.AddWithValue("@mgr", manager);
            comd.Parameters.AddWithValue("@jdate", joiningDate);
            comd.Parameters.AddWithValue("@exp", exp);
            comd.Parameters.AddWithValue("@basic", basic);
            comd.Parameters.AddWithValue("@da", da);
            comd.Parameters.AddWithValue("@hra", hra);
            comd.Parameters.AddWithValue("@pf", pf);
            comd.Parameters.AddWithValue("@net", net);
            comd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Payroll employee inserted.");
        }
    }
}

