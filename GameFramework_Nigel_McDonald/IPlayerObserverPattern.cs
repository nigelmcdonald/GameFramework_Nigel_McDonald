using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    //template of the observer pattern holder
    public interface IPlayerObserverPattern
    {
        void Subscribe(IPlayerObserver playerObserver);

        //used to notify all of the registered players of changes
        void Notify();
    }
}
