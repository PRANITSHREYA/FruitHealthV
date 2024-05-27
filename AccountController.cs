using FruitHealth.Areas.Identity.Data;
using FruitHealth.Models;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class AccountController : Controller
    {
        // Action to display the registration form
        public IActionResult Register()
        {
            return View();
        }

        // Action to handle form submission
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                    Email = model.Email,
                    Password = model.Password,
                };

                // Save the user to the database
                fruitHealthContext _context = new fruitHealthContext();
                _context.Users.Add(user);
                _context.SaveChanges();

                // Redirect to a different page after successful registration
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed; redisplay form.
            return View(model);
        }
    }
}
