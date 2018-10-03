using System;
using System.Threading.Tasks;

namespace EnixerBanks
{
    public interface IScanFinger
    {
        Task<bool> Scan();
    }
}
