using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.EventModels
{
    // To implement this event to cause an action, IHandle<logonevent> must be implemented in whatever viewmodel will use it
    // Then a private IEventAggregator needs to be created for that viewmodel
    // Then for the constructor of that viewmodel IEventAggregator needs to be a paremeter
    // Within the constructor, set the private IEventAggregator to the parameter being passed in
    // Use the private event aggregator to subscribe to "this"
    // this subscribes the instance to listening for the type of event implemented in IHandle
    public class LogOnEvent
    {

    }
}
