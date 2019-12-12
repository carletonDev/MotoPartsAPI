using MotoPartsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoPartsAPI.Interfaces
{
    public class DbContext:IDbContext
    {
        //factory pattern for instantiating DBContext 
        //can't make an interface for context methods have to instantiate and do Dependency Injection this way making a factory pattern
        //scales though because If you wanted a Parts database or anything else you would just need to make a  new Context and a method to instantiate it in this factory pattern
        public MotoPartsContext MotoPartsContext()
        {
            return new MotoPartsContext();
        }
    }
}
