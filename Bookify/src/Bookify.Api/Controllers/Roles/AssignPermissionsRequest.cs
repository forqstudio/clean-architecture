namespace Bookify.Api.Controllers.Roles;

public sealed record AssignPermissionsRequest(List<int> PermissionIds);
