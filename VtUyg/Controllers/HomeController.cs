using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;
using VtUyg.Models;
using VtUyg.ViewModel;

namespace VtUyg.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        db01Entities db = new db01Entities();
        public ActionResult Index()
        {
            List<Kayitlar> kayitListe = db.Kayitlar.ToList();
            return View(kayitListe);
        }

        public ActionResult yeniKayit()
        {
            return View();
        }
       [HttpPost]
        public ActionResult yeniKayit(kayitModel model)
        {
            Kayitlar kayit = new Kayitlar();
            kayit.adsoyad = model.adsoyad;
            kayit.mail = model.mail;
            kayit.yas = model.yas;

            db.Kayitlar.Add(kayit); //veritabanındaki kayıtlar ekleniyor.
            db.SaveChanges(); // olası değişiklikleri kaydetmek için.

            ViewBag.sonuc = "Kayıt Yapıldı.";// ViewBag,homecontrol'deki yapıyı view'e taşır


            return View();
        }
    
        public ActionResult kayitDuzenle(int? id)
        {

            Kayitlar kayit = db.Kayitlar.Where(k => k.kayId == id).SingleOrDefault();

            kayitModel model = new kayitModel();
            model.kayId = kayit.kayId;
            model.adsoyad = kayit.adsoyad;
            model.mail = kayit.mail;
            model.yas = kayit.yas;
            return View(model);
        }

        [HttpGet]

        public ActionResult kayitSil(int? id)
        {
            Kayitlar kayit = db.Kayitlar.Where(k => k.kayId == id).SingleOrDefault();

            db.Kayitlar.Remove(kayit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult kayitDuzenle(kayitModel m)
        {

            Kayitlar kayit = db.Kayitlar.Where(k => k.kayId == m.kayId).SingleOrDefault();
            kayit.adsoyad = m.adsoyad;
            kayit.mail = m.mail;
            kayit.yas = m.yas;

            db.SaveChanges(); // yapılan değişiklikleri-güncellemeleri kaydeder.



            ViewBag.sonuc = "Kayıt Güncellendi";// ViewBag,homecontrol'deki yapıyı view'e taşır
            return View();
        }
    }
}