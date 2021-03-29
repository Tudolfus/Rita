using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Database.Migrations.Scripts
{
    [Migration(202103291851)]
    public class Migration_2021_03_29_18_51 : Migration
    {
        public override void Down()
        {
            Delete.Table("Products");
        }

        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("ProductId").AsInt32().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("Price").AsDecimal(10, 2).NotNullable()
                .WithColumn("Name").AsString(250).NotNullable()
                .WithColumn("Amount").AsDecimal(10, 2).NotNullable()
                .WithColumn("Date").AsDateTime().NotNullable();
        }
    }
}