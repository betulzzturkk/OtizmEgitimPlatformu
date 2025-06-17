using Microsoft.EntityFrameworkCore;
using AutismEducationPlatform.Web.Models;

namespace AutismEducationPlatform.Web.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Courses.Any())
                {
                    return;
                }

                context.Courses.AddRange(
                    new Course
                    {
                        Name = "Hayvanları Tanıyalım",
                        Description = "Çocukların hayvanları tanımasını sağlayan eğlenceli bir kurs",
                        Category = "Hayvanlar",
                        DifficultyLevel = 3,
                        ImageUrl = "/images/courses/animals.jpg",
                        DurationMinutes = 30
                    },
                    new Course
                    {
                        Name = "Renkleri Öğreniyorum",
                        Description = "Temel renkleri öğreten interaktif aktiviteler",
                        Category = "Renkler",
                        DifficultyLevel = 2,
                        ImageUrl = "/images/courses/colors.png",
                        DurationMinutes = 25
                    },
                    new Course
                    {
                        Name = "Sayıları Keşfedelim",
                        Description = "1'den 10'a kadar sayıları öğreten eğlenceli oyunlar",
                        Category = "Sayılar",
                        DifficultyLevel = 4,
                        ImageUrl = "/images/courses/numbers.jpg",
                        DurationMinutes = 35
                    },
                    new Course
                    {
                        Name = "Şekilleri Öğrenelim",
                        Description = "Temel geometrik şekilleri tanıtan eğlenceli aktiviteler",
                        Category = "Şekiller",
                        DifficultyLevel = 2,
                        ImageUrl = "/images/courses/shapes.jpg",
                        DurationMinutes = 25
                    },
                    new Course
                    {
                        Name = "Duygularımız",
                        Description = "Temel duyguları tanıma ve ifade etme aktiviteleri",
                        Category = "Duygular",
                        DifficultyLevel = 3,
                        ImageUrl = "/images/courses/emotions.jpg",
                        DurationMinutes = 30
                    },
                    new Course
                    {
                        Name = "Trafik İşaretlerini Öğrenelim",
                        Description = "Temel trafik işaretlerini ve anlamlarını öğreten eğitici içerik",
                        Category = "Trafik",
                        DifficultyLevel = 4,
                        ImageUrl = "/images/courses/traffic.jpg",
                        DurationMinutes = 40
                    },
                    new Course
                    {
                        Name = "Görgü Kuralları",
                        Description = "Temel görgü kurallarını öğreten interaktif aktiviteler",
                        Category = "Görgü Kuralları",
                        DifficultyLevel = 3,
                        ImageUrl = "/images/courses/manners.jpg",
                        DurationMinutes = 35
                    },
                    new Course
                    {
                        Name = "Eğitici Masallar",
                        Description = "Öğretici ve eğlenceli masallar koleksiyonu",
                        Category = "Masallar",
                        DifficultyLevel = 2,
                        ImageUrl = "/images/courses/stories.jpg",
                        DurationMinutes = 45
                    },
                    new Course
                    {
                        Name = "Eğitici Videolar",
                        Description = "Çeşitli konularda eğitici video içerikleri",
                        Category = "Videolar",
                        DifficultyLevel = 1,
                        ImageUrl = "/images/courses/videos.jpg",
                        DurationMinutes = 50
                    }
                );

                if (!context.Tales.Any())
                {
                    context.Tales.AddRange(
                        new Tale
                        {
                            Title = "Üç Akıllı Keçi Masalı",
                            Description = "Üç akıllı keçinin macerası.",
                            VideoUrl = "https://www.youtube.com/watch?v=Wmt1vz4ctDw",
                            ThumbnailUrl = "https://img.youtube.com/vi/Wmt1vz4ctDw/hqdefault.jpg"
                        },
                        new Tale
                        {
                            Title = "Güzel ve Çirkin Masalı",
                            Description = "Güzel ve Çirkin'in hikayesi.",
                            VideoUrl = "https://www.youtube.com/watch?v=Qxsd0awXhqI",
                            ThumbnailUrl = "https://img.youtube.com/vi/Qxsd0awXhqI/hqdefault.jpg"
                        },
                        new Tale
                        {
                            Title = "Karlar Kraliçesi ve Parmak Kız Masalı",
                            Description = "Karlar Kraliçesi ve Parmak Kız'ın masalı.",
                            VideoUrl = "https://www.youtube.com/watch?v=8NpeJ_bWnTk",
                            ThumbnailUrl = "https://img.youtube.com/vi/8NpeJ_bWnTk/hqdefault.jpg"
                        },
                        new Tale
                        {
                            Title = "Rapunzel ve Külkedisi",
                            Description = "Rapunzel ve Külkedisi'nin masalı.",
                            VideoUrl = "https://www.youtube.com/watch?v=kZ-NMD1eFSI",
                            ThumbnailUrl = "https://img.youtube.com/vi/kZ-NMD1eFSI/hqdefault.jpg"
                        },
                        new Tale
                        {
                            Title = "Karlar Kraliçesi",
                            Description = "Karlar Kraliçesi'nin masalı.",
                            VideoUrl = "https://www.youtube.com/watch?v=HPJHlE7A9Y8",
                            ThumbnailUrl = "https://img.youtube.com/vi/HPJHlE7A9Y8/hqdefault.jpg"
                        },
                        new Tale
                        {
                            Title = "Adisebaba Çizgi Film Masallar",
                            Description = "Adisebaba çizgi film masalları.",
                            VideoUrl = "https://www.youtube.com/watch?v=qF29_dJkOIM",
                            ThumbnailUrl = "https://img.youtube.com/vi/qF29_dJkOIM/hqdefault.jpg"
                        },
                        new Tale
                        {
                            Title = "Kartaneleri ve Minik Ayıcık",
                            Description = "Kartaneleri ve minik ayıcığın hikayesi.",
                            VideoUrl = "https://www.youtube.com/watch?v=fH0WHwYNLA4",
                            ThumbnailUrl = "https://img.youtube.com/vi/fH0WHwYNLA4/hqdefault.jpg"
                        },
                        new Tale
                        {
                            Title = "İnatçı Yavru Fil",
                            Description = "İnatçı yavru filin hikayesi.",
                            VideoUrl = "https://www.youtube.com/watch?v=qaNZkV8d0xs",
                            ThumbnailUrl = "https://img.youtube.com/vi/qaNZkV8d0xs/hqdefault.jpg"
                        }
                    );
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
} 