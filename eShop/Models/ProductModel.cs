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
            "Накопители",
            "Клавиатуры"
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
        /// Характеристики товара
        /// </summary>
        public string productCharacteristics { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public double productPrice { get; set; }
        /// <summary>
        /// Теги товара
        /// </summary>
        public string productTags { get; set; }
        public List<string> collectionsTags = new List<string>();
        /// <summary>
        /// Дата добавления товара
        /// </summary>
        public string dateAdd { get; set; }
        /// <summary>
        /// Название изображения товара
        /// </summary>
        public string productImage { get; set; }
        /// <summary>
        /// Путь к изображениям
        /// </summary>
        public static string pathToImage = "/Content/Images/";

        public static List<Category> Category = new List<Category>()
        {
            new Category
            {
                Id = 1,
                Name = "Компьютеры",
                Childrens = new List<Category>()
                {
                    new Category
                    {
                        Name = "Процессоры"
                    },
                    new Category
                    {
                        Name = "Материнские платы"
                    },
                    new Category
                    {
                        Name = "Накопители"
                    }
                }
            },
            new Category
            {
                Id = 2,
                Name = "Периферия",
                Childrens = new List<Category>()
                {     
                        new Category
                    {
                        Name = "Мыши"
                    },
                        new Category
                    {
                        Name = "Клавиатуры"
                    }
                }
            }
        };
        
    }

    public enum TypeSort
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
}