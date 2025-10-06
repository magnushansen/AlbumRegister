using Microsoft.AspNetCore.Mvc;
using AlbumRegister.Models;
using AlbumRegister.Data;

namespace AlbumRegister.Components;

public class AlbumFeatured : ViewComponent
{
    private AlbumContext context;

    public AlbumFeatured(AlbumContext ctx)
    {
        context = ctx;
    }

    public IViewComponentResult Invoke()
    {
        var Albums = (IEnumerable<Album>)context.Albums;
        Album? a = Albums.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        return View("/Views/Shared/_AlbumSummary.cshtml", a);
    }
}