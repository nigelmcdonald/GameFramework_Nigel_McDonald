using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public interface IPlayerObserver
    {
        void Update(IPlayerObserverPattern playerObserverPattern);
    }
}
