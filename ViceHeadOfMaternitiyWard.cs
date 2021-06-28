namespace maternity_ward_system
{
    public class ViceHeadOfMaternitiyWard: Employee, IManager, IDecisionMaker
    {
        public double HourlyPay{get; protected set;}
        public double ManagerSalary{get; protected set;}
        public string UniqueJobDescripition{get; protected set;}
        public int MinimumMonthlyHours{get; protected set;}
        public ViceHeadOfMaternitiyWard(string fname, string lname, string id, int age, double hours, double managerSalaray)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
            MinimumMonthlyHours = 50;
            UniqueJobDescripition = "The Vice has complete control when the Head of the ward is not around";
            ManagerSalary = managerSalaray;
            MyEmployeeType = EmployeeType.ViceHeadOfWard.ToString();
        }
        public ViceHeadOfMaternitiyWard(string fname, string lname, string id, int age, double managerSalaray)
            :this(fname, lname, id, age, 0, managerSalaray){}
        
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