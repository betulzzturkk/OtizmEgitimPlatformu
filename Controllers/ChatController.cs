using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutismEducationPlatform.Web.Services; // ✅ OpenAI servisini dahil et

namespace AutismEducationPlatform.Web.Controllers
{
    public class ChatRequest
    {
        public string Message { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly OpenAIService _openAIService;

        public ChatController(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost]
        public async Task<IActionResult> GetReply([FromBody] ChatRequest request)
        {
            if (string.IsNullOrEmpty(request.Message))
                return new JsonResult(new { reply = "Lütfen bir mesaj yazın." });

            // 🧠 Önce GPT'den yanıt al
            var reply = await _openAIService.GetChatResponseAsync(request.Message);

            if (!string.IsNullOrWhiteSpace(reply) && !reply.Contains("yanıt veremiyor"))
                return new JsonResult(new { reply });

            // ❓ Olmazsa yedek (anahtar kelime) cevap
            reply = GetSimpleReply(request.Message);
            return new JsonResult(new { reply });
        }

        private string GetSimpleReply(string message)
        {
            message = message.ToLower()
                             .Replace("ı", "i")
                             .Replace("ğ", "g")
                             .Replace("ü", "u")
                             .Replace("ş", "s")
                             .Replace("ö", "o")
                             .Replace("ç", "c");

            if (message.Contains("merhaba") || message.Contains("selam"))
                return "Merhaba! Size nasıl yardımcı olabilirim?";

            if (message.Contains("otizm"))
                return "Otizm, sosyal iletişimde ve davranışlarda farklılıklara neden olan nörogelişimsel bir durumdur.";

            if (message.Contains("uyku"))
                return "Otizmli çocuklarda uyku düzeni oluşturmak için her gün aynı saatte yatma ve ekran süresini azaltma önerilir.";

            if (message.Contains("oyun"))
                return "Otizmli çocuklar için sessiz, tekrarlı ve duyu uyaranı az olan oyunlar önerilir.";

            if (message.Contains("iletisim"))
                return "Göz teması kurmak yerine nesneler üzerinden iletişim kurmak otizmli çocuklarda daha etkili olabilir.";

            if (message.Contains("egitim") || message.Contains("ogrenme"))
                return "Eğitimde görsel materyaller, kısa ve net yönergeler otizmli çocuklar için daha uygundur.";

            return "Sorunuzu tam anlayamadım ama size yardımcı olmak isterim. Daha açık ifade edebilir misiniz?";
        }
    }
}
