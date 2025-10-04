namespace AlbumRegister.Models;

public class AlbumViewModel
{
    public Album Album { get; set; }
        = new() { Title = string.Empty };
    public string Action { get; set; } = "Create";
    public bool ReadOnly { get; set; } = false;
    public string Theme { get; set; } = "primary";
    public bool ShowAction { get; set; } = true;
    public IEnumerable<Genre> Genres { get; set; }
    = Enumerable.Empty<Genre>();
}
