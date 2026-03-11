using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Permissions.GetPermission;

internal sealed class GetPermissionQueryHandler(IPermissionRepository permissionRepository)
    : IQueryHandler<GetPermissionQuery, PermissionResponse>
{
    public async Task<Result<PermissionResponse>> Handle(
        GetPermissionQuery request,
        CancellationToken cancellationToken)
    {
        var permission = await permissionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (permission is null)
        {
            return Result.Failure<PermissionResponse>(PermissionErrors.NotFound);
        }

        return new PermissionResponse(permission.Id, permission.Name);
    }
}
