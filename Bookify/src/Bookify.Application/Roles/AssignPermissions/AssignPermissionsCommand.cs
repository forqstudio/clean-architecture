using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Roles.AssignPermissions;

public sealed record AssignPermissionsCommand(
    int RoleId,
    List<int> PermissionIds) : ICommand;
