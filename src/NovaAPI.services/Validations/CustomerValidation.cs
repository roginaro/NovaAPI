using FluentValidation;
using NovaAPI.Entities.Models;

namespace NovaAPI.Services.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            //
        }
    }
}
