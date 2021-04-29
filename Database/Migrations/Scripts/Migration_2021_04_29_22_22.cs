using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Database.Migrations.Scripts
{
    [Migration(202104292222)]
    public class Migration_2021_04_29_22_22 : Migration
    {
        public override void Down()
        {
            Delete.Table("Stores");
        }

        public override void Up()
        {
            Create.Table("Stores")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("Name").AsString(50).NotNullable();
        }
    }
}
