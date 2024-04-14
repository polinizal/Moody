using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class MoodsController : Controller
    {
        private readonly IMoodService _moodService; 

        public MoodsController(IMoodService moodService)
        {
            _moodService = moodService;
        }

        // GET: Moods
        public async Task<IActionResult> Index()
        {
            return View(await _moodService.GetAllMoodsAsync());
        }

        // GET: Moods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await _moodService.GetMoodByIdAsync(id.Value);
            if (mood == null)
            {
                return NotFound();
            }

            return View(mood);
        }

        // GET: Moods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoodType,Id")] MoodDTO mood)
        {
            if (ModelState.IsValid)
            {
                await _moodService.CreateMoodAsync(mood);
                return RedirectToAction(nameof(Index));
            }
            //  ViewBag.Moods = Enum.GetNames(typeof(MoodType));
            return View(mood);
        }

        // GET: Moods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await _moodService.GetMoodByIdAsync(id.Value);
            if (mood == null)
            {
                return NotFound();
            }
            return View(mood);
        }

        // POST: Moods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MoodType,Id")] MoodDTO mood)
        {
            if (id != mood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _moodService.UpdateMoodAsync(mood);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoodExists(mood.Id))
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
            return View(mood);
        }

        // GET: Moods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var mood = await _moodService.GetMoodByIdAsync(id.Value);

            if (mood == null)
            {
                return NotFound();
            }

            return View(mood);
        }

        // POST: Moods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _moodService.DeleteMoodByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MoodExists(int id)
        {
            return (_moodService.GetMoodByIdAsync(id) != null);
        }
    }
}
