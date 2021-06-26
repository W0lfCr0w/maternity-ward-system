namespace maternity_ward_system
{
    public interface IDecisionMaker : IMinorEmployee
    {
        public string UniqueJobDescripition{get;}
        public int MinimumMonthlyHours{get; }
        public double GetDecisionMakerBonusPay();

    }
}