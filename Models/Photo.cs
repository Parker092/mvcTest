namespace mvcTest.Models
{
       using System.ComponentModel.DataAnnotations;

    public class Photo
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        [Url]
        public string ThumbnailUrl { get; set; }
    }
}
