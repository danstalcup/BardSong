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

        private List<object> _data = new List<object>();
        private HashSet<Type> _dataTypes = new HashSet<Type>();

        public List<string> GetDataTypeNames()
        {
            return _dataTypes.Select(dt => dt.Name).ToList();
        }

        public void Add(object item)
        {
            var itemType = item.GetType();
            this.DataTypes.Add(itemType);
            this.Data.Add(item);
        }

        public List<T> Get<T>(bool exactTypeOnly = false)
        {
            if (exactTypeOnly)
            {
                return this.Data.Where(o => o.GetType().Equals(typeof(T))).Select(o => (T)o).ToList() as List<T>;
            }
            else
            {
                return this.Data.Where(o => o is T).Select(o => (T)o).ToList() as List<T>;
            }
        }
    }
}
