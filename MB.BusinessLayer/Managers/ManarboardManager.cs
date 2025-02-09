using MB.BusinessLayer.Managers.Interface;
using MB.Model;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MB.BusinessLayer.Managers
{
    public class MaharboardManager : IMaharboardManager
    {
        public Task<Maharboard> Calculate(Maharboard maharboard)
        {   

            // Calculate the day of the week
            // Default DayOfWeek value is 0 for Sunday, 1 for Monday.
            // But Maharboard starts from 1 for Sunday, 2 for Monday.
            int y = (int)maharboard.BirthDate.DayOfWeek + 1; // y is 1 for Sunday, 2 for Monday

            int x = 0; // x is Burmese Calendar year
            // Check the person borns before or after Myanmar New Year.
            if (maharboard.BirthDate > new DateTime(maharboard.BirthDate.Year, 4, 17))
            {
                // born after Myanmar New Year
                x = maharboard.BirthDate.Year - 638;
            }
            else
            {
                // born before Myanmar New Year
                x = maharboard.BirthDate.Year - 639;
            }

            // calculate the mod of Mahaboard
            maharboard.Mod = (x % 7);

            // Calculate the result of Maharboard with Algorithm.
            // Here, y is the day of the week and x is the Burmese Calendar year.
            maharboard.MaharboardNumber = (((7 - y) + (x % 7)) * 2) % 7;

            maharboard.BurmeseDay = GetBurmeseDay(maharboard.BirthDate);
            return Task.FromResult(maharboard);
        }

        public async Task<string> ReadTextFileContext(string filePath)
        {
            string result = string.Empty;

            // Read the result from the file asynchronously
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    result = await reader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle potential errors (e.g., file in use, access denied)
                return $"Error reading file: {ex.Message}";
            }
            return result;
        }

        public static string GetBurmeseDay(DateTime date)
        {
            var burmeseDays = new Dictionary<DayOfWeek, string>
            {
                { DayOfWeek.Sunday, "တနင်္ဂနွေ" },
                { DayOfWeek.Monday, "တနင်္လာ" },
                { DayOfWeek.Tuesday, "အင်္ဂါ" },
                { DayOfWeek.Wednesday, "ဗုဒ္ဓဟူး" },
                { DayOfWeek.Thursday, "ကြာသပတေး" },
                { DayOfWeek.Friday, "သောကြာ" },
                { DayOfWeek.Saturday, "စနေ" }
            };

            return burmeseDays[date.DayOfWeek];
        }
    }
}
