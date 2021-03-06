﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;
using ToDo.Models.ViewModels;

namespace ToDo.Controllers
{
    public class TodoItemsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public TodoItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: TodoItems
        public async Task<ActionResult> Index()
        {


            // getting the current user
            var user = await GetCurrentUserAsync();

            // filtering items so we only see our own and not other users
            var items = await _context.TodoItem
                .Where(ti => ti.ApplicationUserId == user.Id)
                .Include(ti => ti.ToDoStatus)
                .ToListAsync();

            return View(items);
        }

        // GET: TodoItems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoItems/Create
        public async Task<ActionResult> Create()
        {
            var ToDoStatuses = await _context.ToDoStatus
                 .Select(td => new SelectListItem() { Text = td.Title, Value = td.Id.ToString() })
                 .ToListAsync();

            var viewModel = new ToDoItemStatusViewModel();

            viewModel.StatusOptions = ToDoStatuses;

            return View(viewModel);
        }

        // POST: TodoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoItemStatusViewModel todoViewItem)
        {
            try
            {
                var todoItem = new ToDoItem
                {
                    Title = todoViewItem.Title,
                    ToDoStatusId = todoViewItem.TodoStatusId

                };

                var user = await GetCurrentUserAsync();
                todoItem.ApplicationUserId = user.Id;

                _context.TodoItem.Add(todoItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoItems/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var item = await _context.TodoItem.FirstOrDefaultAsync(ti => ti.Id == id);
            var loggedInUser = await GetCurrentUserAsync();


            var TodoStatuses = await _context.ToDoStatus
                .Select(td => new SelectListItem() { Text = td.Title, Value = td.Id.ToString() })
                .ToListAsync();

            var viewModel = new ToDoItemStatusViewModel()
            {
                Id = id,
                Title = item.Title,
                TodoStatusId = item.ToDoStatusId,
                StatusOptions = TodoStatuses,

            };

            if (item.ApplicationUserId != loggedInUser.Id)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: TodoItems/Edit/5
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

        // GET: TodoItems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoItems/Delete/5
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