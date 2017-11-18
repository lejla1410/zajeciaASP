namespace ListaZakupów.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CzasMod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LzDBTests", "CzasModyfikacji", c => c.DateTime());
            DropColumn("dbo.LzDBTests", "costam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LzDBTests", "costam", c => c.String());
            DropColumn("dbo.LzDBTests", "CzasModyfikacji");
        }
    }
}
