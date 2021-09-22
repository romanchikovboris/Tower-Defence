using System;
using System.Collections.Generic;

namespace GameBus
{ 
    internal class CallbackCollection
    {
        public Type type;
        public List<CallbackWrapper> CallbackWrappers;

        public CallbackCollection(Type type, List<CallbackWrapper> callbackWrappers)
        {
            this.type = type;
            CallbackWrappers = callbackWrappers;
        }
    }
    
}