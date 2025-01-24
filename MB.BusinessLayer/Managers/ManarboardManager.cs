using MB.BusinessLayer.Managers.Interface;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MB.BusinessLayer.Managers
{
    public class MaharboardManager : IManarboardManager
    {
        public async Task<string> Calculate(DateOnly date)
        {
            // Calculate the day of the week
            // Default DayOfWeek value is 0 for Sunday, 1 for Monday.
            // But Maharboard starts from 1 for Sunday, 2 for Monday.
            int y = (int)date.DayOfWeek + 1; // y is 1 for Sunday, 2 for Monday

            int x = 0; // x is Burmese Calendar year
            if (date > new DateOnly(date.Year, 4, 17)) // check if the date is after Burmese New Year
            {
                x = date.Year - 637;
            }
            else
            {
                x = date.Year - 638;
            }
            int z = 0; // z is the Mahaboard result number
            z = (( (7 - x) + (y % 7)) *2) % 7;
            await Task.Delay(1);
            return "မွေးရက်";
        }
    }
}
