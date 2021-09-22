using System;
using System.Collections.Generic;
using GameBus;

namespace _Main.Scripts
{
    public class ZoneDetector<T>
    {
        public event Action<IReadOnlyCollection<T>> ObjectsChanged;    
        public event Action AnyEnter;
        public event Action AllExit;
        
        public IReadOnlyCollection<T> Objects => objects; 
        
        private HashSet<T> objects = new HashSet<T>();
        
        private ISubscribeOnlyBus enterBus;
        private ISubscribeOnlyBus exitBus;

        public ZoneDetector(ISubscribeOnlyBus enterBus, ISubscribeOnlyBus exitBus)
        {
            this.enterBus = enterBus;
            this.exitBus = exitBus;  
            
            enterBus.Subscribe<T>(Enter);
            exitBus.Subscribe<T>(Exit);
        }

        private void Enter(T enter)
        {
            if(objects.Contains(enter))
                return;
            
            objects.Add(enter); 
            ObjectsChanged?.Invoke(objects);
            
            if(objects.Count == 1)
                AnyEnter?.Invoke(); 
        }

        private void Exit(T exit)
        {
            if(!objects.Contains(exit))
                return;
             
            objects.Remove(exit); 
            ObjectsChanged?.Invoke(objects);
            
            if(objects.Count == 0)
                AllExit?.Invoke();
        }
    }
}