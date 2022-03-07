using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Areas.Dashboard.ViewModels
{
    public class AddRoleVm
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
        public string RoleName { get; set; }
    }
}
