using BusinessTrip.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Statement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statement.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel modelForCreate)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = modelForCreate.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "AdministrationController");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(modelForCreate);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
            };

            foreach(var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                } 
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel modelForEdit)
        {
            var role = await roleManager.FindByIdAsync(modelForEdit.RoleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {modelForEdit.RoleId} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = modelForEdit.RoleId;
                var result = await roleManager.UpdateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(modelForEdit);
        }

        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View();
        }
    }
}
