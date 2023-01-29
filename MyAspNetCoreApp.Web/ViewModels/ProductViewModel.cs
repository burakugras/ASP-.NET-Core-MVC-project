
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
        public string? Color { get; set; }
        public bool IsPublish { get; set; }
        public int Expire { get; set; }
        public DateTime? PublishDate { get; set; }
        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz")]
        public string Description { get; set; }
    }
}
