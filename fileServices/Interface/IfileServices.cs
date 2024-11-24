using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileScdervices.Interface;
public interface IfileServices<T>
    {
         List<T> Read();
         void Write(T obj);
    }