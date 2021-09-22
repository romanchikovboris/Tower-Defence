using System; 
using UnityEngine;

namespace GameBus
{
    public class Collision2dEnterBus : MonoBehaviour, ISubscribeOnlyBus
    {  
        private Bus bus = new Bus();

        public void Subscribe<T>(Action<T> callback) => bus.Subscribe(callback);
        public void Unsubscribe<T>(Action<T> callback) => bus.Unsubscribe(callback);
 
        private void OnCollisionEnter2D(Collision2D collision)
        { 
            foreach (var action in bus.actions.Values)
            {
                var c = collision.collider.GetComponent(action.type);
                if(c == null)
                    continue;
                
                bus.Fire(action.type.FullName, c);
            } 
        }
    }
}