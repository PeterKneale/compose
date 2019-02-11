using FluentMigrator;

namespace Products.Api.Controllers
{
    [Migration(1)]
    public class ProductMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString();
        }

        public override void Down()
        {
            Delete.Table("Products");
        }
    }
}
