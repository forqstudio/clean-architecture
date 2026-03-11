using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Permissions.UpdatePermission;

public sealed record UpdatePermissionCommand(int Id, string Name) : ICommand;
