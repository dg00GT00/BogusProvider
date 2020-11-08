using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BogusProvider.ModelValidation
{
    public class RandomId : IValidatableObject
    {
        [Required] public int? BrandId { get; set; }
        [Required] public int? TypeId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BrandId <= 0)
            {
                yield return new ValidationResult($"The {nameof(BrandId)} must be greater than 0",
                    new[] {nameof(BrandId)});
            }
            if (TypeId <= 0)
            {
                yield return new ValidationResult($"The {nameof(TypeId)} must be greater than 0",
                    new[] {nameof(TypeId)});
            }
        }
    }
}