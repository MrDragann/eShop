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
                    productTags = "fast, superspeed, ultramodern",
                    productDescription = "Супер современная материнская плата",
                    productPrice = 3500,
                    dateAdd = "2017-01-14",
                    collectionsTags = { "fast", "superspeed", "ultramodern" },
                    productImage = "motherB.jpg"
                });
            productList.Add(
                new ProductModel
                {
                    productId = 2,
                    productName = "USB FLASH DRIVE KINGSTON 32GB",
                    selectedCategory = "Накопители",
                    productTags = "flash, fast, superspeed",
                    productDescription = "Ультрабыстрый флэш-накопитель.",
                    productPrice = 322,
                    dateAdd = "2017-01-19",
                    collectionsTags = { "flash", "fast", "superspeed" },
                    productImage = "flashK.jpg"
                });
            productList.Add(
                new ProductModel
                {
                    productId = 3,
                    productName = "A4 Tech A4-KB-28G-1-U",
                    selectedCategory = "Клавиатуры",
                    productTags = "a4, keyboard, usb",
                    productDescription = "Самая надежная клавиатура.",
                    productPrice = 200,
                    dateAdd = "2017-01-20",
                    collectionsTags = { "a4", "keyboard", "usb" },
                    productImage = "a4Keyb.jpg"
                });
            productList.Add(
                new ProductModel
                {
                    productId = 4,
                    productName = "Logitech G105 USB",
                    selectedCategory = "Клавиатуры",
                    productTags = "logitech, keyboard, usb, backlight",
                    productDescription = "Игровая клавиатура с подцветкой.",
                    productPrice = 901,
                    dateAdd = "2017-01-22",
                    collectionsTags = { "logitech", "keyboard", "usb", "backlight" },
                    productImage = "logG105Keyb.jpg"
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
            if (productList.Count < 1)
            {
                model.productId = 1;
            }
            else
            {
                model.productId = productList.Max(x => x.productId) + 1;
            }
            model.collectionsTags = ProductDataStorage.Instance.TagsSplit(model);
            productList.Add(model);
        }
        /// <summary>
        /// Поиск информации о товаре по его ID
        /// </summary>
        /// <param name="ProdutId"></param>
        /// <returns></returns>
        public ProductModel GetProductById(int ProdutId)
        {
            return productList.Find(x => x.productId == ProdutId);
        }
        /// <summary>
        /// Обновление информации о товаре
        /// </summary>
        /// <param name="model"></param>
        public void UpdateProduct(ProductModel model)
        {
            ///Замена старой модели на новую
            var oldModel = productList.Find(x => x.productId == model.productId);
            if (oldModel == null)
            {
                return;
            }
            if (model.productImage == null) { model.productImage = oldModel.productImage; }
            productList.Remove(oldModel);
            model.collectionsTags = ProductDataStorage.Instance.TagsSplit(model);
            productList.Add(model);
        }
        /// <summary>
        /// Удаление товара из списка
        /// </summary>
        /// <param name="ProductId"></param>
        public void DeleteProduct(int ProductId)
        {
            var model = productList.Find(x => x.productId == ProductId);
            ///Проверка существования модели
            if (model == null)
            {
                return;
            }
            productList.Remove(model);
        }
        /// <summary>
        /// Метод поиска товаров по заданному тегу
        /// </summary>
        /// <param name="Tag">Имя тега</param>
        /// <returns>Список товаров</returns>
        public List<ProductModel> GetProductsByTag(string Tag)
        {
            return productList.FindAll(x => x.collectionsTags.Contains(Tag));
        }
        /// <summary>
        /// Разбиение строки тегов
        /// </summary>
        /// <param name="model">Экземпляр ProductModel</param>
        /// <returns>Коллекцию тегов</returns>
        public List<string> TagsSplit(ProductModel model)
        {
            return model.productTags.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}