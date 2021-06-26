namespace maternity_ward_system
{
    public class InternWithBreechSpecialty: Intern, IExpertEmployee
    {
        public double ExpertHourlyPay{get; private set;}
        public InternWithBreechSpecialty(string fname, string lname, string id, int age, double hours)
            :base(fname, lname, id, age, hours)
        {
            ExpertHourlyPay = BasePay * 1.3 ;
        }
        public InternWithBreechSpecialty(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        public override double EndOfMonthSalary()
        {
            return ExpertHourlyPay * this.workInformation.HoursWorked;
        }
        
    }
}