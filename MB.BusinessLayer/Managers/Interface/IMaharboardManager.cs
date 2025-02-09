using MB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.BusinessLayer.Managers.Interface
{
    public interface IMaharboardManager
    {
        public Task<Maharboard> Calculate(Maharboard maharboard);
        public Task<string> ReadTextFileContext(string filePath);
    }
}
