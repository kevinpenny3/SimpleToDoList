using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {

            private readonly ApplicationDbContext _context;

            private readonly UserManager<ApplicationUser> _userManager;

            public ToDoItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
            {

                _context = context;
                _userManager = userManager;
            }
        // GET: ToDoItems
        public async Task<ActionResult> Index()
        {
            // getting the current user
            var user = await GetCurrentUserAsync();

            // filtering items so we only see our own and not other users
            var items = await _context.TodoItem
                .Where(ti => ti.ApplicationUserId == user.Id)
                .ToListAsync();

            return View(items);
        }

        // GET: ToDoItems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDoItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}