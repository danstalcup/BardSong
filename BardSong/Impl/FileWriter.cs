using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong.Impl
{
    public class FileWriter : IFileWriter
    {
        public void WriteToFile(string filepath, string content)
        {
            File.WriteAllText(filepath, content);
        }
    }
}
