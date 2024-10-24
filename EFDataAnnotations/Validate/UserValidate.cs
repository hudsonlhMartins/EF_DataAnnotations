using EFDataAnnotations.Communications.Requests;
using FluentValidation;

namespace EFDataAnnotations.Validate;

public class UserValidate : AbstractValidator<CreateUser>
{
    public UserValidate()
    {
        RuleFor(user => user.Email).NotEmpty().EmailAddress();
        RuleFor(user => user.Name).NotEmpty().MinimumLength(3);
        RuleFor(user => user.Password).NotEmpty().MinimumLength(6);
    }
}