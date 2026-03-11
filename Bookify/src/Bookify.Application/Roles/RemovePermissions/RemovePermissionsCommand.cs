using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Roles.RemovePermissions;

public sealed record RemovePermissionsCommand(
    int RoleId,
    List<int> PermissionIds) : ICommand;
