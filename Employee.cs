namespace maternity_ward_system
{
    public class Employee
    {   
        public const double BasePay = 30;
        private string _firstName;
        private string _lastName;
        private string _id;
        private int _age;
        public WorkingHours workInformation;
        public string FirstName
        {
            get{ return this._firstName;} 
            set
            {
                if(value != "")
                    this._firstName = value;
            }
        }
        public string LastName
        {
            get{ return this._lastName;} 
            set
            {
                if(value != "")
                    this._lastName = value;
            }
        }
        public int Age
        {
            get{ return this._age;} 
            set
            {
                if(value >= 18)
                    this._age = value;
                else
                {
                    System.Console.ForegroundColor = System.ConsoleColor.Red;
                    System.Console.WriteLine("Too Young. Employee must be at least 18 years of age");
                    System.Console.ResetColor();
                }
            }
        }
        public string ID
        {
            get{return this._id;}
            set
            {
                if(value.Length == 5) 
                    this._id = value;
                else
                {
                    System.Console.ForegroundColor = System.ConsoleColor.Red;
                    System.Console.WriteLine("ID value must be above 5 digits");
                    System.Console.ResetColor();
                }
            }
        }
        public Employee(string firstname, string lastname, string id, int age, double hours)
        {
            FirstName = firstname;
            LastName = lastname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
        }
        public Employee(string firstname, string lastname, string id, int age):this(firstname, lastname, id, age, 0){}
    }
}