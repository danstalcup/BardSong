using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong.Impl
{
    public class RepositoryWriter : IRepositoryWriter
    {
        public RepositoryWriter(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void Write(Repository repository)
        {
            throw new NotImplementedException();
        }

        private readonly IFileWriter fileWriter;
    }
}
