using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong.Impl
{
    public class DataSetManager : IDataSetManager
    {
        
        public IDataSet GetDataSet(string name)
        {            
            if(DataSets == null)
            {
                DataSets = new Dictionary<string, IDataSet>();
            }
                        
            if (!DataSets.Keys.Contains(name))
            {
                DataSets.Add(name, new DataSet());
            }
                        
            return DataSets[name];
        }

        private Dictionary<string, IDataSet> DataSets { get; set; }
    }
}
