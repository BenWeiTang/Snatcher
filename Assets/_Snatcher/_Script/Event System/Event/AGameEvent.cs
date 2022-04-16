using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public abstract class AGameEvent<T> : ScriptableObject
    {
        private event Action<T> Event;
        private readonly List<IGameEventListener<T>> _eventListeners = new List<IGameEventListener<T>>();

        /// <summary>
        /// Raise the ScriptableObject Event for all IEventListeners and callbacks to be invoked.
        /// Note that IEventListeners will be invoked before C#-style callbacks are invoked.
        /// </summary>
        /// <param name="item"></param>
        public void Raise(T item)
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised(item);
            }
            
            Event?.Invoke(item);
        }

        /// <summary>
        /// Register IGameEventLister to this ScriptableObject Event
        /// </summary>
        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }

        /// <summary>
        /// Register callback to this ScriptableObject Event
        /// Note using this method of event registration, you have to unregister it either in OnDisable or OnDestroy
        /// </summary>
        public void RegisterListener(Action<T> callback)
        {
            Event += callback;
        }
        
        /// <summary>
        /// Unregister IGameEventListener from this ScriptableObject Event
        /// </summary>
        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }

        /// <summary>
        /// Unregister callback from this ScriptableObject Event
        /// </summary>
        public void UnregisterListener(Action<T> callback)
        {
            Event -= callback;
        }
    }
}