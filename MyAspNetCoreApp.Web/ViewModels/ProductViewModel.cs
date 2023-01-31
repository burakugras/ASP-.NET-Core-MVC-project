
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [StringLength(50,ErrorMessage ="İsim alanına en fazla 50 karakter girilebilir.")]
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz")]
        public string? Name { get; set; }

        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})",ErrorMessage ="Fiyat alanında noktadan sonra en fazla 2 basamak olmalıdır.")]
        [Range(1, 1000, ErrorMessage = "Fiyat alanı 1 ile 1000 arasında bir değer olmalıdır.")]
        [Required(ErrorMessage ="Fiyat alanı boş bırakılamaz")]    
        public decimal? Price { get; set; }
        
        [Required(ErrorMessage = "Stok alanı boş bırakılamaz")]
        [Range(1,200,ErrorMessage ="Stok alanı 1 ile 200 arasında bir değer olmalıdır.")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "Renk boş bırakılamaz")]
        public string? Color { get; set; }
        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "Süre boş bırakılamaz")]
        public int? Expire { get; set; }
        [Required(ErrorMessage = "Yayınlanma tarihi boş olamaz")]
        public DateTime? PublishDate { get; set; }
        [StringLength(300, MinimumLength =50, ErrorMessage = "Açıklama alanı 50 ile 300 karakter arasında olabilir.")]
        [Required(ErrorMessage = "Açıklama boş bırakılamaz")]
        public string Description { get; set; }

        [EmailAddress(ErrorMessage ="Email adresi uygun formatta değil.")]
        public string EmailAddress { get; set; }
    }
}
