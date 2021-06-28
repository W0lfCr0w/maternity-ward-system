using System;

namespace maternity_ward_system
{
    class Program
    {

        static void Main(string[] args)
        {
            DB db =  new DB();
            bool isSaved = false;
            Console.WriteLine("Welcome to the employee database interface");
            Console.WriteLine("Choose what type of employee and then enter his/her details");
            do
            {
                Console.WriteLine("Type 'save' to save and exit");
                foreach (EmployeeType etype in (EmployeeType[]) Enum.GetValues(typeof(EmployeeType)))
                {
                    Console.WriteLine($"Choose {(int)etype} for {etype.ToString()}");
                }
                string response = Console.ReadLine();
                if(response == "Save" || response == "save")
                {
                    db.PrintEmployees();
                    Console.WriteLine("Thank you and goodbye");
                    isSaved = true;
                }
                else if( int.Parse(response) >= 0 || int.Parse(response) <= 21)
                {
                    db.AddEmployee((EmployeeType)Enum.Parse(typeof(EmployeeType), response));
                }
            }while(!isSaved);

        }
    }
}
