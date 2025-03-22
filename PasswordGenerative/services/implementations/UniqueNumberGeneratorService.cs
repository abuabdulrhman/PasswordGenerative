using PasswordGenerative.Services.Internal;
using System.Text;

namespace PasswordGenerative.services.implementations
{
    public class UniqueNumberGeneratorService : IUniqueNumberGeneratorService
    {
        public string GenerateUniqueNumbers(int maxLength)
        {
            const string validDigits = "1234567890";
            StringBuilder result = new StringBuilder();
            Random random = new Random();
            HashSet<char> usedChars = new HashSet<char>();

            while (result.Length < maxLength)
            {
                char randomdigit = validDigits[random.Next(validDigits.Length)];

                if (!usedChars.Contains(randomdigit))
                {
                    usedChars.Add(randomdigit);
                    result.Append(randomdigit);
                }
            }
            return result.ToString();
        }

        public string GenerateUniqueNumbersNotStartWithZero(int maxLength)
        {
            const string validDigits = "123456789"; // لا نسمح بـ 0 كبداية
            StringBuilder result = new StringBuilder();
            Random random = new Random();
            HashSet<char> usedChars = new HashSet<char>();

            // اختار رقم عشوائي غير صفر ليكون الرقم الأول
            char firstDigit = validDigits[random.Next(validDigits.Length)];
            result.Append(firstDigit);
            usedChars.Add(firstDigit);

            // نستخدم 0 كجزء من الأرقام المتاحة للخيارات التالية
            const string remainingDigits = "0123456789";

            // استمر في إنشاء الأرقام حتى نصل إلى الحد الأقصى
            while (result.Length < maxLength)
            {
                char randomDigit = remainingDigits[random.Next(remainingDigits.Length)];

                // تحقق مما إذا كان الرقم قد تم استخدامه مسبقًا
                if (!usedChars.Contains(randomDigit))
                {
                    usedChars.Add(randomDigit);
                    result.Append(randomDigit);
                }
            }

            return result.ToString();
        }
    }
}