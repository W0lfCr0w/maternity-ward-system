namespace maternity_ward_system
{
    public class HeadOfManagement : Employee, IDecisionMaker, IManager
    {
        public double ManagerSalary{get; private set;}
        public double HourlyPay{get; private set;}
        public string UniqueJobDescripition{get; private set;}
        public int MinimumMonthlyHours{get; private set;}
        public HeadOfManagement(string fname, string lname, string id, int age, double hours, double managerSalaray)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
            ManagerSalary = managerSalaray;
        }
        public HeadOfManagement(string fname, string lname, string id, int age, double managerSalaray) 
            :this(fname, lname, id, age, managerSalaray, 0){}
        public double GetDecisionMakerBonusPay()
        {
            if(this.workInformation.HoursWorked > MinimumMonthlyHours)
                return 200 * (1.5 * HourlyPay);
            else
                return 0;
        }
        public override double EndOfMonthSalary()
        {
            return this.GetDecisionMakerBonusPay() + ManagerSalary;
        }
    }
}