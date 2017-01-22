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
        public ActionResult AddProduct(ProductModel model)
        {
            ProductDataStorage.Instance.AddProduct(model);
            return View();
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
    }
}