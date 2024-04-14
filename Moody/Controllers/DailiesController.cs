using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using java.security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moody.Data;
using Moody.Data.Data;
using Moody.Services.DTOs;
using Moody.Services.Services.Abstractions;

namespace Moody.Controllers
{
    [Authorize]
    public class DailiesController : Controller
    {
        private readonly IDailyService _dailyService;
        private readonly IMoodService _moodService;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public DailiesController(IDailyService dailyService, IMoodService moodService, IUserService userService, UserManager<IdentityUser> userManager)
        {
            _dailyService = dailyService;
            _moodService = moodService;
            _userService = userService;
            _userManager = userManager;
        }

        // GET: Dailies
        public async Task<IActionResult> Index()
        {
            var current = await _userManager.GetUserAsync(User);
            if (current != null)
            {
                return View(await _dailyService.GetAllDailiesByUserAsync(current.Id));
            }
            else
            {
                return View(new List<DailyDTO>());
            }
        }

        // GET: Dailies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
        {
            return NotFound();
        }

        var daily = await _dailyService.GetDailyByIdAsync(id.Value);
        if (daily == null)
        {
            return NotFound();
        }

        return View(daily);
        }

        // GET: Dailies/Create
        public async Task<IActionResult> Create()
        {
            var daily = new DailyDTO();
            daily.CreationDate = DateTime.Today;
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            daily.UserId = currentUserId;
            ViewBag.Moods = new SelectList(await _moodService.GetAllMoodsAsync(), "Id", "MoodType");
            return View(daily);
        }

        // POST: Dailies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreationDate,MoodId,UserId,Note,Id")] DailyDTO daily)
        {
            if (ModelState.IsValid)
            {
                // Set CreationDate to current date and UserId to current user's Id
                daily.CreationDate = DateTime.Today;
                string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                daily.UserId = currentUserId;

                // Create the daily
                await _dailyService.CreateDailyAsync(daily);

                // Redirect to the index action
                return RedirectToAction(nameof(Index));
            }

            // If model state is not valid, reload the view with the ViewBag properties and the invalid DailyDTO object
           
            ViewBag.Moods = new SelectList(await _moodService.GetAllMoodsAsync(), "Id", "MoodType");
           
            return View(daily);
        }


        // GET: Dailies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily = await _dailyService.GetDailyByIdAsync(id.Value);

            string currentUserId = daily.UserId;
            daily.UserId = currentUserId;
            ViewBag.Moods = new SelectList(await _moodService.GetAllMoodsAsync(), "Id", "MoodType");
            if (daily == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", daily.UserId);
            return View(daily);
        }

        // POST: Dailies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreationDate,MoodId,UserId,Note,Id")] DailyDTO daily)
        {
            if (id != daily.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    string currentUserId = daily.UserId;
                    daily.UserId = currentUserId;
                    ViewBag.Moods = new SelectList(await _moodService.GetAllMoodsAsync(), "Id", "MoodType");
                    await _dailyService.UpdateDailyAsync(daily);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyExists(daily.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", daily.UserId);
            return View(daily);
        }

        // GET: Dailies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily = await _dailyService.GetDailyByIdAsync(id.Value);
            if (daily == null)
            {
                return NotFound();
            }

            return View(daily);
        }

        // POST: Dailies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dailyService.DeleteDailyByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DailyExists(int id)
        {
            return (_dailyService.GetDailyByIdAsync(id) != null);
        }
    }
}
