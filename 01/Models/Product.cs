using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва товару є обов'язковою")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Назва має бути від 3 до 100 символів")]
        [Display(Name = "Назва")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Опис не може перевищувати 500 символів")]
        [Display(Name = "Опис")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Вкажіть ціну")]
        [Range(0.01, 1000000, ErrorMessage = "Ціна має бути від 0.01 до 1 000 000")]
        [Display(Name = "Ціна (₴)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Вкажіть кількість")]
        [Range(0, 10000, ErrorMessage = "Кількість має бути від 0 до 10 000")]
        [Display(Name = "Кількість на складі")]
        public int Amount { get; set; }

        [Display(Name = "Фото")]
        public string? Image { get; set; }

        [NotMapped]
        [Display(Name = "Обрати фото")]
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Оберіть категорію")]
        [Display(Name = "Категорія")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}