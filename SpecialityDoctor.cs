namespace maternity_ward_system
{
    public class SpecialityDoctor: SeniorDoctor, IExpertEmployee
    {
        public double ExpertHourlyPay{get; private set;}
        public SpecialityDoctor(string fname, string lname, string id, int age, double hours)
            :base(fname, lname, id, age, hours)
            {
                ExpertHourlyPay = 1.3 * base.HourlyPay;
            }
        public SpecialityDoctor(string fname, string lname, string id, int age)
            :this(fname, lname, id, age, 0){}

        public override double EndOfMonthSalary()
        {
            double dmsalary = base.GetDecisionMakerBonusPay();
            double hours =  this.workInformation.HoursWorked;
            return dmsalary + hours * ExpertHourlyPay;
        }
    }
}