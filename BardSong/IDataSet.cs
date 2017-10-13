using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong
{
    public interface IDataSet
    {
        void Add(object item);

        List<T> Get<T>();
    }
}
