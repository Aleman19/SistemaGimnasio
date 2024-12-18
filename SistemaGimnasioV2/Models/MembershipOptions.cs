namespace SistemaGimnasioV2.Models
{
    public class MembershipOptions
    {
        public string PlanName { get; set; } = string.Empty;
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
    }
}
