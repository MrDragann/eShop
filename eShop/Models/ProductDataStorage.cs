using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.Models
{
    public class ProductDataStorage
    {
        /// <summary>
        /// Экземпляр хранилища товаров
        /// </summary>
        public static ProductDataStorage Instance = new ProductDataStorage();
        /// <summary>
        /// Список имеющихся товаров
        /// </summary>
        public List<ProductModel> productList = new List<ProductModel>();
        /// <summary>
        /// Инициализация списка товаров
        /// </summary>
        public ProductDataStorage()
        {
            productList.Add(
                new ProductModel
                {
                    productId = 1,
                    productName = "ASUS MAXIMUS VII RANGER",
                    selectedCategory = "Материнские платы",
                    productDescription = "Супер современная материнская плата",
                    productPrice = 3500,
                    dateAdd = "2017-01-14",
                    productTags = "fast, superspeed, ultramodern"
                });
            productList.Add(
                new ProductModel
                {
                    productId = 2,
                    productName = "USB FLASH DRIVE 32GB KINGSTON DT 100 G3",
                    selectedCategory = "Накопители",
                    productDescription = "Ультрабыстрый флэш-накопитель.",
                    productPrice = 322,
                    dateAdd = "2017-01-19",
                    productTags = "flash, fast, superspeed"
                });
            
        }
        /// <summary>
        /// Вывод имеющегося списка товаров
        /// </summary>
        /// <returns>Список товаров</returns>
        public List<ProductModel> GetAllProducts()
        {
            return productList;
        }
        /// <summary>
        /// Добавление нового товара в список
        /// </summary>
        /// <param name="model">Объект ProductModel</param>
        public void AddProduct(ProductModel model)
        {
            ///Создание нового ID на основе уже существующих
            model.productId = productList.Max(x => x.productId) + 1;
            productList.Add(model);
        }
        /// <summary>
        /// Поиск информации о товаре по его ID
        /// </summary>
        /// <param name="ProdutId"></param>
        /// <returns></returns>
        public ProductModel GetProductById(int ProdutId)
        {
            return productList.Find(x => x.productId==ProdutId);
        }
    }
}