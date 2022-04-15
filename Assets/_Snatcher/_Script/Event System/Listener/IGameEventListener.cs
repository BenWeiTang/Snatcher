namespace Snatcher
{
    public interface IGameEventListener<T>
    {
        public void OnEventRaised(T item);
    }
}