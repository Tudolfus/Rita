using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Infrastructure.DB.Migrations
{
    [Migration(202105012221)]
    public class Migration_2021_05_01_22_21 : Migration
    {
        public override void Down()
        {
            Delete.Table("Products");
        }

        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("Name").AsString(250).NotNullable()
                .WithColumn("StoreId").AsInt32().NotNullable().ForeignKey("Stores", "Id");
        }
    }
}
