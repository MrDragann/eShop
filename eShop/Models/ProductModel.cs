using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.Models
{
    public class ProductModel
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int productId { get; set; }
        /// <summary>
        /// Имя товара
        /// </summary>
        public string productName { get; set; }
        /// <summary>
        /// Список категорий
        /// </summary>
        public static List<string> productCategory = new List<string>()
        {
            "Процессоры",
            "Материнские платы",
            "Память",
            "Видеокарты",
            "Накопители"
        };
        /// <summary>
        /// Выбранная категория
        /// </summary>
        public string selectedCategory { get; set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        public string productDescription { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public double productPrice { get; set; }
        /// <summary>
        /// Теги товара
        /// </summary>
        public string productTags { get; set; }
        /// <summary>
        /// Дата добавления товара
        /// </summary>
        public string dateAdd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string productImage { get; set; }
        /// <summary>
        /// Путь к изображению
        /// </summary>
        public static string pathToImage = "/Content/Images/";
    }
}