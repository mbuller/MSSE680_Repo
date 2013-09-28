using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSE680.DAL;
using MSSE680.Service;

namespace MSSE680.Business
{
    public abstract class Manager
    {
        private SvcFactory svcFactory = SvcFactory.GetInstance();
        protected IService GetService(String name)
        {
            return svcFactory.GetService(name);
        }

    }
}
