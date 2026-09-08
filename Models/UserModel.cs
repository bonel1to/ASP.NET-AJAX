using System.ComponentModel.DataAnnotations;

namespace ASP.NET_AJAX.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Нужно обязательно заполнить имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя от 2 до 50 символов")]
        [Display(Name = "Имя")]
        public string Name {get; set;}= string.Empty;

        [Required(ErrorMessage = "Нужно обязательно заполнить email")]
        [EmailAddress(ErrorMessage = "Нужна правильная почта")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Email от 2 до 50 символов")]
        [Display(Name = "Email")]
        public string Email {get; set;}= string.Empty;

        [Required(ErrorMessage = "Нужно обязательно заполнить телефон")]
        [Phone(ErrorMessage = "Нужен правильный номер телефона")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Нужно обязательно заполнить город")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Город от 2 до 50 символов")]
        [Display(Name = "Город")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Нужно обязательно заполнить год рождения")]
        [Range(1900, 2026, ErrorMessage = "Год от 1900 до 2026")]
        [Display(Name = "Год рождения")]
        public int? BirthYear {get; set;}

        [Required(ErrorMessage = "Нужно обязательно заполнить образование")]
        [Display(Name = "Образование")]
        public string Education { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "Комментарий должен быть не длиннее 300 символов")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; } = string.Empty;
    }
}
