using UnityEngine;

namespace Snatcher
{
    public abstract class AReference<T> : ScriptableObject
    {
        public T Value;
    }
}
