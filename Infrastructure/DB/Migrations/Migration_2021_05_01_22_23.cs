using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Infrastructure.DB.Migrations
{
    [Migration(202105012223)]
    public class Migration_2021_05_01_22_23 : Migration
    {
        public override void Down()
        {
            Delete.Table("ProductsDateInfo");
        }

        public override void Up()
        {
            Create.Table("ProductsDateInfo")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("ProductId").AsInt64().NotNullable().ForeignKey("Products", "Id")
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("Price").AsDecimal(10, 2).NotNullable();
        }
    }
}
