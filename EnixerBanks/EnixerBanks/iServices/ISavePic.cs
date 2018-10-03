using System;
using System.IO;
using System.Threading.Tasks;

namespace EnixerBanks
{
    public interface ISavePic
    {
        Task<bool> Save(string path, string _name);
    }
}
