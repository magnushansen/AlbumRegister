namespace AlbumRegister.Models
{
    public static class ViewModelFactory
    {
        public static AlbumViewModel Details(Album p)
        {
            return new AlbumViewModel
            {
                Album = p,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                Genres = p == null || p.Genre == null
            ? Enumerable.Empty<Genre>()
            : new List<Genre> { p.Genre },
            };
        }

        public static AlbumViewModel Create(Album album, IEnumerable<Genre> genres)
        {
            return new AlbumViewModel
            {
                Album = album,
                Genres = genres
            };
        }


        public static AlbumViewModel Edit(Album album,
            IEnumerable<Genre> genres)
        {
            return new AlbumViewModel
            {
                Album = album,
                Genres = genres,
                Theme = "warning",
                Action = "Edit"
            };
        }

        public static AlbumViewModel Delete(Album p,
            IEnumerable<Genre> genres) {
            return new AlbumViewModel {
                Album = p, Action = "Delete",
                ReadOnly = true, Theme = "danger",
                Genres = genres
            };
        }
    }
}