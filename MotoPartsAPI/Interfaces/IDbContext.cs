using Microsoft.EntityFrameworkCore;
using MotoPartsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoPartsAPI.Interfaces
{
   public interface IDbContext
    {
        MotoPartsContext MotoPartsContext();
    }
}
