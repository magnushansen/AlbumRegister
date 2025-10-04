using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AlbumRegister.Data;
using Microsoft.EntityFrameworkCore;

namespace AlbumRegister.Models;

public class Album
{
    public int AlbumId { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Artist { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Group { get; set; }

    [Required]
    [Range(1, long.MaxValue, ErrorMessage = "Please select a genre")]
    public long GenreId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Genre? Genre { get; set; }

    public bool isShown { get; set; } = true;
}