using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Permissions.GetPermission;

namespace Bookify.Application.Permissions.GetPermissions;

public sealed record GetPermissionsQuery : IQuery<IReadOnlyList<PermissionResponse>>;
