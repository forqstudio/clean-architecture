using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Permissions.GetPermission;

public sealed record GetPermissionQuery(int Id) : IQuery<PermissionResponse>;
