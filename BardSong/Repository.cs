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
            dataSet.Add(item);
        }               

        public List<T> Get<T>(bool exactTypeOnly=false)
        {
            return this.dataSet.Get<T>(exactTypeOnly);            
        }

        public void Write()
        {
            this.writer.Write(this);
        }

        private readonly IRepositoryWriter writer;
        private readonly IDataSet dataSet;
        }
}
