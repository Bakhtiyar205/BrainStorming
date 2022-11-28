using static BrainStorming.Enums.StatusEnum;

namespace BrainStorming.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string? ContractNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status PolicyStatus { get; set; }
        public string? Person { get; set; }
    }
}
