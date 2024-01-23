using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitectureMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Products (Name,Description,Price,Stock,Image,CategoryId) " +
                "values ('Caderno espiral','Caderno espiral 100 folhas',7.45,50,'caderno1.jpg',1)");
            
            mb.Sql("Insert Into Products (Name,Description,Price,Stock,Image,CategoryId) " +
                   "values ('Estojo escolar','Estojo cinza',5.65,70,'estojo1.jpg',1)");
           
            mb.Sql("Insert Into Products (Name,Description,Price,Stock,Image,CategoryId) " +
                           "values ('Borracha escolar','Borracha branca pequena',3.25,80,'borracha.jpg',1)");
           
            mb.Sql("Insert Into Products (Name,Description,Price,Stock,Image,CategoryId) " +
                           "values ('Calculadora escolar','Calculadora simples',15.39,20,'calculadora.jpg',2)");

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Products");
        }
    }
}
