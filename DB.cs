using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;
namespace maternity_ward_system
{
    public enum EmployeeType
    {
        Cleaner, PoisonCleaner, HeadCleaner, SupervisorCleaner,
        Cook, SousChef, Chef, FoodDistributer,
        HeadOfManagement,
        FirstAid, Nurse, Paramedic,
        HeadNurse,
        Midwife, BreechMidwife,
        Intern, BreechIntern,
        Doctor, SeniorDoctor, SpecialityDcotor,
        ViceHeadOfWard, HeadOfWard
    }
    public class DB
    {
        private List<Employee> _employeesDB;
        public DB(){ LoadDB(); }
        private class GeneralEmployee
        {
            public string FirstName{get; set;}
            public string LastName{get; set;}
            public string ID{get; set;}
            public int Age{get; set;}
            public string MyEmployeeType{get; set;}
            public double HoursWorked{get; set;}
            public string ExtraField{get; set;}
            public GeneralEmployee(string fname, string lname, int age, string id, string e, double hours, string extra)
            {
                FirstName = fname;
                LastName = lname;
                ID = id;
                Age = age;
                MyEmployeeType = e;
                HoursWorked = hours;
                ExtraField = extra;
            }
        }
        
        public string GetFirstName()
        {
            string fname;
            Console.WriteLine("Enter First Name:");
            fname = Console.ReadLine();
            while (string.IsNullOrEmpty(fname) || fname.Length == 1 || !Regex.Match(fname, "^[A-Z][a-zA-Z]*$").Success)
            {
                if(!Regex.Match(fname, "^[A-Z][a-zA-Z]*$").Success)
                    System.Console.WriteLine("Name contains illegal characters");
                else
                    Console.WriteLine("Name is empty or too short! Input employee's first name once more");
                fname = Console.ReadLine();
            }
            return fname;
        }
        public string GetLastName()
        {
            string lname;
            Console.WriteLine("Enter Last Name:");
            lname = Console.ReadLine();
            while (string.IsNullOrEmpty(lname) || lname.Length == 1 || !Regex.Match(lname, "^[A-Z][a-zA-Z]*$").Success)
            {
                if(!Regex.Match(lname, "^[A-Z][a-zA-Z]*$").Success)
                    System.Console.WriteLine("Name contains illegal characters");
                else
                    Console.WriteLine("Name Name is empty or too short! Input employee's last name once more");
                lname = Console.ReadLine();
            }
            return lname;
        }
        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public string GetID()
        {
            string id;
            Console.WriteLine("Enter Employee ID (5 digits long):");
            id = Console.ReadLine();
            while (string.IsNullOrEmpty(id) || id.Length != 5 || isIDExist(id)|| !IsAllDigits(id))
            {
                if(isIDExist(id))
                    Console.WriteLine("Error! ID already exists!");
                else if(!IsAllDigits(id))
                    Console.WriteLine("Error! ID must only have digits inside");
                else
                    Console.WriteLine("Error! ID must be 5 digits!");
                id = Console.ReadLine();
            }
            return id;
        }
        public bool isIDExist(string newID)
        {
            foreach(Employee e in this._employeesDB)
            {
                if(e.ID == newID)
                    return true;
            }
            return false;
        }
        public int GetAge()
        {
            int age;
            System.Console.WriteLine("Enter Age");
            string stringage = Console.ReadLine();
            while(!int.TryParse(stringage, out age))
            {
                Console.WriteLine("Age should be a number");
                stringage = Console.ReadLine();
            }
            return age;
        }
        public double GetManagerSalary()
        {
            Console.WriteLine("Please enter the managers monthly salary:");
            double salary;
            string stringsalary = Console.ReadLine();
            while(!double.TryParse(stringsalary, out salary))
            {
                Console.WriteLine("Salary needs to be a number");
                stringsalary = Console.ReadLine();
            }
            return salary;
        }
        public void AddHoursToEmployee(string id, double hours)
        {
            _employeesDB.Find(e => e.ID ==id).workInformation.AddHours(hours);
        }
        public string[] GetEmployeeDetails(string id)
        {
            var e = _employeesDB.Find(e => e.ID == id);
            string[] details = new string[3];
            details[0] = e.EndOfMonthSalary().ToString();
            details[1] = e.HoursWorked.ToString("0.00");
            details[2] = e.FirstName + " " + e.LastName;
            return details;
        }
        public void AddToDB(Employee e)
        {
            this._employeesDB.Add(e); 
        }
        public void AddEmployee(EmployeeType t)
        {
            switch(t)
            {
                case EmployeeType.Cleaner:
                {
                    AddToDB(new Cleaner(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.PoisonCleaner:
                {
                    AddToDB(new PoisonCleaner(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.HeadCleaner:
                {
                    AddToDB(new HeadCleaner(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.SupervisorCleaner:
                {
                    AddToDB(new SupervisorCleaner(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.Cook:
                {
                    AddToDB(new Cook(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.SousChef:
                {
                    AddToDB(new SousChef(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.Chef:
                {
                    AddToDB(new Chef(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.FoodDistributer:
                {
                    AddToDB(new FoodDistributer(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.HeadOfManagement:
                {
                    AddToDB(new HeadOfManagement(GetFirstName(), GetLastName(), GetID(), GetAge(), GetManagerSalary()));
                    break;
                }
                case EmployeeType.FirstAid:
                {
                    AddToDB(new FirstAid(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.Nurse:
                {
                    AddToDB(new Nurse(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.Paramedic:
                {
                    AddToDB(new Paramedic(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.HeadNurse:
                {
                    AddToDB(new HeadNurse(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.Midwife:
                {
                    AddToDB(new Midwife(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.BreechMidwife:
                {
                    AddToDB(new BreechMidwife(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.Intern:
                {
                    AddToDB(new Intern(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.BreechIntern:
                {
                    AddToDB(new InternWithBreechSpecialty(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.Doctor:
                {
                    AddToDB(new Doctor(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.SeniorDoctor:
                {
                    AddToDB(new SeniorDoctor(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.SpecialityDcotor:
                {
                    AddToDB(new SpecialityDoctor(GetFirstName(), GetLastName(), GetID(), GetAge()));
                    break;
                }
                case EmployeeType.ViceHeadOfWard:
                {
                    AddToDB(new ViceHeadOfMaternitiyWard(GetFirstName(), GetLastName(), GetID(), GetAge(), GetManagerSalary()));
                    break;
                }
                case EmployeeType.HeadOfWard:
                {
                    AddToDB(new HeadOfMaternityWard(GetFirstName(), GetLastName(), GetID(), GetAge(), GetManagerSalary()));
                    break;
                }
                default:
                {
                    Console.WriteLine("NO Such Employee Type");
                    break;
                }
            }

        }
        private void AddEmployee(GeneralEmployee ge)
        {
            switch(Enum.Parse(typeof(EmployeeType), ge.MyEmployeeType))
            {
                case EmployeeType.Cleaner:
                {
                    AddToDB(new Cleaner(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.PoisonCleaner:
                {
                    AddToDB(new PoisonCleaner(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.HeadCleaner:
                {
                    AddToDB(new HeadCleaner(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.SupervisorCleaner:
                {
                    AddToDB(new SupervisorCleaner(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.Cook:
                {
                    AddToDB(new Cook(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.SousChef:
                {
                    AddToDB(new SousChef(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.Chef:
                {
                    AddToDB(new Chef(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.FoodDistributer:
                {
                    AddToDB(new FoodDistributer(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.HeadOfManagement:
                {
                    AddToDB(new HeadOfManagement(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked, double.Parse(ge.ExtraField)));
                    break;
                }
                case EmployeeType.FirstAid:
                {
                    AddToDB(new FirstAid(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.Nurse:
                {
                    AddToDB(new Nurse(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.Paramedic:
                {
                    AddToDB(new Paramedic(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.HeadNurse:
                {
                    AddToDB(new HeadNurse(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.Midwife:
                {
                    AddToDB(new Midwife(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.BreechMidwife:
                {
                    AddToDB(new BreechMidwife(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.Intern:
                {
                    AddToDB(new Intern(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.BreechIntern:
                {
                    AddToDB(new InternWithBreechSpecialty(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.Doctor:
                {
                    AddToDB(new Doctor(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.SeniorDoctor:
                {
                    AddToDB(new SeniorDoctor(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.SpecialityDcotor:
                {
                    AddToDB(new SpecialityDoctor(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked));
                    break;
                }
                case EmployeeType.ViceHeadOfWard:
                {
                    AddToDB(new ViceHeadOfMaternitiyWard(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked, double.Parse(ge.ExtraField)));
                    break;
                }
                case EmployeeType.HeadOfWard:
                {
                    AddToDB(new HeadOfMaternityWard(ge.FirstName, ge.LastName, ge.ID, ge.Age, ge.HoursWorked, double.Parse(ge.ExtraField)));
                    break;
                }
                default:
                {
                    break;
                }
            }
        }
        public void SaveDB()
        {
            string jsonDB = "EmployeesDB.json";
            string db = System.Text.Json.JsonSerializer.Serialize(this._employeesDB);
            File.WriteAllText(jsonDB, db);
        }
        public void LoadDB()
        {
            // this._employeesDB = new List<Employee>();
            try
            {
                string jsonDB = "EmployeesDB.json";
                string jsonString = File.ReadAllText(jsonDB);
                List<GeneralEmployee> tempDB = JsonConvert.DeserializeObject<List<GeneralEmployee>>(jsonString);
                this._employeesDB = new List<Employee>();
                GenEmployeeToEmployeeDB(tempDB);
            }
            catch (FileNotFoundException)
            {
                this._employeesDB = new List<Employee>();
            }
        }
        private void GenEmployeeToEmployeeDB(List<GeneralEmployee> tempDB)
        {
            foreach(GeneralEmployee ge in tempDB)
            {
                AddEmployee(ge);
            }
        }
    }
}