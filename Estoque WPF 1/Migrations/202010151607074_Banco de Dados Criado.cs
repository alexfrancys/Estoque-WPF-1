namespace Estoque_WPF_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancodeDadosCriado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Matricula = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.Int(nullable: false),
                        Telefone = c.Int(nullable: false),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Matricula);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        ImagemPr = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtoes");
            DropTable("dbo.Funcionarios");
        }
    }
}
