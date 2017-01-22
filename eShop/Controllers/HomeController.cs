﻿using System;
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
        public ActionResult AddProduct(ProductModel model, HttpPostedFileBase image)
        {
            if (image != null)
            {
                ///Извлечение имени файла
                string fileName = System.IO.Path.GetFileName(image.FileName);
                model.productImage = fileName;
                ///Сохранение файла в проекте
                image.SaveAs(Server.MapPath(ProductModel.pathToImage + fileName));
            }
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

        public ActionResult Edit(int id)
        {
            return View(ProductDataStorage.Instance.GetProductById(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, ProductModel model)
        {
            ProductDataStorage.Instance.UpdateProduct(model);
            return View("Details", model);
        }
    }
}