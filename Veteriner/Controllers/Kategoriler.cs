using Microsoft.AspNetCore.Mvc;
using Veteriner.DataBase;

namespace Veteriner.Controllers
{
    public class Kategoriler : Controller
    {
        ApplicationConnectionDb db = new ApplicationConnectionDb();
        public IActionResult Yeni()
        {
            ViewBag.Baslik = "Kategori Ekle";
            return View();
        }
        public IActionResult Listele()
        {

            ViewBag.Baslik = "Kategori Listele";

            return View();
        }


        [HttpPost]
        public ActionResult YeniKategoriKaydet(Kategori K)
        {
            db.Kategori.Add(K);
            db.SaveChanges();
            return RedirectToAction("Listele");
        }


        [HttpPost]
        public ActionResult KategoriDuzenle(Kategori YKB)
        {
            Kategori EKB = db.Kategori.FirstOrDefault(x => x.id == YKB.id);
            EKB.Ad = YKB.Ad;
            EKB.Aciklama = YKB.Aciklama;
            db.SaveChanges();
            return RedirectToAction("Listele");

        }



        [HttpPost]
        public ActionResult KategoriSil(Kategori YKB)
        {
            Kategori EKB = db.Kategori.FirstOrDefault(x => x.id == YKB.id);
            db.Kategori.Remove(EKB);
            db.SaveChanges(true);
            return RedirectToAction("Listele");

        }



    }
}
