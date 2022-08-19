using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Models
{
    public class UserSignUpViewModel
    {

        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen adınızı ve soyadınızı giriniz!")]
        public string nameSurname  { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz!")]
        public string Password { get; set; }

        [Display(Name = "Şifreyi Doğrula")]
        [Compare("Password",ErrorMessage ="Şifreler  uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen mailinizi giriniz!")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz!")]
        public string Username { get; set; }
        public bool IsAcceptCheckBox { get; set; }

    }
}
