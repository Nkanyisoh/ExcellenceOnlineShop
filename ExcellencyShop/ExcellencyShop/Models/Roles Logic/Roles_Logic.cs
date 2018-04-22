using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ExcellencyShop.Models;
using CustomUserRoles.Models;

namespace ExcellencyShop.Models.Roles_Logic
{
    public class Roles_Logic
    {
        private RoleManager<IdentityRole> RoleManager { get; set; }

        public Roles_Logic()
        {
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        }

        public void AddRole(string name)
        {
            if (!RoleManager.RoleExists(name))
            {
                IdentityRole role = new IdentityRole();
                role.Name = name;
                RoleManager.Create(role);
            }
        }

        public List<RoleModelView> Getall()
        {
            return RoleManager.Roles.ToList().Select(x => new RoleModelView() { Id = x.Id, Name = x.Name }).ToList();
        }



    }
}
