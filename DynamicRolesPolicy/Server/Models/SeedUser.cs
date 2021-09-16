namespace DynamicRolesPolicy.Server.Models;

record SeedUser(string Id, string UserName, string PasswordHash, string SecurityStamp);
record SeedRole(string Id, string Name);
record SeedUserRole(string UserId, string RoleId);