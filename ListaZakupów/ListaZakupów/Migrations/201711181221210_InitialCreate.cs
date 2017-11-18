namespace ListaZakupów.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LzDBTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Produkt = c.String(),
                        Ilosc = c.Int(nullable: false),
                        Cena = c.Double(nullable: false),
                        Czas = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LzDBTests");
        }
    }
}
