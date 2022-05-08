using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Snatcher
{
    public class VaultState : ASubState
    {
        private Vector3 _destination;
        private Vector3 _apex;
        
        public VaultState(PlayerStateMachine currentContext) : base(currentContext)
        {
        }

        public override async void EnterState()
        {
            if (Context.Debug) this.Log("Enter");
            
            CalculateWaypoints();
            await VaultUp();
            await VaultDown();
            Context.SwitchSubState(Factory.Idle);
        }

        public override void ExitState() { }

        public override void UpdateState() { }

        protected override void CheckSwitchState() { }

        private void CalculateWaypoints()
        {
            Transform t = Context.transform;
            
            //TODO: parameterize distance and height
            _destination = t.position + t.forward * 5f;
            _apex = 0.5f * (_destination + t.position);
            _apex.y += 5f;
        }
        
        private async Task VaultUp()
        {
            await Context.transform.DOMove(_apex, 0.25f).SetEase(Ease.OutQuad).AsyncWaitForCompletion();
        }
        
        private async Task VaultDown()
        {
            await Context.transform.DOMove(_destination, 0.25f).SetEase(Ease.InQuad).AsyncWaitForCompletion();
        }
    }
}