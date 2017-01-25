using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eShop.Models;

namespace eShop.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns>Список имеющихся товаров
        /// с сортировкой по цене</returns>
        public ActionResult Index(TypeSort sort = TypeSort.NameAsc)
        {
            switch (sort)
            {
                case TypeSort.NameAsc: return View(ProductDataStorage.Instance.GetAllProducts().OrderBy(x => x.productName));
                case TypeSort.NameDesc: return View(ProductDataStorage.Instance.GetAllProducts().OrderByDescending(x => x.productName));
                case TypeSort.PriceAsc: return View(ProductDataStorage.Instance.GetAllProducts().OrderBy(x => x.productPrice));
                case TypeSort.PriceDesc: return View(ProductDataStorage.Instance.GetAllProducts().OrderByDescending(x => x.productPrice));
            }
            return View(ProductDataStorage.Instance.GetAllProducts().OrderBy(x => x.productName));
            //return View(sort == TypeSort.NameAsc ? ProductDataStorage.Instance.GetAllProducts().OrderBy(x => x.productName): ProductDataStorage.Instance.GetAllProducts().OrderByDescending(x => x.productName));
        }
        /// <summary>
        /// Страница добавления товара
        /// </summary>
        /// <returns>Новый объект модели товаров</returns>
        public ActionResult AddProduct()
        {
            return View(new ProductModel());
        }
        /// <summary>
        /// Добавление нового товара в список
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProduct(ProductModel model, HttpPostedFileBase productImage)
        {
            string fileName = "unknownProduct.jpg";
            if (productImage != null)
            {
                ///Извлечение имени файла
                fileName = System.IO.Path.GetFileName(productImage.FileName);
                model.productImage = fileName;
                ///Сохранение файла в проекте
                productImage.SaveAs(Server.MapPath(ProductModel.pathToImage + fileName));
            }
            if (productImage == null) model.productImage = "unknownProduct.jpg";

            ProductDataStorage.Instance.AddProduct(model);
            return View("Details", model);
        }
        /// <summary>
        /// Вывод информации о товаре по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            ProductModel model = ProductDataStorage.Instance.GetProductById(id);
            model.collectionsTags = ProductDataStorage.Instance.TagsSplit(model);
            return View(model);
        }
        /// <summary>
        /// Редактирование товара основываясь на выбранном ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ProductModel model = ProductDataStorage.Instance.GetProductById(id);
            return View(model);
        }
        /// <summary>
        /// Редактирование информации о товаре
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="productImage"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, ProductModel model, HttpPostedFileBase productImage)
        {
            if (productImage != null)
            {
                ///Извлечение имени файла
                string fileName = System.IO.Path.GetFileName(productImage.FileName);
                model.productImage = fileName;
                ///Сохранение файла в проекте
                productImage.SaveAs(Server.MapPath(ProductModel.pathToImage + fileName));
            }
            
            ProductDataStorage.Instance.UpdateProduct(model);
            return View("Details", model);
        }
        
        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeleteProduct(int id, ProductModel model)
        {
            ProductDataStorage.Instance.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Поиск товаров по тегу
        /// </summary>
        /// <param name="Tag">Имя тега</param>
        /// <returns>Список товаров</returns>
        public ActionResult FindProductByTag(string Tag)
        {
            ViewBag.Message = Tag;
            return View(ProductDataStorage.Instance.GetProductsByTag(Tag));
        }
    }
}