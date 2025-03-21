using FluentMigrator;

namespace Bnn.Data.Migrations;

[Migration(20250223221300)]
public class InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("Bananas")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Weight").AsDecimal().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Bananas");
    }
}