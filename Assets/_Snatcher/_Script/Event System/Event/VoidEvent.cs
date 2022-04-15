using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Event/Void Event", fileName = "New Void Event")]
    public class VoidEvent : AGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}