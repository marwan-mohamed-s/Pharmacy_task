using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_task.Migrations
{
    /// <inheritdoc />
    public partial class insertDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into Doctors (DoctorName, DoctorImg, SpecializationId) values ('Dr. Adam Johnson', '1.png', 1);
                                   insert into Doctors (DoctorName, DoctorImg, SpecializationId) values ('Dr. Michael Smith', '5.png', 2);
                                   insert into Doctors (DoctorName, DoctorImg, SpecializationId) values ('Dr. Daniel Wilson', '3.png', 5);
                                   insert into Doctors (DoctorName, DoctorImg, SpecializationId) values ('Dr. James Anderson', '6.png', 4);
                                   insert into Doctors (DoctorName, DoctorImg, SpecializationId) values ('Dr. William Harris', '2.png', 3);
                                   insert into Doctors (DoctorName, DoctorImg, SpecializationId) values ('Dr. Benjamin Lewis', '4.png', 6);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Doctors");

        }
    }
}
