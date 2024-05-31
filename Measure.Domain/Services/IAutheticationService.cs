using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public interface IAutheticationService
    {
        Task AccessTokenToHeader();
        Task<string> GetAccessTokenAsync();
    }
}
