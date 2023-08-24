using FluentValidation;
using FluentValidation.Results;

namespace KitchenRouter.Domain.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? DeletedAt { get; init; }
        public bool IsDeleted { get; init; }
        public byte[]? RowVersion { get; init; }
        public bool Valid { get; protected set; }
        public bool Invalid => !Valid;
        public ValidationResult? ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
