using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong
{
    public interface IFileWriter
    {
        void WriteToFile(string filepath, string content);
    }
}
