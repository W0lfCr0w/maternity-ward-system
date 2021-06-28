namespace maternity_ward_system
{
    public class SupervisorCleaner : Employee, IDecisionMaker
    {
        public double HourlyPay{get; private set;}
        public string UniqueJobDescripition{get; private set;}
        public int MinimumMonthlyHours{get; private set;}
        public SupervisorCleaner(string fname, string lname, string id, int age, double hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
            UniqueJobDescripition = "Supervises over all cleaners";
            MinimumMonthlyHours = 50;
            MyEmployeeType = EmployeeType.SupervisorCleaner.ToString();
        }
        public SupervisorCleaner(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public double GetDecisionMakerBonusPay()
        {
            if(this.workInformation.HoursWorked > MinimumMonthlyHours)
                return 200 * (1.5 * HourlyPay);
            else
                return 0;
        }
        public override double EndOfMonthSalary()
        {
            return this.GetDecisionMakerBonusPay();
        }
    }
}