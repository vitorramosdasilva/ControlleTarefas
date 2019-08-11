using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TarefasTemp.Data;
using TarefasTemp.Models;

namespace TarefasTemp.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tarefaitem.ToListAsync());
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaitem = await _context.Tarefaitem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefaitem == null)
            {
                return NotFound();
            }

            return View(tarefaitem);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estacompleta,Nome,Dataconclusao")] Tarefaitem tarefaitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefaitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefaitem);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaitem = await _context.Tarefaitem.FindAsync(id);
            if (tarefaitem == null)
            {
                return NotFound();
            }
            return View(tarefaitem);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estacompleta,Nome,Dataconclusao")] Tarefaitem tarefaitem)
        {
            if (id != tarefaitem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefaitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaitemExists(tarefaitem.Id))
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
            return View(tarefaitem);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaitem = await _context.Tarefaitem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefaitem == null)
            {
                return NotFound();
            }

            return View(tarefaitem);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefaitem = await _context.Tarefaitem.FindAsync(id);
            _context.Tarefaitem.Remove(tarefaitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefaitemExists(int id)
        {
            return _context.Tarefaitem.Any(e => e.Id == id);
        }
    }
}
