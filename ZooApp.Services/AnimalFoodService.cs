using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
   public class AnimalFoodService
    {
        ZooContext db = new ZooContext();
        public List<ViewFoodTotal> GetViewFoodTotal()
        {
            var animalFoods = db.AnimalFoods.ToList();

            List<ViewFoodTotal> totals = new List<ViewFoodTotal>();
            foreach (AnimalFood animalFood in animalFoods)
            {
                ViewFoodTotal foodTotal = new ViewFoodTotal(animalFood);
                totals.Add(foodTotal);
            }

            var groupBy = totals.GroupBy(x => x.FoodName);
            List<ViewFoodTotal> results = new List<ViewFoodTotal>();
            foreach (IGrouping<string, ViewFoodTotal> foodTotals in groupBy)
            {
                double totalPrice = foodTotals.Sum(x => x.TotalPrice);
                double quantity = foodTotals.Sum(x => x.TotalQuantity);
                ViewFoodTotal foodTotal = new ViewFoodTotal()
                {
                    FoodName = foodTotals.Key,
                    FoodPrice = foodTotals.First().FoodPrice,
                    TotalPrice = totalPrice,
                    TotalQuantity = quantity

                };
                results.Add(foodTotal);
            }
            return results;
        }
    }
}
