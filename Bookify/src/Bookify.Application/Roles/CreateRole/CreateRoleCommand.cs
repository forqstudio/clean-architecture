using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Roles.CreateRole;

public sealed record CreateRoleCommand(
    string Name,
    List<int> PermissionIds) : ICommand<int>;
