using FluentMigrator;

namespace Infrastructure.DB.Migrations
{
    [Migration(202105020028)]
    public class Migration_2021_05_02_00_28 : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Execute.EmbeddedScript("SaveProductDateInfo");
        }
    }
}
