namespace maternity_ward_system
{
    public interface IDecisionMaker : IMinorEmployee
    {
        public string UniqueJobDescripition{get; set;}
        public int MinimumMonthlyHours{get; set;}
        public double GetDecisionMakerBonusPay();

    }
}