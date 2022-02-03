using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Optima_Anbar.Models
{
    public class CustomUser : IdentityUser
    {

        public string Name { get; set; }

        public string SurName { get; set; }

        [NotMapped]
        public string RoleId { get; set; }
    }
}
