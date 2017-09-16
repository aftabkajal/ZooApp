using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalService
    {
        //create db object
        ZooContext db = new ZooContext();


        public List<ViewAnimal> GetAll()
        {
            //fetch db.animal data
            //pulls all row from table in to ram
            List<Animal> animals = db.Animals.ToList();

            List<ViewAnimal> viewAnimals = new List<ViewAnimal>();

            foreach(Animal animal in animals){
                ViewAnimal viewAnimal = new ViewAnimal(animal);

                viewAnimals.Add(viewAnimal);
            }
            //convert this data into view data
            // return 

            return viewAnimals;

        }

        public bool Save(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
            return true;
        }

        public Animal GetDbModel(int id)
        {
            return db.Animals.Find(id);
        }

        public bool Update(Animal animal)
        {
            db.Entry(animal).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public ViewAnimal Get(int id)
        {
            Animal animal = db.Animals.Find(id);
            ViewAnimal viewAnimal = new ViewAnimal(animal);
            

            return viewAnimal;
        }

        public bool Delete(Animal animal)
        {
            Animal entity = db.Animals.Find(animal.Id);
            db.Animals.Remove(entity);
            db.SaveChanges();
            return true;
        }
    }
}
