namespace KitchenRouter.Domain.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? DeletedAt { get; init; }
        public bool IsDeleted { get; init; }
        public byte[]? RowVersion { get; init; }
    }
}
