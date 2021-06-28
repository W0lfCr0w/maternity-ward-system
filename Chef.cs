namespace maternity_ward_system
{
    public class Chef: SousChef, IDecisionMaker
    {
        public string UniqueJobDescripition{get; private set;}
        public int MinimumMonthlyHours{get; private set;}
        public Chef(string fname, string lname, string id, int age, double hours)
            :base(fname, lname, id, age, hours)
        {
            UniqueJobDescripition = "The Chef of the kitchen makes choices about the food being served";
            MinimumMonthlyHours = 50;
            MyEmployeeType = EmployeeType.Chef.ToString();
        }
        public Chef(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public double GetDecisionMakerBonusPay()
        {
            if(this.workInformation.HoursWorked > MinimumMonthlyHours)
                return 200 * (1.5 * HourlyPay);
            else
                return 0;
        }
        public override double EndOfMonthSalary()
        {
            double dmsalary = this.GetDecisionMakerBonusPay();
            return base.EndOfMonthSalary() + dmsalary;
        }
    }
}