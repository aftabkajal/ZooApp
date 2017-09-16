using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        ZooContext db = new ZooContext();


        public List<ViewFood> GetAll()
        {
            //fetch db.animal data
            //pulls all row from table in to ram
            var list = db.Foods.ToList();

            List<ViewFood> viewFoods = new List<ViewFood>();

            foreach (var l in list)
            {
                var viewFood = new ViewFood(l);

                viewFoods.Add(viewFood);
            }
           return viewFoods;

        }

        public bool Save(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
            return true;
        }

        public Food GetDbModel(int id)
        {
            return db.Foods.Find(id);
        }

        public bool Update(Food food)
        {
            db.Entry(food).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public ViewFood Get(int id)
        {
            var food = db.Foods.Find(id);
            ViewFood viewFood = new ViewFood(food);

            return viewFood;
        }

        public bool Delete(Food food)
        {
            Food entity = db.Foods.Find(food.Id);
            db.Foods.Remove(entity);
            db.SaveChanges();
            return true;
        }
    }
}
