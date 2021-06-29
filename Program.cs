using System;

namespace maternity_ward_system
{
    public class WardConsoles
        {
            public DB employeesDB = new DB();
            public DB EmployeeDB
            {
                get{ return this.employeesDB; }
            }
            public WardConsoles()
            {
                
            }
            public void AddEmployeesConsole()
            {
                bool isSaved = false;
                Console.WriteLine("Welcome to the Employee Database Interface");
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
                        employeesDB.SaveDB();
                        Console.WriteLine("New Employees Saved");
                        isSaved = true;
                    }
                    else if( int.Parse(response) >= 0 || int.Parse(response) <= 21)
                    {
                        employeesDB.AddEmployee((EmployeeType)Enum.Parse(typeof(EmployeeType), response));
                    }
                }while(!isSaved);
            }
            public double GetHours()
            {
                Console.WriteLine("Enter the starting hour in HH:MM format or HH:MM AM/PM");
                string startTime = Console.ReadLine();
                DateTime startDate;
                while(!DateTime.TryParse(startTime, out startDate))
                {
                    Console.WriteLine("The hour entered was not in the correct format, try again.");
                    startTime = Console.ReadLine();
                } 
                Console.WriteLine("Enter the ending hour in HH:MM format or HH:MM AM/PM");
                string endTime = Console.ReadLine();
                DateTime endDate;
                while(!DateTime.TryParse(endTime, out endDate))
                {
                    Console.WriteLine("The hour entered was not in the correct format, try again.");
                    endTime = Console.ReadLine();
                }
                TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                string hours = duration.ToString(@"hh\:mm");
                return (double)duration.TotalHours;       
            }
            public void AddWorkHoursToEmployeesConsole()
            {
                bool isSaved = false;
                System.Console.WriteLine("Welcome to the Employee Work Hours Interface");
                do
                {
                    Console.WriteLine("Enter the ID of the employee you want to add hours to");
                    Console.WriteLine("Type 'save' to save and exit");
                    string id = Console.ReadLine();
                    if(EmployeeDB.isIDExist(id))
                    {
                        EmployeeDB.AddHoursToEmployee(id, GetHours());
                    }
                    else if(id == "Save" || id == "save")
                    {
                        EmployeeDB.SaveDB();
                        isSaved = true;
                    }

                }while(!isSaved);
            }
            public void EmployeeSalaryConsole()
            {
                bool isClose = false;
                Console.WriteLine("Welcome to the Salary Interface");
                do
                {
                    Console.WriteLine("Enter the ID of the employee that you want to see his/hers salary this month");
                    Console.WriteLine("Type 'close' to exit");
                    string response = Console.ReadLine();
                    if(EmployeeDB.isIDExist(response))
                    {
                        string[] details = EmployeeDB.GetEmployeeDetails(response);
                        System.Console.WriteLine($"Employee #{response}:{details[2]} worked for {double.Parse(details[1])} hours this month.");
                        System.Console.WriteLine($"His salary this month will be {details[0]}$");
                    }
                    else if(response == "Close" || response == "close")
                    {
                        EmployeeDB.SaveDB();
                        isClose = true;
                    }

                }while(!isClose);
            }
            public void GeneralConsole()
            {
                bool isQuit = false;
                string response;
                while(!isQuit)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("Welcome to the Employee Records Center console");
                    System.Console.WriteLine("Please choose the action you want to do");
                    System.Console.WriteLine("Enter 1 to add an employee to the database.");
                    System.Console.WriteLine("Enter 2 to add an employee's working hours for the day");
                    System.Console.WriteLine("Enter 3 to view an employee's salary");
                    System.Console.WriteLine("To exit the console enter quit");
                    response = Console.ReadLine();
                    if(response == "Quit" || response == "quit")
                        {
                            isQuit = true;
                            break;
                        }
                    if(int.Parse(response) < 4 && int.Parse(response) > 0)
                    {
                        switch(int.Parse(response))
                        {
                            case 1:
                            {
                                AddEmployeesConsole();
                                break;
                            }
                            case 2:
                            {
                                AddWorkHoursToEmployeesConsole();
                                break;
                            }
                            case 3:
                            {
                                EmployeeSalaryConsole();
                                break;
                            }
                        }   
                    }
                    else
                    {
                        System.Console.WriteLine("You entered an invalid action, please try again");
                    }
                    
                }
            }
        }
    class Program
    {
        
        static void Main(string[] args)
        {
            WardConsoles wc = new WardConsoles();
            wc.GeneralConsole();
        }
    }
}
