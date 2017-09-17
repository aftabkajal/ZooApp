namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUniqueName : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Animals", "IX_AnimalName");
            DropIndex("dbo.Foods", "IX_FoodName");
            CreateIndex("dbo.Animals", "Name", unique: true, name: "IX_AnimalName");
            CreateIndex("dbo.Foods", "Name", unique: true, name: "IX_FoodName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Foods", "IX_FoodName");
            DropIndex("dbo.Animals", "IX_AnimalName");
            CreateIndex("dbo.Foods", "Name", name: "IX_FoodName");
            CreateIndex("dbo.Animals", "Name", name: "IX_AnimalName");
        }
    }
}
