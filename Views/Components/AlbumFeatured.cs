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
<<<<<<< HEAD
        Album? a = Albums.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
=======
        Album a = Albums.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
>>>>>>> ac9fe7a0687e27010614de81d6bb42a5fa42c127
        return View("/Views/Shared/_AlbumSummary.cshtml", a);
    }
}