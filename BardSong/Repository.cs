using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong
{
    public class Repository
    { 
        public string Filepath { get; set; }                   

        public Repository(IWriter writer)
        {
            this.writer = writer;

            this.data = new List<object>();
            this.dataTypes = new HashSet<Type>();
        }
        
        public void Add(object item)
        {
            var itemType = item.GetType();
            this.dataTypes.Add(itemType);
            this.data.Add(item);
        }               

        public List<T> Get<T>()
        {
            return data.Where(o => o is T).Select(o => (T)o).ToList() as List<T>;
        }

        public void Write()
        {
            this.writer.Write(this);
        }

        private readonly IWriter writer;

        internal readonly List<object> data;

        internal readonly HashSet<Type> dataTypes;
    }
}
