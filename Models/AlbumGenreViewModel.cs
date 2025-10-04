using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AlbumRegister.Models;

public class AlbumGenreViewModel
{
    public List<Album>? Albums { get; set; }
    public SelectList? Genres { get; set; }
    public string? AlbumGenre { get; set; }
    public string? SearchString { get; set; }

    public PagingInfo PagingInfo { get; set; } = new();
}