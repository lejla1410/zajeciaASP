namespace ListaZakupów.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NazwaMigracji : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LzDBTests", "costam", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LzDBTests", "costam");
        }
    }
}
