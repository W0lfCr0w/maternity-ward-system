namespace maternity_ward_system
{
    public class SousChef: Employee, ISeniorEmployee, IExpertEmployee
    {
        public double HourlyPay{get; private set;}
        public double ExpertHourlyPay{get; private set;}
        public void SeniorEmployeeRaise()
        {
            HourlyPay = HourlyPay * 1.05;
        }
        public SousChef(string fname, string lname, string id, int age, double hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
            SeniorEmployeeRaise();
            ExpertHourlyPay = HourlyPay * 1.3;
        }
        public SousChef(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public override double EndOfMonthSalary()
        {
            return ExpertHourlyPay * this.workInformation.HoursWorked;
        }
    }
}