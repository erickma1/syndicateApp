using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using syndicateApp.Models;

namespace syndicateApp.Controllers
{
    public class TblPostsController : Controller
    {
        private readonly SyndicatedContext _context;

        public TblPostsController(SyndicatedContext context)
        {
            _context = context;
        }

        // GET: TblPosts
        public async Task<IActionResult> Index()
        {
              return _context.TblPosts != null ? 
                          View(await _context.TblPosts.ToListAsync()) :
                          Problem("Entity set 'SyndicatedContext.TblPosts'  is null.");
        }

        // GET: TblPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblPosts == null)
            {
                return NotFound();
            }

            var tblPost = await _context.TblPosts
                .FirstOrDefaultAsync(m => m.IdNo == id);
            if (tblPost == null)
            {
                return NotFound();
            }

            return View(tblPost);
        }

        // GET: TblPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNo,PostCategory,PostText,PostImage,IsActive,MetaData")] TblPost tblPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPost);
        }

        // GET: TblPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblPosts == null)
            {
                return NotFound();
            }

            var tblPost = await _context.TblPosts.FindAsync(id);
            if (tblPost == null)
            {
                return NotFound();
            }
            return View(tblPost);
        }

        // POST: TblPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNo,PostCategory,PostText,PostImage,IsActive,MetaData")] TblPost tblPost)
        {
            if (id != tblPost.IdNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPostExists(tblPost.IdNo))
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
            return View(tblPost);
        }

        // GET: TblPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblPosts == null)
            {
                return NotFound();
            }

            var tblPost = await _context.TblPosts
                .FirstOrDefaultAsync(m => m.IdNo == id);
            if (tblPost == null)
            {
                return NotFound();
            }

            return View(tblPost);
        }

        // POST: TblPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblPosts == null)
            {
                return Problem("Entity set 'SyndicatedContext.TblPosts'  is null.");
            }
            var tblPost = await _context.TblPosts.FindAsync(id);
            if (tblPost != null)
            {
                _context.TblPosts.Remove(tblPost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPostExists(int id)
        {
          return (_context.TblPosts?.Any(e => e.IdNo == id)).GetValueOrDefault();
        }
    }
}
