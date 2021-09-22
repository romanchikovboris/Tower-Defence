using System;

namespace GameBus
{
    public interface IBus : ISubscribeOnlyBus
    { 
        void Fire<T>(T arg); 
        void Fire<T>(string name, T arg);
    }
}