using Bookify.Domain.Users;
using FluentValidation;

namespace Bookify.Application.Permissions.CreatePermission;

internal sealed class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(Permission.NameMaxLength)
            .Matches(Permission.NameRegexPattern)
            .WithMessage(Permission.NameFormatMessage);
    }
}
