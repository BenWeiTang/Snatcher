using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class NonPlayerPlayerStateReference : ASingletonScriptableObject<PlayerStateFactoryManager>
    {
        public ASuperState CurrentState(PlayerStateMachine context)
        {
            return context.CurrentSuperState;
        }
    }
}
