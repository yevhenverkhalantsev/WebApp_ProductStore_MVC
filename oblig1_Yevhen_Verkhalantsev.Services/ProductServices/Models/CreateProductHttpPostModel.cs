using FluentValidation;

namespace oblig1_Yevhen_Verkhalantsev.Services.ProductServices.Models;

public class CreateProductHttpPostModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public long ProducerId { get; set; }
    public long CategoryId { get; set; }
    
}

public class CreateProductHttpPostValidator : AbstractValidator<CreateProductHttpPostModel>
{
    public CreateProductHttpPostValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(200)
            .NotEmpty()
            .NotNull();
        
        RuleFor(x=>x.Description)
            .MinimumLength(3)
            .MaximumLength(200)
            .NotEmpty()
            .NotNull();
        
        RuleFor(x=>x.Price)
            .GreaterThan(0);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0);
        
        RuleFor(x => x.ProducerId)
            .GreaterThan(0);

    }
}