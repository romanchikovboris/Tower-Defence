using System; 
using UnityEngine;

namespace GameBus
{
    public class Trigger2dEnterBus : MonoBehaviour, ISubscribeOnlyBus
    {  
        private Bus bus = new Bus();

        public void Subscribe<T>(Action<T> callback) => bus.Subscribe(callback);
        public void Unsubscribe<T>(Action<T> callback) => bus.Unsubscribe(callback);
 
        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var action in bus.actions.Values)
            {
                var c = other.GetComponent(action.type);
                if(c == null)
                    continue;
                
                bus.Fire(action.type.FullName, c);
            } 
        }
    }
}