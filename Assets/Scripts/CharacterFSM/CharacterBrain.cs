using FSM;
using UnityEngine;

namespace CharacterFSM
{
    public class CharacterBrain<TState> : MonoBehaviour where TState : class, ITickableWithResult<TState>
    {
        private StateMachine<TState> _sm;

        public void Initialize(StateMachine<TState> sm) => _sm = sm;

        private void Update() => _sm.Tick(Time.deltaTime);
    }
}
