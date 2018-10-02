using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Interface.Fields
{
    public class Fields : IDisposable
    {
        public int ExecuteScalar_Int = 0;
        public double ExecuteScalar_Double = 0;
        public float ExecuteScalar_Float = 0;
        public long ExecuteScalar_Long = 0;
        public bool ExecuteScalar_Bool =false;
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool _IDispose)
        {
            if (_IDispose)
            {
                ExecuteScalar_Bool = false;
                ExecuteScalar_Double = 0;
                ExecuteScalar_Float = 0;
                ExecuteScalar_Int = 0;
                ExecuteScalar_Long = 0;
            }
        }
    }
}
