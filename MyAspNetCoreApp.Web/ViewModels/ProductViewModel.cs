
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Fiyat alanı boş bırakılamaz")]    
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Stok alanı boş bırakılamaz")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "Renk boş bırakılamaz")]
        public string? Color { get; set; }
        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "Süre boş bırakılamaz")]
        public int? Expire { get; set; }
        [Required(ErrorMessage = "Yayınlanma tarihi boş olamaz")]
        public DateTime? PublishDate { get; set; }
        [Required(ErrorMessage = "Açıklama boş bırakılamaz")]
        public string Description { get; set; }
    }
}
