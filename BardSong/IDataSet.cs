using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardSong
{
    public interface IDataSet
    {
        List<object> Data { get; } 

        HashSet<Type> DataTypes { get; }

        List<string> DataTypeNames { get; }
    }
}
