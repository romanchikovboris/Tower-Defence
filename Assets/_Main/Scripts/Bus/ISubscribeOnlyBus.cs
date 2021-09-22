using System;

namespace GameBus
{
    public interface ISubscribeOnlyBus
    {
        void Subscribe<T>(Action<T> callback);
        void Unsubscribe<T>(Action<T> callback);
    }
}