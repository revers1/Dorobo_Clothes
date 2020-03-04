
    namespace DoroboShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblFilterNameGroups", "CategoryId", "dbo.tblCategories");
            DropForeignKey("dbo.tblFilterNameGroups", "FilterNameId", "dbo.tblFilterNames");
            DropForeignKey("dbo.tblFilterNameGroups", "FilterValueId", "dbo.tblFilterValues");
            DropIndex("dbo.tblFilterNameGroups", new[] { "FilterNameId" });
            DropIndex("dbo.tblFilterNameGroups", new[] { "FilterValueId" });
            DropIndex("dbo.tblFilterNameGroups", new[] { "CategoryId" });
            CreateTable(
                "dbo.FilterNameGroupsViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilterNameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.tblFilterNameGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tblFilterNameGroups",
                c => new
                    {
                        FilterNameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilterNameId, t.FilterValueId, t.CategoryId });
            
            DropTable("dbo.FilterNameGroupsViewModels");
            CreateIndex("dbo.tblFilterNameGroups", "CategoryId");
            CreateIndex("dbo.tblFilterNameGroups", "FilterValueId");
            CreateIndex("dbo.tblFilterNameGroups", "FilterNameId");
            AddForeignKey("dbo.tblFilterNameGroups", "FilterValueId", "dbo.tblFilterValues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tblFilterNameGroups", "FilterNameId", "dbo.tblFilterNames", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tblFilterNameGroups", "CategoryId", "dbo.tblCategories", "Id", cascadeDelete: true);
        }
    }
}
