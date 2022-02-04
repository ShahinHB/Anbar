using Microsoft.AspNetCore.Identity;
using Optima_Anbar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optima_Anbar.ViewModels
{
    public class VmUserRole
    {
        public List<CustomUser> CustomUsers { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public List<IdentityUserRole<string>> UserRoles { get; set; }
    }
}
