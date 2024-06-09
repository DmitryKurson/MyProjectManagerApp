using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;
using MyProjectManagerApp.Data;
using MyProjectManagerApp.Models;

namespace MyProjectManagerApp.Controllers
{
    public class ProjectController : Controller
    {
        ApplicationDbContext db;
        public ProjectController(ApplicationDbContext context)
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
        public async Task<IActionResult> Create(Project project)
        {
            db.projects.Add(project);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id != null)
            {
                Project? project = await db.projects.FirstOrDefaultAsync(p => p.Id == id);
                if (project != null)
                {
                    db.projects.Remove(project);
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
                Project? project = await db.projects.FirstOrDefaultAsync(p => p.Id == id);
                if (project != null)
                    return View(project);
            }
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Project project)
        {
            db.projects.Update(project);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index(string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            IQueryable<Project> project = db.projects;

            if (!string.IsNullOrEmpty(name))
            {
                project = project.Where(p => p.Name!.Contains(name));
            }

            project = sortOrder switch
            {
                SortState.IdAsc => project.OrderBy(s => s.Id),
                SortState.IdDesc => project.OrderByDescending(s => s.Id),
                SortState.NameAsc => project.OrderBy(s => s.Name),
                SortState.NameDesc => project.OrderByDescending(s => s.Name),
                //Description
                SortState.CreatorNameAsc => project.OrderBy(s => s.CreatorName),
                SortState.CreatorNameDesc => project.OrderByDescending(s => s.CreatorName),
                _ => project.OrderBy(s => s.Name),
            };

            var count = await project.CountAsync();
            var items = await project.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            ProjectIndexViewModel viewModel = new ProjectIndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(name),
                new ProjectSortViewModel(sortOrder)
            );
            return View(viewModel);
        }
    }
}
