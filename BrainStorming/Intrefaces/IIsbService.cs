using BrainStorming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorming.Intrefaces
{
    public interface IIsbService
    {
        Task<List<ISB>> GetContracts();
    }
}
