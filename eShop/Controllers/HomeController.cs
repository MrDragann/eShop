using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eShop.Models;
using System.Data.Entity;

namespace eShop.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();

        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns>Список имеющихся товаров
        /// с сортировкой по цене</returns>
        public ActionResult Index(int pageNum = 0, TypeSort sort = TypeSort.NameAsc)
        {
            ProductDataStorage.Instance.PageNum = pageNum;
            ProductDataStorage.Instance.ItemsCount = db.Products.Count();
            int pageSize = ProductDataStorage.Instance.PageSize;
            switch (sort)
            {
                case TypeSort.NameAsc: return View(db.Products.OrderBy(x => x.Name).Skip(pageSize * pageNum).Take(pageSize));
                case TypeSort.NameDesc: return View(db.Products.OrderByDescending(x => x.Name).Skip(pageSize * pageNum).Take(pageSize));
                case TypeSort.PriceAsc: return View(db.Products.OrderBy(x => x.Price).Skip(pageSize * pageNum).Take(pageSize));
                case TypeSort.PriceDesc: return View(db.Products.OrderByDescending(x => x.Price).Skip(pageSize * pageNum).Take(pageSize));
            }
            return View(db.Products.OrderBy(x => x.Name));
        }
        /// <summary>
        /// Страница добавления товара
        /// </summary>
        /// <returns>Новый объект модели товаров</returns>
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        /// <summary>
        /// Добавление нового товара в список
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProduct(Product model, HttpPostedFileBase Image)
        {
            ///Проверка наличия папки изображений
            string path = Request.MapPath("~/Content/Images");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            ///Изображение по умолчанию
            string fileName = "unknownProduct.jpg";
            if (Image != null)
            {
                ///Извлечение имени файла
                fileName = System.IO.Path.GetFileName(Image.FileName);
                model.Image = fileName;
                ///Сохранение файла в проекте
                Image.SaveAs(Server.MapPath(Product.pathToImage + fileName));
            }
            if (Image == null) model.Image = "unknownProduct.jpg";
            db.Products.Add(model);
            db.SaveChanges();
            return View("Details", model);
        }
        /// <summary>
        /// Вывод информации о товаре по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db.Products.Find(id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }
        /// <summary>
        /// Редактирование товара основываясь на выбранном ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product model = db.Products.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }
        /// <summary>
        /// Редактирование информации о товаре
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="Image"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Product model, HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                ///Извлечение имени файла
                string fileName = System.IO.Path.GetFileName(Image.FileName);
                model.Image = fileName;
                ///Сохранение файла в проекте
                Image.SaveAs(Server.MapPath(Product.pathToImage + fileName));
            }
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return View("Details", model);
        }
        
        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeleteProduct(int id)
        {
            Product model = db.Products.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.Products.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Management");
        }
        /// <summary>
        /// Поиск товаров по тегу
        /// </summary>
        /// <param name="Tag">Имя тега</param>
        /// <returns>Список товаров</returns>
        //public ActionResult FindProductByTag(string Tag)
        //{
        //    ViewBag.Message = Tag;
        //    return View(ProductDataStorage.Instance.GetProductsByTag(Tag));
        //}
        /// <summary>
        /// Управление товарами
        /// </summary>
        /// <returns></returns>
        public ActionResult Management()
        {
            return View(db.Products);
        }

        /// <summary>
        /// Поиск товаров по категории
        /// </summary>
        /// <param name="Category">Название категории</param>
        /// <returns>Список товаров</returns>
        //public ActionResult Category(string Category)
        //{
        //    ViewBag.Message = Category;
        //    return View(ProductDataStorage.Instance.GetProductsByCategory(Category));
        //}
        /// <summary>
        /// Закрытие подключения
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}