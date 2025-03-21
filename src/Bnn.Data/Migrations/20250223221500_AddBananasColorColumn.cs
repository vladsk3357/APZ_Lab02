using FluentMigrator;

namespace Bnn.Data.Migrations;

[Migration(20250223221500)]
public class AddBananasColorColumn : Migration
{
    public override void Up()
    {
        Alter.Table("Bananas")
            .AddColumn("Color").AsString(255).Nullable();
    }

    public override void Down()
    {
        Delete.Column("Color").FromTable("Bananas");
    }
}