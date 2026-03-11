using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Permissions.DeletePermission;

public sealed record DeletePermissionCommand(int Id) : ICommand;
