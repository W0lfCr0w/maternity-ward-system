namespace maternity_ward_system
{
    public class SousChef: Cook, IExpertEmployee
    {
        public double ExpertHourlyPay{get; private set;}
        public SousChef(string fname, string lname, string id, int age, double hours)
            :base(fname, lname, id, age, hours)
            {
                ExpertHourlyPay = HourlyPay * 1.3;
            }
        public SousChef(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public override double EndOfMonthSalary()
        {
            return ExpertHourlyPay * this.workInformation.HoursWorked;
        }
    }
}