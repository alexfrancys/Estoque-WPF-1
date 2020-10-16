namespace Estoque_WPF_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corrigindotipoimagemproduto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtoes", "ImagemPr", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "ImagemPr", c => c.Byte(nullable: false));
        }
    }
}
