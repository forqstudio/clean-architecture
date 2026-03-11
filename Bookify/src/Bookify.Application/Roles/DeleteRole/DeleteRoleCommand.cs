using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Roles.DeleteRole;

public sealed record DeleteRoleCommand(int Id) : ICommand;
