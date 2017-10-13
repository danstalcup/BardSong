using BardSong.Impl;
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

        public Repository(IDataSetManager dataSetManager)
        {            
            this.dataSetManager = dataSetManager;
        }
        
        public void Add(object item)
        {
            var typeOfItem = item.GetType();
            var dataset = dataSetManager.GetDataSet(typeOfItem.Name);
            dataset.Add(item);
        }
        
        private readonly IDataSetManager dataSetManager;
    }
}
