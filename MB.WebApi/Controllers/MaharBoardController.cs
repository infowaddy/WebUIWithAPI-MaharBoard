using MB.BusinessLayer.Managers.Interface;
using MB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace MB.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaharBoardController : ControllerBase
    {
        private IMaharboardManager maharboardManager;
        private readonly IConfiguration configuration;
        string maharboardResultFolder = string.Empty;
        public MaharBoardController(IMaharboardManager _maharboardManager, IConfiguration _configuration)
        {
            this.maharboardManager = _maharboardManager;
            this.configuration = _configuration;            
            maharboardResultFolder = this.configuration["MaharboardResultFolder"];
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Maharboard maharboard)
        {
           

            maharboard = maharboardManager.Calculate(maharboard).Result;

            #region Based on the MaharBoard Result
            string adipadi = "6.txt";
            string puti = "5.txt";
            string raza = "4.txt";
            string thike = "3.txt";
            string ahtun = "2.txt";
            string marana = "1.txt";
            string binga = "0.txt";


            string resultFilePath = maharboardResultFolder;
            switch (maharboard.MaharboardNumber)
            {
                case ((int)Aphwar.ဘင်္ဂ):
                    resultFilePath += binga;
                    maharboard.Aphwar = Aphwar.ဘင်္ဂ.ToString();
                    break;
                case ((int)Aphwar.မရဏ):
                    resultFilePath += marana;
                    maharboard.Aphwar = Aphwar.မရဏ.ToString();
                    break;
                case ((int)Aphwar.အထွန်း):
                    resultFilePath += ahtun;
                    maharboard.Aphwar = Aphwar.အထွန်း.ToString ();
                    break;
                case ((int)Aphwar.သိုက်):
                    resultFilePath += thike;
                    maharboard.Aphwar = Aphwar.သိုက်.ToString();
                    break;
                case ((int)Aphwar.ရာဇ):
                    resultFilePath += raza;
                    maharboard.Aphwar = Aphwar.ရာဇ.ToString();
                    break;
                case ((int)Aphwar.ပုတိ):
                    resultFilePath += puti;
                    maharboard.Aphwar = Aphwar.ပုတိ.ToString();
                    break;
                case ((int)Aphwar.အဓိပတိ):
                    resultFilePath += adipadi;
                    maharboard.Aphwar = Aphwar.အဓိပတိ.ToString();
                    break;
                default:
                    break;
            }
            string result = await maharboardManager.ReadTextFileContext(resultFilePath);
            #endregion

            #region Based on the Mod Result
            string modFilePath = maharboardResultFolder;
            switch (maharboard.Mod)
            {
                case 0:
                    modFilePath += "M0.txt";
                    break;
                case 1:
                    modFilePath += "M1.txt";
                    break;
                case 2:
                    modFilePath += "M2.txt";
                    break;
                case 3:
                    modFilePath += "M3.txt";
                    break;
                case 4:
                    modFilePath += "M4.txt";
                    break;
                case 5:
                    modFilePath += "M5.txt";
                    break;
                case 6:
                    modFilePath += "M6.txt";
                    break;
                default:
                    break;
            }
            string modresult = await maharboardManager.ReadTextFileContext(modFilePath);
            #endregion

            #region Get Warning Message
            string warningFilePath = maharboardResultFolder + "W.txt";
            string warning = await maharboardManager.ReadTextFileContext(warningFilePath);
            #endregion

            #region Get Disclaimer
            string disclaimerFilePath = maharboardResultFolder + "D.txt";
            string disclaimer = await maharboardManager.ReadTextFileContext(disclaimerFilePath);
            #endregion

            maharboard.MaharboardNumberResult = result;
            maharboard.ModResult = modresult;
            maharboard.Warning = warning;
            maharboard.Disclaimer = disclaimer;

            return StatusCode((int)HttpStatusCode.OK, maharboard);
        }
    }
}
