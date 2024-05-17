using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public interface ITokenHandlerService
    {
        Task <string> HandleTokenAsync(string token);
    }
}
