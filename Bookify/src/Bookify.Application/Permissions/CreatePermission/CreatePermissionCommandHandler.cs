using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Permissions.CreatePermission;

internal sealed class CreatePermissionCommandHandler(
    IPermissionRepository permissionRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePermissionCommand, int>
{
    public async Task<Result<int>> Handle(
        CreatePermissionCommand request,
        CancellationToken cancellationToken)
    {
        if (!Permission.IsValidName(request.Name))
        {
            return Result.Failure<int>(PermissionErrors.InvalidName);
        }

        var existingPermission = await permissionRepository.GetByNameAsync(request.Name, cancellationToken);
        if (existingPermission is not null)
        {
            return Result.Failure<int>(PermissionErrors.AlreadyExists);
        }

        var permission = Permission.Create(0, request.Name);

        permissionRepository.Add(permission);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return permission.Id;
    }
}
