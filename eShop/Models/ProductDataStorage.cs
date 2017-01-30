using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eShop.Models
{
    /// <summary>
    /// Контекст данных для работы с моделями
    /// </summary>
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
    }

    public class ProductDataStorage
    {
        /// <summary>
        /// Экземпляр хранилища товаров
        /// </summary>
        public static ProductDataStorage Instance = new ProductDataStorage();
        /// <summary>
        /// Метод поиска товаров по заданному тегу
        /// </summary>
        /// <param name="Tag">Имя тега</param>
        /// <returns>Список товаров</returns>
        //public List<Product> GetProductsByTag(string Tag)
        //{
        //    return productList.FindAll(x => x.collectionsTags.Contains(Tag));
        //}
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
        //public List<Product> GetProductsByCategory(string Category)
        //{
        //    return productList.FindAll(x => x.selectedCategory.Contains(Category));
        //}
        /// <summary>
        /// Данные для постраничного вывода
        /// </summary>
        public int PageSize = 3;
        public int PageNum { get; set; }
        public int ItemsCount { get; set; }
    }
}