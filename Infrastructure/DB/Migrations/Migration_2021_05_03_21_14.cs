using FluentMigrator;

namespace Infrastructure.DB.Migrations
{
    [Migration(202105032114)]
    public class Migration_2021_05_03_21_14 : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Execute.EmbeddedScript("GetProducts.sql");
        }
    }
}
