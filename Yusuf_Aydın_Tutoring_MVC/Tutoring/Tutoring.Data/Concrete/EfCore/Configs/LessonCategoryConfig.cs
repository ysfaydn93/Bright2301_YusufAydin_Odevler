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
    public class LessonCategoryConfig : IEntityTypeConfiguration<LessonCategory>
    {
        public void Configure(EntityTypeBuilder<LessonCategory> builder)
        {
            builder.HasKey(lc => new { lc.LessonId, lc.CategoryId });
            builder.HasData(
                new LessonCategory { LessonId = 1, CategoryId = 1 },
                new LessonCategory { LessonId = 2, CategoryId = 2 });
            //    new LessonCategory { LessonId = 2, CategoryId = 1 },
            //new LessonCategory { LessonId = 2, CategoryId = 2 });


            //new LessonCategory { LessonId = 3, CategoryId = 1 },
            //new LessonCategory { LessonId = 4, CategoryId = 1 },
            //new LessonCategory { LessonId = 6, CategoryId = 2 },
            //new LessonCategory { LessonId = 8, CategoryId = 2 },
            //new LessonCategory { LessonId = 9, CategoryId = 2 },
            //new LessonCategory { LessonId = 11, CategoryId = 3 },
            //new LessonCategory { LessonId = 15, CategoryId = 4 },
            //new LessonCategory { LessonId = 16, CategoryId = 4 },
            //new LessonCategory { LessonId = 18, CategoryId = 5 });

        }
    }
}
