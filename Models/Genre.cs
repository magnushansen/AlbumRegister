using System.ComponentModel.DataAnnotations;

namespace AlbumRegister.Models;

public class Genre
{
    public int GenreId { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(30)]
    public string? GenreName { get; set; }

    public IEnumerable<Album>? Albums { get; set; }
}