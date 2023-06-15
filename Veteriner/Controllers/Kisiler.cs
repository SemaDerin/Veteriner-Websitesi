using Microsoft.AspNetCore.Mvc;
using Veteriner.DataBase;

namespace Veteriner.Controllers
{
    public class Kisiler : Controller
    {
        ApplicationConnectionDb db = new ApplicationConnectionDb();
        public IActionResult Yeni()
        {
            ViewBag.Baslik = "Kişi Ekle";
            return View();
        }


        public ActionResult Listele()
        {
            ViewBag.Baslik = "Kişileri Listele";
            return View();
        }

        [HttpPost]
        public ActionResult KisiKaydet(Kisi K)
        {
            db.Kisi.Add(K);
            db.SaveChanges();
            return RedirectToAction("Listele");
        }



        [HttpPost]

        public ActionResult KisiDuzenle(Kisi YKB)
        {

            Kisi EKB = db.Kisi.FirstOrDefault(x=> x.id == YKB.id);
            EKB.Ad = YKB.Ad;
            EKB.Soyad = YKB.Soyad;
            EKB.Telefon = YKB.Telefon;
            EKB.Mail = YKB.Mail;
            EKB.Adres = YKB.Adres;
            db.SaveChanges();

            return RedirectToAction("Listele");
        }



        [HttpPost]
        public ActionResult KisiSil(Kisi SSKB)
        {
            Kisi SKB = db.Kisi.FirstOrDefault(x => x.id == SSKB.id);
            db.Kisi.Remove(SKB);
            db.SaveChanges(true);
            return RedirectToAction("Listele");

        }
    }
}
