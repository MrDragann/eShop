using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eShop.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

    public class ProductDataStorage
    {
        /// <summary>
        /// Экземпляр хранилища товаров
        /// </summary>
        public static ProductDataStorage Instance = new ProductDataStorage();
        /// <summary>
        /// Список имеющихся товаров
        /// </summary>
        public List<Product> productList = new List<Product>();
        /// <summary>
        /// Инициализация списка товаров
        /// </summary>
        public ProductDataStorage()
        {
            productList.Add(
                new Product
                {
                    Id = 1,
                    Name = "ASUS MAXIMUS VII RANGER",
                    selectedCategory = "Материнские платы",
                    Tags = "fast, superspeed, ultramodern",
                    Description = "Супер современная материнская плата",
                    Characteristics = "Тут будут характеристики",
                    Price = 3500,
                    DateAdd = "2017-01-14",
                    collectionsTags = { "fast", "superspeed", "ultramodern" },
                    Image = "motherB.jpg"
                });
            productList.Add(
                new Product
                {
                    Id = 2,
                    Name = "KINGSTON USB FLASH 32GB",
                    selectedCategory = "Накопители",
                    Tags = "flash, fast, superspeed",
                    Description = "Ультрабыстрый флэш-накопитель.",
                    Characteristics = "Тут будут характеристики",
                    Price = 322,
                    DateAdd = "2017-01-19",
                    collectionsTags = { "flash", "fast", "superspeed" },
                    Image = "flashK.jpg"
                });
            productList.Add(
                new Product
                {
                    Id = 3,
                    Name = "A4 Tech A4-KB-28G-1-U",
                    selectedCategory = "Клавиатуры",
                    Tags = "a4, keyboard, usb",
                    Description = "Самая надежная клавиатура.",
                    Characteristics = "Тут будут характеристики",
                    Price = 200,
                    DateAdd = "2017-01-20",
                    collectionsTags = { "a4", "keyboard", "usb" },
                    Image = "a4Keyb.jpg"
                });
            productList.Add(
                new Product
                {
                    Id = 4,
                    Name = "Logitech G105 USB",
                    selectedCategory = "Клавиатуры",
                    Tags = "logitech, keyboard, usb, backlight",
                    Description = "Игровая клавиатура с подцветкой.",
                    Characteristics = "Тут будут характеристики",
                    Price = 901,
                    DateAdd = "2017-01-22",
                    collectionsTags = { "logitech", "keyboard", "usb", "backlight" },
                    Image = "logG105Keyb.jpg"
                });
        }
        
        /// <summary>
        /// Вывод имеющегося списка товаров
        /// </summary>
        /// <returns>Список товаров</returns>
        public List<Product> GetAllProducts()
        {
            return productList;
        }
        /// <summary>
        /// Добавление нового товара в список
        /// </summary>
        /// <param name="model">Объект ProductModel</param>
        public void AddProduct(Product model)
        {
            ///Создание нового ID на основе уже существующих
            if (productList.Count < 1)
            {
                model.Id = 1;
            }
            else
            {
                model.Id = productList.Max(x => x.Id) + 1;
            }
            model.collectionsTags = ProductDataStorage.Instance.TagsSplit(model);
            productList.Add(model);
        }
        /// <summary>
        /// Поиск информации о товаре по его ID
        /// </summary>
        /// <param name="ProdutId"></param>
        /// <returns></returns>
        public Product GetProductById(int ProdutId)
        {
            return productList.Find(x => x.Id == ProdutId);
        }
        /// <summary>
        /// Обновление информации о товаре
        /// </summary>
        /// <param name="model"></param>
        public void UpdateProduct(Product model)
        {
            ///Замена старой модели на новую
            var oldModel = productList.Find(x => x.Id == model.Id);
            if (oldModel == null)
            {
                return;
            }
            if (model.Image == null) { model.Image = oldModel.Image; }
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
            var model = productList.Find(x => x.Id == ProductId);
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
        public List<Product> GetProductsByTag(string Tag)
        {
            return productList.FindAll(x => x.collectionsTags.Contains(Tag));
        }
        /// <summary>
        /// Разбиение строки тегов
        /// </summary>
        /// <param name="model">Экземпляр ProductModel</param>
        /// <returns>Коллекцию тегов</returns>
        public List<string> TagsSplit(Product model)
        {
            return model.Tags.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        /// <summary>
        /// Метод поиска товаров по категории
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        public List<Product> GetProductsByCategory(string Category)
        {
            return productList.FindAll(x => x.selectedCategory.Contains(Category));
        }


        public int PageSize = 3;
        public int PageNum { get; set; }
        public int ItemsCount { get; set; }
    }
}