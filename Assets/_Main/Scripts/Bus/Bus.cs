using System;
using System.Collections.Generic;
using System.Linq;

namespace GameBus
{
    public class Bus : IBus
    { 
        internal Dictionary<string, CallbackCollection> actions = new Dictionary<string, CallbackCollection>();
        
        public void Subscribe<T>(Action<T> callback)
        { 
            var callbackWrapper = new CallbackWrapper(callback, args => callback((T) args)); 
            var type = typeof(T);
            var key = type.FullName;
            
            if(!actions.ContainsKey(key))
                actions.Add(key, new CallbackCollection(type, new List<CallbackWrapper>()));
            
            var list = actions[key].CallbackWrappers;
            list.Add(callbackWrapper);
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            var key = type.FullName;
            if(!actions.ContainsKey(key))
                return;
            
            var callbackCollection = actions[key];
            var callbackWrapper = callbackCollection.CallbackWrappers.FirstOrDefault(c => c.callback == callback);
            if(callbackWrapper == null)
                return;
            
            callbackCollection.CallbackWrappers.Remove(callbackWrapper);
            if (callbackCollection.CallbackWrappers.Count == 0)
                actions.Remove(key);
        }

        public void Fire<T>(T arg) => Fire(typeof(T).FullName, arg);   
        
        public void Fire<T>(string name, T arg)
        { 
            if(!actions.ContainsKey(name))
                return;
            
            var callbackCollection = actions[name]; 
            foreach (var callbackWrapper in callbackCollection.CallbackWrappers)
                callbackWrapper.wrapperCallback?.Invoke(arg);
        }
    }
}