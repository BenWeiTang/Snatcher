using System;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/SO Animation/Move To", fileName = "New MoveTo Animation")]
    public class MoveTo : ScriptableObject
    {
        [SerializeField] private float _duration;
        [SerializeField] private Ease _easeMode;
        
        public async Task PerformAsync(Transform context, Vector3 target, Action onEnterAnimation = null, Action onExitAnimation = null)
        {
            onEnterAnimation?.Invoke();
            await context.DOMove(target, _duration).SetEase(_easeMode).AsyncWaitForCompletion();
            onExitAnimation?.Invoke();
        }
    }
}
