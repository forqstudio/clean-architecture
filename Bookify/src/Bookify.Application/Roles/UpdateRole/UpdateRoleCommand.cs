using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Roles.UpdateRole;

public sealed record UpdateRoleCommand(
    int Id,
    string Name,
    List<int> PermissionIds) : ICommand;
