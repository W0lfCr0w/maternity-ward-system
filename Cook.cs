namespace maternity_ward_system
{
    public class Cook: Employee, ISeniorEmployee
    {
        public double HourlyPay{get; private set;}
        public void SeniorEmployeeRaise()
        {
            HourlyPay = HourlyPay * 1.05;
        }
        public Cook(string fname, string lname, string id, int age, double hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
            SeniorEmployeeRaise();
            MyEmployeeType = EmployeeType.Cook.ToString();
        }
        public Cook(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public override double EndOfMonthSalary()
        {
            return HourlyPay * this.workInformation.HoursWorked;
        }
    }
}