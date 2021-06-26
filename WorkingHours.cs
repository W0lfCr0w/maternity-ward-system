namespace maternity_ward_system
{
    public class WorkingHours
    {
        private double _hoursWorked;
        protected double HoursWorked
        {
            get { return this._hoursWorked; }
            set
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

    }
}