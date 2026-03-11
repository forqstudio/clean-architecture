using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Permissions.CreatePermission;

public sealed record CreatePermissionCommand(string Name) : ICommand<int>;
