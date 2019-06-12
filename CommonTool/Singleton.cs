using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonFunc
{ 
   public  class  Singleton<T> where T:new()
    {
        static readonly Lazy<T> _instance = new Lazy<T>(() => new T(), true );
        public static  T Instance
        {
            get { return _instance.Value; }
        }

    }
  
}
