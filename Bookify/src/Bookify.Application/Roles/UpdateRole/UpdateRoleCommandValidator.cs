using Bookify.Domain.Users;
using FluentValidation;

namespace Bookify.Application.Roles.UpdateRole;

internal sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(c => c.Id).GreaterThan(0);

        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(Role.NameMaxLength);

        RuleFor(c => c.PermissionIds)
            .NotNull();
    }
}
