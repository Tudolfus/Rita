using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Database.Migrations.Scripts
{
    [Migration(202104292225)]
    public class Migration_2021_04_29_22_25 : Migration
    {
        public override void Down()
        {
            Delete.Table("StoresProducts");
        }

        public override void Up()
        {
            Create.Table("StoresProducts")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("ProductId").AsInt64().NotNullable().ForeignKey("Products", "Id")
                .WithColumn("StoreId").AsInt32().NotNullable().ForeignKey("Stores", "Id")
                .WithColumn("Price").AsDecimal(10, 2).NotNullable();
        }
    }
}
