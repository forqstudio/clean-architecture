namespace Bookify.Api.Controllers.Roles;

public sealed record RemovePermissionsRequest(List<int> PermissionIds);
