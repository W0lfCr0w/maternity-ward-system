namespace maternity_ward_system
{
    public class SeniorDoctor: Doctor, IDecisionMaker
    {
        public string UniqueJobDescripition{get; protected set;}
        public int MinimumMonthlyHours{get; protected set;}
        public SeniorDoctor(string fname, string lname, string id, int age, double hours) :base(fname, lname, id, age, hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
            SeniorEmployeeRaise();
            MinimumMonthlyHours = 50;
            UniqueJobDescripition = "Senior Doctor can override a Doctor's decision about a patient";
        }
        public SeniorDoctor(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public double GetDecisionMakerBonusPay()
        {
            if(this.workInformation.HoursWorked > MinimumMonthlyHours)
                return 200 * (1.5 * HourlyPay);
            else
                return 0;
        }
        public override double EndOfMonthSalary()
        {
            return base.EndOfMonthSalary() + this.GetDecisionMakerBonusPay();
        }
    }
}