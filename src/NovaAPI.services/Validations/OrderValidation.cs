using FluentValidation;
using NovaAPI.Entities.Models;

namespace NovaAPI.Services.Validations
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
        }
    }
}
