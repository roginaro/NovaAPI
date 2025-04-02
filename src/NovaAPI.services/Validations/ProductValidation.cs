using FluentValidation;
using NovaAPI.Entities.Models;

namespace NovaAPI.Services.Validations
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {
            //RuleFor(x => x.ProductId)
            //    .NotEqual(0)
            //    .WithMessage("Bisonho informe o codigo do produto");
           RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Bisonho informe o nome do produto");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Bisonho informe a descrição do produto");
            RuleFor(x => x.Price)
                .NotEqual(0)
                .WithMessage("Bisonho informe o preço do produto");
            RuleFor(x => x.Image)
                .Must(x=> ValidateImage(x))
                .WithMessage("Bisonho informe uma imagem válida");
        }
        private bool ValidateImage(string image)
        {
            FileInfo fileInfo = new FileInfo(image);
            if (!Directory.Exists(fileInfo.DirectoryName))
            {
                return false;
            }
            if (fileInfo.Extension != ".jpg" )
            {
                return false;
            }
            return true;
        }
    }
}
