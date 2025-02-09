using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace MB.Model
{
    public class Maharboard
    {
        /// <summary>
        /// Birthdate shall be in UTC format with ISO 8601 standard.
        /// E.g. yyyy-MM-ddTHH:mm:ssZ
        /// </summary>
        [Required(ErrorMessage = "မွေးနေ့ ထည့်ရန် လိုအပ်သည်။")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Person name
        /// </summary>
        [Required(ErrorMessage = "နာမည် ထည့်ရန် လိုအပ်သည်။")]
        public string Name { get; set; }= string.Empty;
        /// <summary>
        /// Gender of the Person. It should be Male or Female
        /// </summary>
        [Required(ErrorMessage = "ကျား/မ ရွေးရန် လိုအပ်သည်။")]
        public Gender? Gender { get; set; }
        /// <summary>
        /// The result of Mahaboard based on the Aphwar such as Puti, Ahdipadi
        /// </summary>
        public string MaharboardNumberResult { get; set; }= string.Empty;
        /// <summary>
        /// The result of Mahaboard based on the Mod
        /// </summary>
        public  string ModResult { get; set; } = string.Empty;
        /// <summary>
        /// Mod of the Mahaboard Calculation
        /// </summary>
        public int Mod { get; set; }
        /// <summary>
        /// Number of the Mahaboard Calculation
        /// </summary>
        public int MaharboardNumber { get; set; }
        /// <summary>
        /// Maharboard Aphwar
        /// </summary>
        public string Aphwar { get; set; } = string.Empty;
        /// <summary>
        /// Warning
        /// </summary>
        public string Warning { get; set; } = string.Empty;
        /// <summary>
        /// Disclaimer
        /// </summary>
        public string Disclaimer { get; set; } = string.Empty;

        [Range(typeof(bool), "true", "true", ErrorMessage = "သင်သည် ဗေဒင်၏ အကျိုးအပြစ်များကို သဘောတူရန် လိုအပ်သည်။")]
        public bool AgreeTerms { get; set; }

        public string BurmeseDay { get; set; } = string.Empty;
    }

    public enum Gender
    {
        Female = 0,
        Male = 1
    }

    public enum Aphwar
    {
        ဘင်္ဂ = 0,
        မရဏ = 1,
        အထွန်း = 2,
        သိုက် = 3,
        ရာဇ = 4,
        ပုတိ = 5,
        အဓိပတိ = 6
        
    }
}
