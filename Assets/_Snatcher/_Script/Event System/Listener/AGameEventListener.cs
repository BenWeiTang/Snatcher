using UnityEngine;
using UnityEngine.Events;

namespace Snatcher
{
    public abstract class AGameEventListener<T, E, UER> : MonoBehaviour, 
        IGameEventListener<T> where E : AGameEvent<T> where UER : UnityEvent<T>
    {
        public E GameEvent
        {
            get => _gameEvent;
            set => _gameEvent = value;
        }
        [SerializeField] private E _gameEvent;
        [SerializeField] private UER _unityEventResponse;

        private void OnEnable()
        {
            if (_gameEvent == null) 
                return;

            _gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (_gameEvent == null)
                return;

            _gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            if (_unityEventResponse != null)
            {
                _unityEventResponse.Invoke(item);
            }
        }
    }
}
