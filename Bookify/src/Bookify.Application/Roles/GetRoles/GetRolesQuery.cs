using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Roles.GetRole;

namespace Bookify.Application.Roles.GetRoles;

public sealed record GetRolesQuery : IQuery<IReadOnlyList<RoleResponse>>;
