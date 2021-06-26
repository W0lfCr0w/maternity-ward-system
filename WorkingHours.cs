namespace maternity_ward_system
{
    public class WorkingHours
    {
        private double _hoursWorked;
        public double HoursWorked
        {
            get { return this._hoursWorked; }
            private set
            {
                if(value < 0)
                {
                    this._hoursWorked = 0;
                }
                else
                {
                    this._hoursWorked = value;
                }
            }
        }

        public WorkingHours(double hours)
        {
            this.HoursWorked = hours;
        }
        public WorkingHours():this(0){}

        public void AddHours(double hours)
        {
            if(hours > 0) 
                HoursWorked += hours;
        }

    }
}