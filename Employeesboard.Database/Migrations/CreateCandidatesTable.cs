using System.Diagnostics.CodeAnalysis;
using FluentMigrator;

namespace Employeesboard.Database.Migrations
{
    [Migration(1)]
    [ExcludeFromCodeCoverage]
    public class CreateCandidatesTable : Migration
    {
        private const string SchemaName = "schCandidates";
        private const string CandidatesTable = "tProfiles";

        public override void Up()
        {
            Create.Schema(SchemaName);

            Create.Table(CandidatesTable).InSchema(SchemaName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Email").AsString(150).NotNullable().Unique()
                .WithColumn("FirstName").AsString(100).NotNullable()
                .WithColumn("LastName").AsString(100).NotNullable()
                .WithColumn("Phone").AsString(20).NotNullable();
            }

        public override void Down()
        {
            Delete.Table(CandidatesTable).InSchema(SchemaName);
            Delete.Schema(SchemaName);
        }
    }
}
