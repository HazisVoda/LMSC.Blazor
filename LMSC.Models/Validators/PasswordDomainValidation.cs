using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSC.Models.Validators
{
    public class PasswordDomainValidation : ValidationAttribute
    {
        public string AllowedDomain { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            if (strings.Length > 8 && strings[1].ToUpper() == AllowedDomain.ToUpper())
            {
                return null;
            }

            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
        }
    }
}
