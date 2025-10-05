using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlbumRegister.Models;
using AlbumRegister.Data;
using Microsoft.EntityFrameworkCore;

namespace AlbumRegister.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private AlbumContext context;
    private IEnumerable<Genre> genres => context.Genres;
    public int PageSize = 10;

    public HomeController(ILogger<HomeController> logger, AlbumContext data)
    {
        _logger = logger;
        context = data;
    }

    public IActionResult Album(string albumGenre, string searchString, int albumPage = 1)
    {
        var albums = context.Albums.Include(a => a.Genre).AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            albums = albums.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
        }

        if (!string.IsNullOrEmpty(albumGenre))
        {
            albums = albums.Where(x => x.Genre!.GenreName == albumGenre);
        }

        albums = albums.Where(a => a.IsShown);

        var totalItems = albums.Count();

        var albumGenreVM = new AlbumGenreViewModel
        {
            Genres = new SelectList(genres, "GenreName", "GenreName"),
            Albums = albums
                .OrderBy(p => p.AlbumId)
                .Skip((albumPage - 1) * PageSize)
                .Take(PageSize)
                .ToList(),
            AlbumGenre = albumGenre,
            SearchString = searchString,
            PagingInfo = new PagingInfo
            {
                CurrentPage = albumPage,
                ItemsPerPage = PageSize,
                TotalItems = totalItems
            }
        };

        return View(albumGenreVM);
    }



    public async Task<IActionResult> Details(int id)
    {
        Album? a = await context.Albums
            .Include(c => c.Genre)
            .FirstOrDefaultAsync(m => m.AlbumId == id)
            ?? new() { Title = string.Empty };
        AlbumViewModel model = ViewModelFactory.Details(a);
        return View("AlbumEditor", model);
    }



    public IActionResult Create()
    {
        return View("AlbumEditor",
            ViewModelFactory.Create(new() { Title = string.Empty }, genres));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
    [FromForm] Album album)
    {
        if (ModelState.IsValid)
        {
            album.AlbumId = default;
            album.Genre = default;
            context.Albums.Add(album);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Album));
        }
        return View("AlbumEditor",
            ViewModelFactory.Create(album, genres));
    }


    public async Task<IActionResult> Edit(int id) {
        Album? p = await context.Albums.FindAsync(id);
        if (p != null) {
            AlbumViewModel model =
            ViewModelFactory.Edit(p, genres);
            return View("AlbumEditor", model);
        }
        return NotFound();
        }

    [HttpPost]
    public async Task<IActionResult> Edit(
            [FromForm] Album album) {
        if (ModelState.IsValid) {
            album.Genre = default;
            context.Albums.Update(album);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Album));
        }
        return View("AlbumEditor",
            ViewModelFactory.Edit(album, genres));
    }


    public async Task<IActionResult> Delete(int id) {
        Album? p = await context.Albums.FindAsync(id);
        if (p != null) {
            AlbumViewModel model = ViewModelFactory.Delete(
                p, genres);
            return View("AlbumEditor", model);
        }
        return NotFound();
        }

    [HttpPost]
    public async Task<IActionResult> Delete(Album album) {
        context.Albums.Remove(album);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Album));
        }


    public async Task<IActionResult> Index()
    {
        var albums = await context.Albums.ToListAsync();
        var viewModel = new AlbumGenreViewModel
        {
            Albums = albums
        };
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
