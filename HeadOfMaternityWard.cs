namespace maternity_ward_system
{
    public class HeadOfMaternityWard: ViceHeadOfMaternitiyWard, IRiskFactorEmployee
    {
        public double RiskFactorBonus{get; private set;}
        public HeadOfMaternityWard(string fname, string lname, string id, int age, double hours, double managerSalaray)
            :base(fname, lname, id, age, hours, managerSalaray)
            {
                RiskFactorBonus = 2.0;
                MyEmployeeType = EmployeeType.HeadOfWard.ToString();
            }
        public HeadOfMaternityWard(string fname, string lname, string id, int age, double managerSalaray)
            :this(fname, lname, id, age, 0, managerSalaray){}
        
        public override double EndOfMonthSalary()
        {
            return base.EndOfMonthSalary() * RiskFactorBonus;
        }
        
    }
}