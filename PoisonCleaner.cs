namespace maternity_ward_system
{
    public class PoisonCleaner : Employee, IExpertEmployee, IDecisionMaker, IRiskFactorEmployee
    {
        public double ExpertHourlyPay{get; private set;}
        public double HourlyPay{get; private set;}
        public double RiskFactorBonus{get; private set;}
        public string UniqueJobDescripition{get; private set;}
        public int MinimumMonthlyHours{get; private set;}
        public PoisonCleaner(string fname, string lname, string id, int age, double hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
            ExpertHourlyPay = 1.3 * BasePay;
            RiskFactorBonus = 1.2;
            UniqueJobDescripition = "Specialises in cleaning poison";
            MinimumMonthlyHours = 50;
        }
        public PoisonCleaner(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public double GetDecisionMakerBonusPay()
        {
            if(this.workInformation.HoursWorked > this.MinimumMonthlyHours)
                return 200 * (1.5 * HourlyPay);
            else
                return 0;
        }
        public override double EndOfMonthSalary()
        {
            double dmsalary = this.GetDecisionMakerBonusPay();
            double hours = this.workInformation.HoursWorked;
            return (RiskFactorBonus * ( dmsalary + ExpertHourlyPay * hours));
        }
    }
}