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

        public Repository(IRepositoryWriter writer, IDataSet dataSet)
        {
            this.writer = writer;
            this.dataSet = dataSet;           
        }
        
        public void Add(object item)
        {
            var itemType = item.GetType();
            this.dataSet.DataTypes.Add(itemType);
            this.dataSet.Data.Add(item);
        }               

        public List<T> Get<T>()
        {
            return this.dataSet.Data.Where(o => o is T).Select(o => (T)o).ToList() as List<T>;
        }

        public void Write()
        {
            this.writer.Write(this);
        }

        private readonly IRepositoryWriter writer;
        private readonly IDataSet dataSet;
        }
}
