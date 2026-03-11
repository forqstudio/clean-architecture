using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Permissions.GetPermission;
using Bookify.Application.Roles.GetRole;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Roles.GetRoles;

internal sealed class GetRolesQueryHandler(IRoleRepository roleRepository)
    : IQueryHandler<GetRolesQuery, IReadOnlyList<RoleResponse>>
{
    public async Task<Result<IReadOnlyList<RoleResponse>>> Handle(
        GetRolesQuery request,
        CancellationToken cancellationToken)
    {
        var roles = await roleRepository.GetAllAsync(cancellationToken);

        var response = roles
            .Select(r => new RoleResponse(
                r.Id,
                r.Name,
                r.Permissions.Select(p => new PermissionResponse(p.Id, p.Name)).ToList()))
            .ToList();

        return response;
    }
}
