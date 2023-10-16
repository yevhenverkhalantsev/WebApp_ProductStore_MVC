using FluentValidation;

namespace oblig1_Yevhen_Verkhalantsev.Services.CategoryServices.Models;

public class CreateCategoryHttpPostModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class CreateCategoryHttpPostValidator : AbstractValidator<CreateCategoryHttpPostModel>
{
    public CreateCategoryHttpPostValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(4)
            .MaximumLength(100)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Description)
            .MinimumLength(4)
            .MaximumLength(500)
            .NotNull()
            .NotEmpty();
    }
}