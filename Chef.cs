namespace maternity_ward_system
{
    public class Chef: Employee, ISeniorEmployee, IDecisionMaker, IExpertEmployee
    {
        public double HourlyPay{get; private set;}
        public double ExpertHourlyPay{get; private set;}
        public string UniqueJobDescripition{get; private set;}
        public int MinimumMonthlyHours{get; private set;}
        public void SeniorEmployeeRaise()
        {
            HourlyPay = HourlyPay * 1.05;
        }
        public Chef(string fname, string lname, string id, int age, double hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
            SeniorEmployeeRaise();
            ExpertHourlyPay = HourlyPay * 1.3;
            UniqueJobDescripition = "The Chef of the kitchen makes choices about the food being served";
            MinimumMonthlyHours = 50;
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
            double hours = this.workInformation.HoursWorked;
            return (ExpertHourlyPay * hours) + dmsalary;
        }
    }
}