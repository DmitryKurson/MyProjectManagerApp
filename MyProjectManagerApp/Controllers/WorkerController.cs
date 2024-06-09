using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;
using MyProjectManagerApp.Data;
using MyProjectManagerApp.Models;

namespace MyProjectManagerApp.Controllers
{
    public class WorkerController : Controller
    {
        ApplicationDbContext db;
        public WorkerController(ApplicationDbContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Worker worker)
        {
            db.workers.Add(worker);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id != null)
            {
                Worker? worker = await db.workers.FirstOrDefaultAsync(w => w.Id == id);
                if (worker != null)
                {
                    db.workers.Remove(worker);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id != null)
            {
                Worker? worker = await db.workers.FirstOrDefaultAsync(w => w.Id == id);
                if (worker != null)
                    return View(worker);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Worker worker)
        {
            db.workers.Update(worker);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index(string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            IQueryable<Worker> workers = db.workers;

            if (!string.IsNullOrEmpty(name))
            {
                workers = workers.Where(w => w.Name!.Contains(name));
            }

            workers = sortOrder switch
            {
                SortState.IdAsc => workers.OrderBy(w => w.Id),
                SortState.IdDesc => workers.OrderByDescending(w => w.Id),
                SortState.NameAsc => workers.OrderBy(w => w.Name),
                SortState.NameDesc => workers.OrderByDescending(w => w.Name),
                SortState.SurnameAsc => workers.OrderBy(w => w.Name),
                SortState.SurnameDesc => workers.OrderByDescending(w => w.Name),
                SortState.PositionAsc => workers.OrderBy(w => w.Position),
                SortState.PositionDesc => workers.OrderByDescending(w => w.Position),
                SortState.SalaryAsc => workers.OrderBy(w => w.Salary),
                SortState.SalaryDesc => workers.OrderByDescending(w => w.Salary),
                _ => workers.OrderBy(w => w.Name),
            };

            var count = await workers.CountAsync();
            var items = await workers.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            WorkerIndexViewModel viewModel = new WorkerIndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(name),
                new WorkerSortViewModel(sortOrder)
            );
            return View(viewModel);
        }
    }
}
