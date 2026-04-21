// ReSharper disable SuspiciousTypeConversion.Global
using System;

namespace FSM
{
    public class StateMachine<TState> where TState : class, ITickableWithResult<TState>
    {
        public TState Current { get; private set; }

        public event Action<TState, TState> OnTransition;

        public void TransitionTo(TState next)
        {
            if (Current == next) return;
            var prev = Current;
            (Current as IExitable)?.Exit();
            Current = next;
            (Current as IEnterable)?.Enter();
            OnTransition?.Invoke(prev, next);
        }

        public void Tick(float dt)
        {
            var next = Current.Tick(dt);
            if (next != null) TransitionTo(next);
        }
    }
}