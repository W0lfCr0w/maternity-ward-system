namespace maternity_ward_system
{
    public class Cleaner : Employee, IMinorEmployee
    {
        private double _payRate;
        public double HourlyPay
        {
            get{ return this._payRate; }
            set
            {
                this._payRate = value;
            }
        }
        public Cleaner(string fname, string lname, string id, int age, double hours)
        {
            FirstName = fname;
            LastName = lname;
            ID = id;
            Age = age;
            this.workInformation = new WorkingHours(hours);
            HourlyPay = BasePay;
        }
        public Cleaner(string fname, string lname, string id, int age) :this(fname, lname, id, age, 0){}
        
        public override double EndOfMonthSalary()
        {
            return workInformation.HoursWorked * HourlyPay;
        }
    }
}