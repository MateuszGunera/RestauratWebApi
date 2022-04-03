using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC is American fast food restaurant.",
                    HasDelivery = true,
                    ContactEmail = "contact@kfc.com",
                    ContactNumber = "697899118",

                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "B-smart",
                            Price = 6.95M,
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 11.99M,
                        },
                    },

                    Address = new Address()
                    {
                        City = "Szczecin",
                        Street = "Potulicka",
                        PostalCode = "234-56"
                    },
                },

                new Restaurant()
                {
                    Name = "TienDat",
                    Category = "Chinese cuisine",
                    Description = "TienDat is American Chinese cuisine restaurant.",
                    HasDelivery = true,
                    ContactEmail = "tien-dat@td.com",
                    ContactNumber = "798356758",

                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Pad Thai",
                            Price = 25.50M,
                        },
                        new Dish()
                        {
                            Name = "Chicken Curry",
                            Price = 23.99M,
                        },
                        new Dish()
                        {
                            Name = "Chicken Crispy",
                            Price = 24.20M,
                        },
                    },

                    Address = new Address()
                    {
                        City = "Łobez",
                        Street = "Niepodległości",
                        PostalCode = "73-150"
                    },
                }
            };

            return restaurants;
        }
    }
}
