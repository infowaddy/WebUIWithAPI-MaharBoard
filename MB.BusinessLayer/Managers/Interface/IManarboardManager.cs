using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.BusinessLayer.Managers.Interface
{
    public interface IManarboardManager
    {
        public Task<string> Calculate(DateOnly date);
    }
}
