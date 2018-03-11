namespace Fiap.ioT.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medidas");
        }
    }
}
