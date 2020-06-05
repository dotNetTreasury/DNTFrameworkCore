using System;
using DNTFrameworkCore.Application;

namespace DNTFrameworkCore.TestAPI.Application.Identity.Models
{
    public class UserReadModel : ReadModel<long>
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastLoggedInDateTime { get; set; }
    }
}