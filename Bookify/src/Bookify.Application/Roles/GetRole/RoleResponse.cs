using Bookify.Application.Permissions.GetPermission;

namespace Bookify.Application.Roles.GetRole;

public sealed record RoleResponse(
    int Id,
    string Name,
    List<PermissionResponse> Permissions);
