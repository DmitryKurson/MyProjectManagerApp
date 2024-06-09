using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;
using MyProjectManagerApp.Data;
using MyProjectManagerApp.Models;
using Task = MyProjectManagerApp.Models.Task;

namespace MyProjectManagerApp.Controllers
{
    public class TaskController : Controller
    {
        ApplicationDbContext db;
        public TaskController(ApplicationDbContext context)
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
        public async Task<IActionResult> Create(Task task)
        {
            db.tasks.Add(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id != null)
            {
                Task? task = await db.tasks.FirstOrDefaultAsync(t => t.Id == id);
                if (task != null)
                {
                    db.tasks.Remove(task);
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
                Task? task = await db.tasks.FirstOrDefaultAsync(t => t.Id == id);
                if (task != null)
                    return View(task);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Task task)
        {
            db.tasks.Update(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index(string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            IQueryable<Task> tasks = db.tasks;

            if (!string.IsNullOrEmpty(name))
            {
                tasks = tasks.Where(t => t.Name!.Contains(name));
            }

            tasks = sortOrder switch
            {
                SortState.IdAsc => tasks.OrderBy(t => t.Id),
                SortState.IdDesc => tasks.OrderByDescending(t => t.Id),
                SortState.NameAsc => tasks.OrderBy(t => t.Name),
                SortState.NameDesc => tasks.OrderByDescending(t => t.Name),
                SortState.WorkerNameAsc => tasks.OrderBy(t => t.WorkerName),
                SortState.WorkerNameDesc => tasks.OrderByDescending(t => t.WorkerName),
                SortState.TimeAsc => tasks.OrderBy(t => t.Time),
                SortState.TimeDesc => tasks.OrderByDescending(t => t.Time),

                _ => tasks.OrderBy(t => t.Name),
            };

            var count = await tasks.CountAsync();
            var items = await tasks.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            TaskIndexViewModel viewModel = new TaskIndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(name),
                new TaskSortViewModel(sortOrder)
            );
            return View(viewModel);
        }
    }
}
