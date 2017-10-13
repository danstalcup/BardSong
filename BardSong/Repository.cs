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

        public Repository()
        {            
            this.data = new List<object>();
            this.dataTypes = new HashSet<string>();
        }
        
        public void Add(object item)
        {
            var itemType = item.GetType();
            this.dataTypes.Add(itemType.Name);
            this.data.Add(item);
        }               

        public List<T> Get<T>()
        {
            return data.Where(o => o is T).Select(o => (T)o).ToList() as List<T>;
        }

        private readonly List<object> data;

        private readonly HashSet<string> dataTypes;
    }
}
