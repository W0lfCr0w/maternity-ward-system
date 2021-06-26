namespace maternity_ward_system
{
    public class BreechMidwife: Employee, IExpertEmployee
    {
        public double ExpertHourlyPay{get; private set;}
        public BreechMidwife(string fname, string lname, string id, int age, double hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            ExpertHourlyPay = BasePay * 1.3 ;
        }
        public BreechMidwife(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public override double EndOfMonthSalary()
        {
            return ExpertHourlyPay * this.workInformation.HoursWorked;
        }
    }
}