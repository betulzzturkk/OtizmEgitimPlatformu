using Microsoft.AspNetCore.Mvc;
using AutismEducationPlatform.Web.Data;
using AutismEducationPlatform.Web.Models;
using AutismEducationPlatform.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AutismEducationPlatform.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CourseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private async Task<bool> IsInstructor()
        {
            if (!User.Identity.IsAuthenticated)
                return false;

            var user = await _userManager.GetUserAsync(User);
            return await _userManager.IsInRoleAsync(user, "Instructor");
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.IsInstructor = await IsInstructor();
            return View();
        }

        public IActionResult Animals()
        {
            var animals = new List<AnimalViewModel>
            {
                new AnimalViewModel
                {
                    Id = 1,
                    Name = "Kedi",
                    Description = "Miyav!",
                    ImagePath = "/images/animals/cat.jpg",
                    SoundPath = "/sounds/animals/kedi.mp3"
                },
                new AnimalViewModel
                {
                    Id = 2,
                    Name = "Köpek",
                    Description = "Hav hav!",
                    ImagePath = "/images/animals/dog.jpg",
                    SoundPath = "/sounds/animals/kopek.mp3"
                },
                new AnimalViewModel
                {
                    Id = 3,
                    Name = "Kuş",
                    Description = "Cik cik!",
                    ImagePath = "/images/animals/bird.jpg",
                    SoundPath = "/sounds/animals/kus.mp3"
                },
                new AnimalViewModel
                {
                    Id = 4,
                    Name = "Balık",
                    Description = "Glug glug!",
                    ImagePath = "/images/animals/fish.jpg",
                    SoundPath = "/sounds/animals/balik.mp3"
                },
                new AnimalViewModel
                {
                    Id = 5,
                    Name = "Tavşan",
                    Description = "Hıh hıh!",
                    ImagePath = "/images/animals/rabbit.jpg",
                    SoundPath = "/sounds/animals/tavsan.mp3"
                },
                new AnimalViewModel
                {
                    Id = 6,
                    Name = "Kurbağa",
                    Description = "Vrak vrak!",
                    ImagePath = "/images/animals/frog.jpg",
                    SoundPath = "/sounds/animals/kurbaga.mp3"
                },
                new AnimalViewModel
                {
                    Id = 7,
                    Name = "Aslan",
                    Description = "Kükreeme!",
                    ImagePath = "/images/animals/lion.jpg",
                    SoundPath = "/sounds/animals/aslan.mp3"
                },
                new AnimalViewModel
                {
                    Id = 8,
                    Name = "Tavuk",
                    Description = "Gıt gıt gıdak!",
                    ImagePath = "/images/animals/chicken.jpg",
                    SoundPath = "/sounds/animals/tavuk.mp3"
                }
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progresses = _context.AnimalProgress
                    .Where(p => p.UserId == userId)
                    .ToDictionary(p => p.AnimalId, p => p.Progress);

                foreach (var animal in animals)
                {
                    if (progresses.ContainsKey(animal.Id))
                    {
                        animal.Progress = progresses[animal.Id];
                    }
                }
            }

            return View(animals);
        }

        public IActionResult Colors()
        {
            var colors = new List<ColorViewModel>
            {
                new ColorViewModel { Name = "Kırmızı", Description = "Canlı ve dikkat çekici bir renktir.", ImagePath = "/images/colors/kirmizi.jpg", HexCode = "#FF0000", Example = "Kırmızı elma", SoundPath = "/sounds/colors/kirmizi.mp3" },
                new ColorViewModel { Name = "Mavi", Description = "Gökyüzü ve denizin rengidir.", ImagePath = "/images/colors/mavi.jpg", HexCode = "#0000FF", Example = "Mavi gökyüzü", SoundPath = "/sounds/colors/mavi.mp3" },
                new ColorViewModel { Name = "Sarı", Description = "Güneşin rengidir.", ImagePath = "/images/colors/sari.jpg", HexCode = "#FFFF00", Example = "Sarı limon", SoundPath = "/sounds/colors/sari.mp3" },
                new ColorViewModel { Name = "Yeşil", Description = "Doğanın ve çimenlerin rengidir.", ImagePath = "/images/colors/yesil.jpg", HexCode = "#00FF00", Example = "Yeşil yaprak", SoundPath = "/sounds/colors/yesil.mp3" },
                new ColorViewModel { Name = "Turuncu", Description = "Portakalın rengidir.", ImagePath = "/images/colors/turuncu.jpg", HexCode = "#FFA500", Example = "Turuncu portakal", SoundPath = "/sounds/colors/turuncu.mp3" },
                new ColorViewModel { Name = "Mor", Description = "Çiçeklerin güzel rengidir.", ImagePath = "/images/colors/mor.jpg", HexCode = "#800080", Example = "Mor menekşe", SoundPath = "/sounds/colors/mor.mp3" },
                new ColorViewModel { Name = "Pembe", Description = "Tatlı ve yumuşak bir renktir.", ImagePath = "/images/colors/pembe.jpg", HexCode = "#FFC0CB", Example = "Pembe şeker", SoundPath = "/sounds/colors/pembe.mp3" },
                new ColorViewModel { Name = "Kahverengi", Description = "Toprağın rengidir.", ImagePath = "/images/colors/kahverengi.jpg", HexCode = "#8B4513", Example = "Kahverengi ağaç", SoundPath = "/sounds/colors/kahverengi.mp3" },
                new ColorViewModel { Name = "Siyah", Description = "Geceyi temsil eder.", ImagePath = "/images/colors/siyah.jpg", HexCode = "#000000", Example = "Siyah kedi", SoundPath = "/sounds/colors/siyah.mp3" },
                new ColorViewModel { Name = "Beyaz", Description = "Saflığı ve temizliği simgeler.", ImagePath = "/images/colors/beyaz.jpg", HexCode = "#FFFFFF", Example = "Beyaz bulut", SoundPath = "/sounds/colors/beyaz.mp3" }
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progresses = _context.ColorProgress
                    .Where(p => p.UserId == userId)
                    .ToDictionary(p => p.ColorName, p => p.Progress);

                foreach (var color in colors)
                {
                    if (progresses.ContainsKey(color.Name))
                    {
                        color.Progress = progresses[color.Name];
                    }
                }
            }

            return View(colors);
        }

        public IActionResult Shapes()
        {
            var shapes = new List<ShapeViewModel>
            {
                new ShapeViewModel { Name = "Daire", Description = "Yuvarlak şekil", ImagePath = "/images/shapes/daire.jpg", SoundPath = "/sounds/shapes/daire.mp3" },
                new ShapeViewModel { Name = "Kare", Description = "Dört kenarlı eşit şekil", ImagePath = "/images/shapes/kare.jpg", SoundPath = "/sounds/shapes/kare.mp3" },
                new ShapeViewModel { Name = "Üçgen", Description = "Üç kenarlı şekil", ImagePath = "/images/shapes/ucgen.jpg", SoundPath = "/sounds/shapes/ucgen.mp3" },
                new ShapeViewModel { Name = "Dikdörtgen", Description = "Dört kenarlı şekil", ImagePath = "/images/shapes/dikdortgen.jpg", SoundPath = "/sounds/shapes/dikdortgen.mp3" },
                new ShapeViewModel { Name = "Yıldız", Description = "Beş köşeli şekil", ImagePath = "/images/shapes/yildiz.jpg", SoundPath = "/sounds/shapes/yildiz.mp3" },
                new ShapeViewModel { Name = "Altıgen", Description = "Altı kenarlı şekil", ImagePath = "/images/shapes/altigen.jpg", SoundPath = "/sounds/shapes/altigen.mp3" },
                new ShapeViewModel { Name = "Beşgen", Description = "Beş kenarlı şekil", ImagePath = "/images/shapes/besgen.jpg", SoundPath = "/sounds/shapes/besgen.mp3" },
                new ShapeViewModel { Name = "Oval", Description = "Yumurta şekli", ImagePath = "/images/shapes/oval.jpg", SoundPath = "/sounds/shapes/oval.mp3" }
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progresses = _context.ShapeProgress
                    .Where(p => p.UserId == userId)
                    .ToDictionary(p => p.ShapeName, p => p.Progress);

                foreach (var shape in shapes)
                {
                    if (progresses.ContainsKey(shape.Name))
                    {
                        shape.Progress = progresses[shape.Name];
                    }
                }
            }

            return View(shapes);
        }

        public IActionResult Numbers()
        {
            var numbers = new List<NumberViewModel>
            {
                new NumberViewModel { Value = 1, Description = "Bir", ImagePath = "/images/numbers/1.jpg", SoundPath = "/sounds/numbers/1.mp3" },
                new NumberViewModel { Value = 2, Description = "İki", ImagePath = "/images/numbers/2.jpg", SoundPath = "/sounds/numbers/2.mp3" },
                new NumberViewModel { Value = 3, Description = "Üç", ImagePath = "/images/numbers/3.jpg", SoundPath = "/sounds/numbers/3.mp3" },
                new NumberViewModel { Value = 4, Description = "Dört", ImagePath = "/images/numbers/4.jpg", SoundPath = "/sounds/numbers/4.mp3" },
                new NumberViewModel { Value = 5, Description = "Beş", ImagePath = "/images/numbers/5.jpg", SoundPath = "/sounds/numbers/5.mp3" },
                new NumberViewModel { Value = 6, Description = "Altı", ImagePath = "/images/numbers/6.jpg", SoundPath = "/sounds/numbers/6.mp3" },
                new NumberViewModel { Value = 7, Description = "Yedi", ImagePath = "/images/numbers/7.jpg", SoundPath = "/sounds/numbers/7.mp3" },
                new NumberViewModel { Value = 8, Description = "Sekiz", ImagePath = "/images/numbers/8.jpg", SoundPath = "/sounds/numbers/8.mp3" },
                new NumberViewModel { Value = 9, Description = "Dokuz", ImagePath = "/images/numbers/9.jpg", SoundPath = "/sounds/numbers/9.mp3" }
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progresses = _context.NumberProgress
                    .Where(p => p.UserId == userId)
                    .ToDictionary(p => p.NumberValue, p => p.Progress);

                foreach (var number in numbers)
                {
                    if (progresses.ContainsKey(number.Value))
                    {
                        number.Progress = progresses[number.Value];
                    }
                }
            }

            return View(numbers);
        }

        public IActionResult Tales()
        {
            var tales = new List<TaleViewModel>
            {
                new TaleViewModel {
                    Id = 1,
                    Title = "Üç Akıllı Keçi Masalı",
                    Description = "Üç akıllı keçinin macerası.",
                    VideoUrl = "https://www.youtube.com/watch?v=Wmt1vz4ctDw",
                    ThumbnailUrl = "https://img.youtube.com/vi/Wmt1vz4ctDw/hqdefault.jpg"
                },
                new TaleViewModel {
                    Id = 2,
                    Title = "Güzel ve Çirkin Masalı",
                    Description = "Güzel ve Çirkin'in hikayesi.",
                    VideoUrl = "https://www.youtube.com/watch?v=Qxsd0awXhqI",
                    ThumbnailUrl = "https://img.youtube.com/vi/Qxsd0awXhqI/hqdefault.jpg"
                },
                new TaleViewModel {
                    Id = 3,
                    Title = "Karlar Kraliçesi ve Parmak Kız Masalı",
                    Description = "Karlar Kraliçesi ve Parmak Kız'ın masalı.",
                    VideoUrl = "https://www.youtube.com/watch?v=8NpeJ_bWnTk",
                    ThumbnailUrl = "https://img.youtube.com/vi/8NpeJ_bWnTk/hqdefault.jpg"
                },
                new TaleViewModel {
                    Id = 4,
                    Title = "Rapunzel ve Külkedisi",
                    Description = "Rapunzel ve Külkedisi'nin masalı.",
                    VideoUrl = "https://www.youtube.com/watch?v=kZ-NMD1eFSI",
                    ThumbnailUrl = "https://img.youtube.com/vi/kZ-NMD1eFSI/hqdefault.jpg"
                },
                new TaleViewModel {
                    Id = 5,
                    Title = "Karlar Kraliçesi",
                    Description = "Karlar Kraliçesi'nin masalı.",
                    VideoUrl = "https://www.youtube.com/watch?v=HPJHlE7A9Y8",
                    ThumbnailUrl = "https://img.youtube.com/vi/HPJHlE7A9Y8/hqdefault.jpg"
                },
                new TaleViewModel {
                    Id = 6,
                    Title = "Adisebaba Çizgi Film Masallar",
                    Description = "Adisebaba çizgi film masalları.",
                    VideoUrl = "https://www.youtube.com/watch?v=qF29_dJkOIM",
                    ThumbnailUrl = "https://img.youtube.com/vi/qF29_dJkOIM/hqdefault.jpg"
                },
                new TaleViewModel {
                    Id = 7,
                    Title = "Kartaneleri ve Minik Ayıcık",
                    Description = "Kartaneleri ve minik ayıcığın hikayesi.",
                    VideoUrl = "https://www.youtube.com/watch?v=fH0WHwYNLA4",
                    ThumbnailUrl = "https://img.youtube.com/vi/fH0WHwYNLA4/hqdefault.jpg"
                },
                new TaleViewModel {
                    Id = 8,
                    Title = "İnatçı Yavru Fil",
                    Description = "İnatçı yavru filin hikayesi.",
                    VideoUrl = "https://www.youtube.com/watch?v=qaNZkV8d0xs",
                    ThumbnailUrl = "https://img.youtube.com/vi/qaNZkV8d0xs/hqdefault.jpg"
                }
            };
            return View(tales);
        }

        public IActionResult TrafficSigns()
        {
            var signs = new List<TrafficSignViewModel>
            {
                new TrafficSignViewModel { Name = "Dur", ImagePath = "/images/traffic/dur.jpg", SoundPath = "/sounds/traffic/dur.mp3", Description = "Dur işareti: Yolun kesiştiği noktada durulması gerektiğini belirtir." },
                new TrafficSignViewModel { Name = "Yaya Geçidi", ImagePath = "/images/traffic/yaya.jpg", SoundPath = "/sounds/traffic/yaya.mp3", Description = "Yaya geçidi işareti: Yayaların karşıdan karşıya geçebileceği yeri gösterir." },
                new TrafficSignViewModel { Name = "Okul Geçidi", ImagePath = "/images/traffic/okul.jpg", SoundPath = "/sounds/traffic/okul.mp3", Description = "Okul geçidi işareti: Okul yakınında olduğunu ve dikkatli olunması gerektiğini belirtir." },
                new TrafficSignViewModel { Name = "Işıklı İşaret", ImagePath = "/images/traffic/isik.jpg", SoundPath = "/sounds/traffic/isik.mp3", Description = "Işıklı işaret: Trafik ışıklarının olduğu yeri gösterir." },
                new TrafficSignViewModel { Name = "Yön", ImagePath = "/images/traffic/yon.jpg", SoundPath = "/sounds/traffic/yon.mp3", Description = "Yön işareti: Gidilebilecek yönü gösterir." },
                new TrafficSignViewModel { Name = "Bisiklet Yolu", ImagePath = "/images/traffic/bisiklet.jpg", SoundPath = "/sounds/traffic/bisiklet.mp3", Description = "Bisiklet yolu işareti: Bisikletlilerin kullanabileceği yolu gösterir." },
                new TrafficSignViewModel { Name = "Hastane", ImagePath = "/images/traffic/hastane.jpg", SoundPath = "/sounds/traffic/hastane.mp3", Description = "Hastane işareti: Yakında hastane olduğunu belirtir." },
                new TrafficSignViewModel { Name = "Park", ImagePath = "/images/traffic/park.jpg", SoundPath = "/sounds/traffic/park.mp3", Description = "Park işareti: Park alanını gösterir." }
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progresses = _context.TrafficSignProgress
                    .Where(p => p.UserId == userId)
                    .ToDictionary(p => p.SignName, p => p.Progress);

                foreach (var sign in signs)
                {
                    if (progresses.ContainsKey(sign.Name))
                    {
                        sign.Progress = progresses[sign.Name];
                    }
                }
            }

            return View(signs);
        }

        public IActionResult Manners()
        {
            var manners = new List<MannersViewModel>
            {
                new MannersViewModel
                {
                    Title = "Teşekkür Etmek",
                    Description = "Teşekkür etmek, başkalarına karşı saygı göstermenin bir yoludur.",
                    ImagePath = "/images/tesekkur.jpg",
                    Category = "Sosyal",
                    Color = "bg-success",
                    Example = "Birisi size bir şey verdiğinde",
                    CorrectBehavior = "Teşekkür ederim demek"
                }
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progresses = _context.MannerProgress
                    .Where(p => p.UserId == userId)
                    .ToDictionary(p => p.MannerName, p => p.Progress);

                foreach (var manner in manners)
                {
                    if (progresses.ContainsKey(manner.Title))
                    {
                        manner.Progress = progresses[manner.Title];
                    }
                }
            }

            return View(manners);
        }

        public IActionResult SelfExpression()
        {
            var expressions = new List<MannersViewModel>
            {
                new MannersViewModel { Title = "Teşekkür Etmek", Description = "Teşekkür etmeyi öğrenelim.", ImagePath = "/images/manners/tesekkur.jpg", SoundPath = "/sounds/manners/tesekkuretmek.mp3" },
                new MannersViewModel { Title = "Özür Dilemek", Description = "Özür dilemeyi öğrenelim.", ImagePath = "/images/manners/ozur.jpg", SoundPath = "/sounds/manners/ozurdilemek.mp3" },
                new MannersViewModel { Title = "Selamlaşmak", Description = "Selamlaşmayı öğrenelim.", ImagePath = "/images/manners/selam.jpg", SoundPath = "/sounds/manners/selamlasmak.mp3" },
                new MannersViewModel { Title = "Dinlemek", Description = "Başkalarını dinlemeyi öğrenelim.", ImagePath = "/images/manners/dinle.jpg", SoundPath = "/sounds/manners/dinlemek.mp3" },
                new MannersViewModel { Title = "Kapı Çalmak", Description = "Kapı çalmayı öğrenelim.", ImagePath = "/images/manners/kapi.jpg", SoundPath = "/sounds/manners/kapiyicalmak.mp3" },
                new MannersViewModel { Title = "Sıra Beklemek", Description = "Sıra beklemeyi öğrenelim.", ImagePath = "/images/manners/sira.jpg", SoundPath = "/sounds/manners/sirabeklemek.mp3" },
                new MannersViewModel { Title = "Paylaşmak", Description = "Paylaşmayı öğrenelim.", ImagePath = "/images/manners/paylasma.png", SoundPath = "/sounds/manners/paylasmak.mp3" },
                new MannersViewModel { Title = "Sofra Adabı", Description = "Sofra adabını öğrenelim.", ImagePath = "/images/manners/sofra.png", SoundPath = "/sounds/manners/sofraadabi.mp3" }
            };
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);
                var progresses = _context.MannerProgress
                    .Where(p => p.UserId == userId)
                    .ToDictionary(p => p.MannerName, p => p.Progress);
                foreach (var manner in expressions)
                {
                    if (progresses.ContainsKey(manner.Title))
                    {
                        manner.Progress = progresses[manner.Title];
                    }
                }
            }
            return View(expressions);
        }

        public IActionResult EducationalVideos() => View();

        public IActionResult Details(int id)
        {
            switch (id)
            {
                case 1:
                    return RedirectToAction("Animals");
                case 2:
                    return RedirectToAction("Colors");
                case 3:
                    return RedirectToAction("Numbers");
                case 4:
                    return RedirectToAction("Shapes");
                case 5:
                    return RedirectToAction("Tales");
                case 6:
                    return RedirectToAction("TrafficSigns");
                case 7:
                    return RedirectToAction("Manners");
                case 8:
                    return RedirectToAction("EducationalVideos");
                case 9:
                    return RedirectToAction("SelfExpression");
                default:
                    return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAnimalProgress(int animalId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Lütfen giriş yapın.", requireLogin = true });
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progress = await _context.AnimalProgress
                    .FirstOrDefaultAsync(p => p.AnimalId == animalId && p.UserId == userId);

                if (progress == null)
                {
                    progress = new AnimalProgress
                    {
                        AnimalId = animalId,
                        UserId = userId,
                        Progress = 0,
                        InteractionCount = 0,
                        LastInteraction = DateTime.UtcNow
                    };
                    _context.AnimalProgress.Add(progress);
                }

                progress.InteractionCount++;
                progress.LastInteraction = DateTime.UtcNow;
                
                // Her tıklamada %20 artır, maksimum %100
                progress.Progress = Math.Min(100, progress.Progress + 20);

                await _context.SaveChangesAsync();

                return Json(new { success = true, progress = progress.Progress });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveColorProgress([FromBody] ColorProgressInputModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Lütfen giriş yapın.", requireLogin = true });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var progress = await _context.ColorProgress.FirstOrDefaultAsync(p => p.ColorName == model.ColorName && p.UserId == userId);

            if (progress == null)
            {
                progress = new ColorProgress
                {
                    ColorName = model.ColorName,
                    UserId = userId,
                    Progress = model.Progress,
                    InteractionCount = 1,
                    LastInteraction = DateTime.UtcNow
                };
                _context.ColorProgress.Add(progress);
            }
            else
            {
                progress.Progress = model.Progress;
                progress.InteractionCount++;
                progress.LastInteraction = DateTime.UtcNow;
                _context.ColorProgress.Update(progress);
            }

            // CourseProgress tablosunu güncelle
            var courseProgress = await _context.CourseProgress
                .FirstOrDefaultAsync(cp => cp.UserId == userId && cp.CourseName == "Renkler");

            if (courseProgress == null)
            {
                courseProgress = new CourseProgress
                {
                    UserId = userId,
                    CourseId = 2, // Renkler kursunun ID'si
                    CourseName = "Renkler",
                    ProgressPercentage = model.Progress,
                    LastInteraction = DateTime.UtcNow,
                    CompletedActivities = model.Progress >= 100 ? 1 : 0,
                    TotalActivities = 1
                };
                _context.CourseProgress.Add(courseProgress);
            }
            else
            {
                courseProgress.ProgressPercentage = model.Progress;
                courseProgress.LastInteraction = DateTime.UtcNow;
                courseProgress.CompletedActivities = model.Progress >= 100 ? 1 : 0;
                _context.CourseProgress.Update(courseProgress);
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true, progress = progress.Progress });
        }

        [HttpPost]
        public async Task<IActionResult> SaveNumberProgress([FromBody] NumberProgressInputModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Lütfen giriş yapın.", requireLogin = true });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var progress = await _context.NumberProgress.FirstOrDefaultAsync(p => p.NumberValue == model.NumberValue && p.UserId == userId);

            if (progress == null)
            {
                progress = new NumberProgress
                {
                    NumberValue = model.NumberValue,
                    UserId = userId,
                    Progress = model.Progress,
                    InteractionCount = 1,
                    LastInteraction = DateTime.UtcNow
                };
                _context.NumberProgress.Add(progress);
            }
            else
            {
                progress.Progress = model.Progress;
                progress.InteractionCount++;
                progress.LastInteraction = DateTime.UtcNow;
                _context.NumberProgress.Update(progress);
            }

            // CourseProgress tablosunu güncelle
            var courseProgress = await _context.CourseProgress
                .FirstOrDefaultAsync(cp => cp.UserId == userId && cp.CourseName == "Sayılar");

            if (courseProgress == null)
            {
                courseProgress = new CourseProgress
                {
                    UserId = userId,
                    CourseId = 3, // Sayılar kursunun ID'si
                    CourseName = "Sayılar",
                    ProgressPercentage = model.Progress,
                    LastInteraction = DateTime.UtcNow,
                    CompletedActivities = model.Progress >= 100 ? 1 : 0,
                    TotalActivities = 1
                };
                _context.CourseProgress.Add(courseProgress);
            }
            else
            {
                courseProgress.ProgressPercentage = model.Progress;
                courseProgress.LastInteraction = DateTime.UtcNow;
                courseProgress.CompletedActivities = model.Progress >= 100 ? 1 : 0;
                _context.CourseProgress.Update(courseProgress);
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true, progress = progress.Progress });
        }

        [HttpPost]
        public async Task<IActionResult> SaveTrafficSignProgress([FromBody] TrafficSignProgressInputModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Lütfen giriş yapın.", requireLogin = true });
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var progress = await _context.TrafficSignProgress.FirstOrDefaultAsync(p => p.SignName == model.SignName && p.UserId == userId);
            if (progress == null)
            {
                progress = new TrafficSignProgress
                {
                    SignName = model.SignName,
                    UserId = userId,
                    Progress = model.Progress,
                    InteractionCount = 1,
                    LastInteraction = DateTime.UtcNow
                };
                _context.TrafficSignProgress.Add(progress);
            }
            else
            {
                progress.Progress = model.Progress;
                progress.InteractionCount++;
                progress.LastInteraction = DateTime.UtcNow;
            }
            await _context.SaveChangesAsync();
            return Json(new { success = true, progress = progress.Progress });
        }

        [HttpPost]
        public async Task<IActionResult> SaveMannerProgress([FromBody] MannerProgressInputModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Lütfen giriş yapın.", requireLogin = true });
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progress = await _context.MannerProgress
                    .FirstOrDefaultAsync(p => p.MannerName == model.MannerName && p.UserId == userId);

                if (progress == null)
                {
                    progress = new MannerProgress
                    {
                        MannerName = model.MannerName,
                        UserId = userId,
                        Progress = model.Progress,
                        InteractionCount = 1,
                        LastInteraction = DateTime.UtcNow
                    };
                    _context.MannerProgress.Add(progress);
                }
                else
                {
                    progress.Progress = model.Progress;
                    progress.InteractionCount++;
                    progress.LastInteraction = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, progress = progress.Progress });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public class ColorProgressInputModel
        {
            public string ColorName { get; set; }
            public int Progress { get; set; }
        }

        public class NumberProgressInputModel
        {
            public int NumberValue { get; set; }
            public int Progress { get; set; }
        }

        public class TrafficSignProgressInputModel
        {
            public string SignName { get; set; }
            public int Progress { get; set; }
        }

        public class MannerProgressInputModel
        {
            public string MannerName { get; set; }
            public int Progress { get; set; }
        }

        public IActionResult Exams()
        {
            return View();
        }

        public IActionResult PuzzleGame()
        {
            return View();
        }

        public IActionResult MatchingGame()
        {
            return View();
        }

        public IActionResult MemoryGame()
        {
            return View();
        }

        public IActionResult ColorGame()
        {
            return View();
        }

        public IActionResult ClickGame()
        {
            return View();
        }

        public IActionResult SortGame()
        {
            return View();
        }

        public IActionResult AnimalSoundGame()
        {
            return View();
        }

        public IActionResult ShapeGame()
        {
            return View();
        }
    }
}