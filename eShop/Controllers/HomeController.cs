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
        public ActionResult Index()
        {
            return View(ProductDataStorage.Instance.GetAllProducts().OrderBy(x => x.productPrice));
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
            if (productImage != null)
            {
                ///Извлечение имени файла
                string fileName = System.IO.Path.GetFileName(productImage.FileName);
                model.productImage = fileName;
                ///Сохранение файла в проекте
                productImage.SaveAs(Server.MapPath(ProductModel.pathToImage + fileName));
            }
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
            return View(ProductDataStorage.Instance.GetProductById(id));
        }
        /// <summary>
        /// Редактирование товара основываясь на выбранном ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View(ProductDataStorage.Instance.GetProductById(id));
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
        /// Выбор товара для удаления
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            return View(ProductDataStorage.Instance.GetProductById(id));
        }
        /// <summary>
        /// Удаление товара из списка
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            ProductDataStorage.Instance.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}