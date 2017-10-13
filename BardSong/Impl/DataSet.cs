using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong.Impl
{
    public class DataSet : IDataSet
    {
        public List<object> Data
        {
            get
            {
                return _data;
            }
        }

        public HashSet<Type> DataTypes
        {
            get
            {
                return _dataTypes;
            }
        }

        public List<string> DataTypeNames
        {
            get
            {
                return _dataTypes.Select(dt => dt.Name).ToList();
            }
        }

        private List<object> _data = new List<object>();
        private HashSet<Type> _dataTypes = new HashSet<Type>();    
    }
}
