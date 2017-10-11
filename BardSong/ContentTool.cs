using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong
{
    public class ContentTool
    {
        public string Filepath => _filepath;
        public ContentTool()
        {
            _filepath = string.Empty;
        }
        public ContentTool(string filepath)
        {
            _filepath = filepath;
        }
        private string _filepath;
    }
}
