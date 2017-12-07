using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Data.Models
{
    public class DbInitializer
    {
        public static void Initialize(CakeDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Catgoryes.Any())
            {
                context.Catgoryes.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Cakes.Any())
            {
                context.AddRange
                (
                    new Cake
                    {
                        Name = "Čokoladna kraljica",
                        Price = 7.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Čokoladne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2017/03/cokoladna-kraljica.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2017/03/cokoladna-kraljica.jpg"
                    },
                    new Cake
                    {
                        Name = "Mlečna čokoladna torta ",
                        Price = 12.95M,
                        ShortDescription = "Cocktail made of cola, lime and rum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Čokoladne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2017/02/mlecna-cokoladna-torta.jpg",
                        InStock = true,
                        IsPerferedCake = false,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2017/02/mlecna-cokoladna-torta.jpg"
                    },
                    new Cake
                    {
                        Name = "Torta sa orasima",
                        Price = 8.95M,
                        ShortDescription = "Lorem ipsumdolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Čokoladne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/12/torta-sa-orasima.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/12/torta-sa-orasima.jpg"
                    },
                    new Cake
                    {
                        Name = "Grilijas torta",
                        Price = 10.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Čokoladne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/11/grilijas-torta.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/11/grilijas-torta.jpg"
                    },
                    new Cake
                    {
                        Name = "Monte",
                        Price = 12.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Čokoladne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/02/IMG_7334.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/02/IMG_7334.jpg"
                    },
                    new Cake
                    {
                        Name = "Plazma torta sa bananama",
                        Price = 15.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Voćne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2017/05/plazma-torta-sa-bananama.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2017/05/plazma-torta-sa-bananama.jpg"
                    },
                    new Cake
                    {
                        Name = "Voćna Torta",
                        Price = 10.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Voćne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/07/torta-sa-breskvama-vocna-torta.jpg",
                        InStock = false,
                        IsPerferedCake = false,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/07/torta-sa-breskvama-vocna-torta.jpg"
                    },
                    new Cake
                    {
                        Name = "Torta sa jaogdama",
                        Price = 12.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Voćne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/05/torta-sa-jagodama.jpg",
                        InStock = false,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/05/torta-sa-jagodama.jpg"
                    },
                    new Cake
                    {
                        Name = "Bloddy berry torta",
                        Price = 13.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Voćne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/04/bloddy-berry-torta.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/04/bloddy-berry-torta.jpg"
                    },
                    new Cake
                    {
                        Name = "Cheesecake sa šumskim voćem",
                        Price = 15.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Voćne"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2015/06/cizkejk-sa-sumskim-vocem-cheesecake.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2015/06/cizkejk-sa-sumskim-vocem-cheesecake.jpg"
                    },
                    new Cake
                    {
                        Name = "Brza torta sa plazma keksom i orasima",
                        Price = 12.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Brze"],
                        ImageUrl = "https://domacirecepti.net/wp-content/uploads/2016/01/brza-torta-sa-plazma-keksom-i-orasima.jpg",
                        InStock = false,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://domacirecepti.net/wp-content/uploads/2016/01/brza-torta-sa-plazma-keksom-i-orasima.jpg"
                    },
                    new Cake
                    {
                        Name = "Beli andjeo torta",
                        Price = 19.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Brze"],
                        ImageUrl = "https://domacirecepti.net/wp-content/uploads/2017/05/torta-beli-andjeo-thumb.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://domacirecepti.net/wp-content/uploads/2017/05/torta-beli-andjeo-thumb.jpg"
                    },
                    new Cake
                    {
                        Name = "Torta sa TOTO keksom",
                        Price = 12.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Brze"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/08/toto-torta-3.jpg",
                        InStock = false,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/08/toto-torta-3.jpg"
                    },
                    new Cake
                    {
                        Name = "Šeherezada torta",
                        Price = 16.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Brze"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/05/seherezada.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/05/seherezada.jpg"
                    },
                    new Cake
                    {
                        Name = "Fanta jafa torta",
                        Price = 14.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Brze"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/11/fanta-jafa-torta.jpg",
                        InStock = false,
                        IsPerferedCake = false,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/11/fanta-jafa-torta.jpg"
                    },
                    new Cake
                    {
                        Name = "Brza plazma torta",
                        Price = 12.95M,
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tortor eros, interdum in dolor at, blandit pellentesque metus. Nulla dapibus ornare nisi vitae posuere. Mauris arcu nibh, bibendum id nulla vitae, vestibulum iaculis augue. Maecenas ut posuere turpis, at vulputate sapien. Pellentesque vel nisi vitae felis commodo rutrum. Integer sagittis sed leo vel aliquam.",
                        Category = Categories["Brze"],
                        ImageUrl = "https://brzikolaci.com/wp-content/uploads/2016/01/brza-plazma-torta.jpg",
                        InStock = true,
                        IsPerferedCake = true,
                        ImageThumbnailUrl = "https://brzikolaci.com/wp-content/uploads/2016/01/brza-plazma-torta.jpg"
                    }




                );
            }
        

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var categoryList = new Category[]
                    {
                        new Category { CategoryName = "Čokoladne", Description="Čokoladne Torte" },
                        new Category { CategoryName = "Voćne", Description="Voćne Torte" },
                        new Category { CategoryName = "Brze", Description="Brze Torte" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category category in categoryList)
                    {
                        categories.Add(category.CategoryName, category);
                    }
                }

                return categories;
            }
        }
    }
}
