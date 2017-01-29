using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.Models
{
    public class Product
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Выбранная категория
        /// </summary>
        public string selectedCategory { get; set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Характеристики товара
        /// </summary>
        public string Characteristics { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Теги товара
        /// </summary>
        public string Tags { get; set; }
        public List<string> collectionsTags = new List<string>();
        /// <summary>
        /// Дата добавления товара
        /// </summary>
        public string DateAdd { get; set; }
        /// <summary>
        /// Название изображения товара
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Путь к изображениям
        /// </summary>
        public static string pathToImage = "/Content/Images/";
        /// <summary>
        /// Список категорий
        /// </summary>
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