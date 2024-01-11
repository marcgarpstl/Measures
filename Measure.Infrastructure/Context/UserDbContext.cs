using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Context
{
    public class UserDbContext : DbContext, IUserDbContext
    {
    }
}
