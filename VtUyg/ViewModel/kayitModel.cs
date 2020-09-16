using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VtUyg.ViewModel
{
    public class kayitModel
    {
        public int kayId { get; set; }


        [Required(ErrorMessage = "Adı Soyadı Giriniz!")]  // model özellikleri için doğrulama kuralları belirtmemize olanak sağlar.
        [Display(Name = "Adı Soyadı")] // ekran adı ekler
        [StringLength(500, ErrorMessage = "Adı Soyadı En Fazla 500 Karakter Olmalı!")]
        public string adsoyad { get; set; }

        [Required(ErrorMessage = "E-Posta Giriniz!")]  // model özellikleri için doğrulama kuralları belirtmemize olanak sağlar.
        [Display(Name = "E-Posta")] // ekran adı ekler
        [StringLength(500 ,ErrorMessage = "E-Posta En Fazla 500 Karakter Olmalı!")]

        public string mail { get; set; }

        [Required(ErrorMessage = "Yaş Giriniz!")]  // model özellikleri için doğrulama kuralları belirtmemize olanak sağlar.
        [Display(Name = "Yaş")] // ekran adı ekler

        public int yas { get; set; }
    
    } 
}