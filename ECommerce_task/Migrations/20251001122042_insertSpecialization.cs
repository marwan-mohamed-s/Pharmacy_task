using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_task.Migrations
{
    /// <inheritdoc />
    public partial class insertSpecialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    insert into Specializations (SpecializationName) values ('Cardiology');
                    insert into Specializations (SpecializationName) values ('Neurology');
                    insert into Specializations (SpecializationName) values ('Pediatrics');
                    insert into Specializations (SpecializationName) values ('Dermatology');
                    insert into Specializations (SpecializationName) values ('Dentistry');
                    insert into Specializations (SpecializationName) values ('Ophthalmology');
                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM Specializations");

        }
    }
}
