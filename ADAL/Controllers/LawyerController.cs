using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADAL.Data;
using ADAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace ADAL.Controllers
{
    public class LawyerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LawyerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Lawyer,Admin")]

        // GET: Lawyer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lawyers.ToListAsync());
        }

        [Authorize(Roles = "Admin")]

        // GET: Lawyer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyerModel = await _context.Lawyers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawyerModel == null)
            {
                return NotFound();
            }

            return View(lawyerModel);
        }

        [Authorize(Roles = "Admin")]

        // GET: Lawyer/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]

        // POST: Lawyer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email")] LawyerModel lawyerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lawyerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lawyerModel);
        }

        [Authorize(Roles = "Admin")]

        // GET: Lawyer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyerModel = await _context.Lawyers.FindAsync(id);
            if (lawyerModel == null)
            {
                return NotFound();
            }
            return View(lawyerModel);
        }

        [Authorize(Roles = "Admin")]

        // POST: Lawyer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email")] LawyerModel lawyerModel)
        {
            if (id != lawyerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lawyerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LawyerModelExists(lawyerModel.Id))
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
            return View(lawyerModel);
        }

        [Authorize(Roles = "Admin")]

        // GET: Lawyer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyerModel = await _context.Lawyers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawyerModel == null)
            {
                return NotFound();
            }

            return View(lawyerModel);
        }

        [Authorize(Roles = "Admin")]

        // POST: Lawyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lawyerModel = await _context.Lawyers.FindAsync(id);
            if (lawyerModel != null)
            {
                _context.Lawyers.Remove(lawyerModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LawyerModelExists(int id)
        {
            return _context.Lawyers.Any(e => e.Id == id);
        }
    }
}
