using FluentValidation;
using NovaAPI.Entities.Models;

namespace NovaAPI.Services.Validations
{
    public class OrderProductValidation : AbstractValidator<OrderProduct>
    {
        public OrderProductValidation()
        {
        }
    }
}
