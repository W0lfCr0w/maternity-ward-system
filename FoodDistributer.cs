namespace maternity_ward_system
{
    public class FoodDistributer: Employee, IMinorEmployee
    {
        public double HourlyPay{get; private set;}
        public FoodDistributer(string fname, string lname, string id, int age, double hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
        }
        public FoodDistributer(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        
        public override double EndOfMonthSalary()
        {
            return this.workInformation.HoursWorked * HourlyPay;
        }
    }
}