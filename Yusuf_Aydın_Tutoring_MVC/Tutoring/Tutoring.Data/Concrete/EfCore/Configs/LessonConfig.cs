using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Data.Concrete.EfCore.Configs
{
    public class LessonConfig: IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {  
       
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.ImageUrl).IsRequired();


            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.LessonTime).IsRequired();
            builder.Property(x => x.IsHome).IsRequired();


            builder.HasOne(x => x.Teacher).WithMany(x => x.Lessons).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Lesson
                {
                    Id = 1,
                    Name = "C#",
                    Description = "Bu bölümdeki öğretmenler C# alanında ders vermektedirler.",
                    Price=120,
                    Url= "c-sharp",
                    ImageUrl = "1.jpg",
                    LessonTime =400,
                    TeacherId=1
                },
                new Lesson
                {
                    Id = 2,
                    Name = "Java",
                    Description = "Bu bölümdeki öğretmenler Java alanında ders vermektedirler.",
                    Price = 150,
                    Url = "java",
                    ImageUrl = "2.jpg",
                    LessonTime =500,
                    TeacherId = 2
                });

        }
    }
}
