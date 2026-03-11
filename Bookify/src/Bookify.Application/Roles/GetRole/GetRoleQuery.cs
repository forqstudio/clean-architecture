using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Roles.GetRole;

public sealed record GetRoleQuery(int Id) : IQuery<RoleResponse>;
