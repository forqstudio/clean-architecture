using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Permissions.GetPermission;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Permissions.GetPermissions;

internal sealed class GetPermissionsQueryHandler(IPermissionRepository permissionRepository)
    : IQueryHandler<GetPermissionsQuery, IReadOnlyList<PermissionResponse>>
{
    public async Task<Result<IReadOnlyList<PermissionResponse>>> Handle(
        GetPermissionsQuery request,
        CancellationToken cancellationToken)
    {
        var permissions = await permissionRepository.GetAllAsync(cancellationToken);

        var response = permissions
            .Select(p => new PermissionResponse(p.Id, p.Name))
            .ToList();

        return response;
    }
}
