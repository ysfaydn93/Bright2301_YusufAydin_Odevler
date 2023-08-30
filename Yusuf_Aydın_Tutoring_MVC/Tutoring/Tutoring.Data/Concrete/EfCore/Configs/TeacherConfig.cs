using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Data.Concrete.EfCore.Configs
{
    public class TeacherConfig
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.BirthOfYear).IsRequired();

            builder.Property(x => x.About).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.PhotoUrl).IsRequired();



            builder.HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName= "Ali",
                    LastName= "Bağnaz",
                    PhotoUrl = "1.png",
                    About="Web Programlama alanında uzman olup, bu alanda eğitim vermektedir.",
                    BirthOfYear = 1980,
                 LessonId= 1,
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Ece",
                    LastName = "Naz",
                    PhotoUrl = "2.png",
                    About = "Java Programlama alanında uzman olup, bu alanda eğitim vermektedir.",
                    BirthOfYear = 1980,
                    LessonId = 2,
                });

        }
    }
}
