using System;

namespace GameBus
{
    internal class CallbackWrapper
    {
        public object callback;
        public Action<object> wrapperCallback;

        public CallbackWrapper(object callback, Action<object> wrapperCallback)
        {
            this.callback = callback;
            this.wrapperCallback = wrapperCallback;
        }
    }
}