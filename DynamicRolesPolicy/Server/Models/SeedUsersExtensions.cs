using DynamicRolesPolicy.Server.Data;

namespace DynamicRolesPolicy.Server.Models;

static class SeedUsersExtensions
{
    internal static SeedUser[] GetSeedUsers(this ApplicationDbContext _) => SeedUsers;
    internal static SeedUser[] SeedUsers = new SeedUser[]
         {
            new SeedUser(
                Id: "2c023b39-c33c-4a00-b2f5-78c136d06538",
                UserName: "serenity@serenity.com",
                PasswordHash: "AQAAAAEAACcQAAAAEMGL4pVWII0L3VNAVVYPHu355/Yu03sLtrRuSL2YUAphaKCxLklYopQfw8dB0KMeng==",
                SecurityStamp: "WGCHLMIS3OQTFZQGWROFINX7H5SJFVFO"),
            new SeedUser(
                Id: "30cfa766-bd0a-4c51-b993-0a920bae840b",
                UserName: "cruz@cruz.com",
                PasswordHash: "AQAAAAEAACcQAAAAEPAHB8DFKf/FN1ZDdakuGj8R26fVvxvAEXmh7mnwMDbZ9JGsCs2LWdgXd2G2vl2Yww==",
                SecurityStamp: "IQ22XYGXRSOVNFANWBEBENQRSJWIVYYA"),
            new SeedUser(
                Id: "381bf67f-5b97-461e-b219-9d1e00915a2b",
                UserName: "tyler@tyler.com",
                PasswordHash: "AQAAAAEAACcQAAAAEGaCG8YPurptXeaVi8qUWuOtZiIkgHipQOVNEKPqcUBw0waUJvlYCap2pEOT5O9KwA==",
                SecurityStamp: "J7FNK2P73722AXWB67TSMYC5D6BZZCFD"),
            new SeedUser(
                Id: "ea5c3a35-54b0-4e97-b333-621b61efa340",
                UserName: "abigail@abigail.com",
                PasswordHash: "AQAAAAEAACcQAAAAEFxIhB4Lpw1IcAqc7MgyQviDQ1LISPx0m1nN+ILn3IesP/ei0L/8JmzuowbEHPj3JQ==",
                SecurityStamp: "HRD6JI2RRXLFQS3HU7BXBDNTVWQM2M6I"),
            new SeedUser(
                Id: "fe85d469-a528-4608-bc64-68fc473760f0",
                UserName: "brian@brian.com",
                PasswordHash: "AQAAAAEAACcQAAAAEOfWy0Ly3Ja7pkp102fveMhB1XEe9/ml78/POeZxM/KlAfW+dJanQDXnRQcP9+cJ1Q==",
                SecurityStamp: "ZI5MWHJOT6GYRRC3ULTMTBKBHQKR3T5B"),
         };
    internal static SeedRole[] GetSeedRoles(this ApplicationDbContext _) => SeedRoles;
    internal static SeedRole[] SeedRoles = new SeedRole[]
    {
        new SeedRole(Id:"1acbb826-92d7-4ae8-9ffb-39f54d73751e",Name:"Administrator"),
        new SeedRole(Id:"2e5be973-8c9c-4367-b8d2-06b98dc269d8",Name:"Moderator"),
        new SeedRole(Id:"6c74fd23-e927-4f37-bbc6-2f70eb4716dd",Name:"TenantAdministrator"),
    };
    internal static SeedUserRole[] GetSeedUserRoles(this ApplicationDbContext _) => SeedUserRoles;
    internal static SeedUserRole[] SeedUserRoles = new SeedUserRole[]
    {
        new SeedUserRole(UserId:"2c023b39-c33c-4a00-b2f5-78c136d06538", RoleId:"6c74fd23-e927-4f37-bbc6-2f70eb4716dd"),
        new SeedUserRole(UserId:"30cfa766-bd0a-4c51-b993-0a920bae840b", RoleId:"2e5be973-8c9c-4367-b8d2-06b98dc269d8"),
        new SeedUserRole(UserId:"381bf67f-5b97-461e-b219-9d1e00915a2b", RoleId:"6c74fd23-e927-4f37-bbc6-2f70eb4716dd"),
        new SeedUserRole(UserId:"381bf67f-5b97-461e-b219-9d1e00915a2b", RoleId:"2e5be973-8c9c-4367-b8d2-06b98dc269d8"),
        new SeedUserRole(UserId:"ea5c3a35-54b0-4e97-b333-621b61efa340", RoleId:"2e5be973-8c9c-4367-b8d2-06b98dc269d8"),
        new SeedUserRole(UserId:"fe85d469-a528-4608-bc64-68fc473760f0", RoleId:"1acbb826-92d7-4ae8-9ffb-39f54d73751e"),
    };

}
