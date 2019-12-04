namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kupacs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImeIPrezime = c.String(),
                        Recency = c.Int(),
                        Frequency = c.Int(),
                        Monetary = c.Int(),
                        Naplata = c.Int(),
                        Znacaj = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kupacs");
        }
    }
}
