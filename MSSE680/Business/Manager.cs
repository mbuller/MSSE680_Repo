using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;

namespace Business
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
