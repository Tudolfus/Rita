using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Database.Migrations.Scripts
{
    [Migration(202104292217)]
    public class Migration_2021_04_29_22_17 : Migration
    {
        public override void Down()
        {
            Delete.Table("Products");
        }

        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("Name").AsString(250).NotNullable();
        }
    }
}
