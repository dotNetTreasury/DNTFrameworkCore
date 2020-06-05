using System.Collections.Generic;
using DNTFrameworkCore.Common;
using DNTFrameworkCore.TestWebApp.Application.Identity.Models;

namespace DNTFrameworkCore.TestWebApp.Models.Users
{
    // public class UserModalViewModel : UserModel
    // {
    //     public IReadOnlyList<LookupItem<long>> RoleList { get; set; }
    // }

    public class UserModalViewModel
    {
        public UserModel Model { get; set; }
        public IReadOnlyList<LookupItem<long>> Roles { get; set; }
    }
}