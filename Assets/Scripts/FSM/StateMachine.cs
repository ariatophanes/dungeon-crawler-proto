using System;

namespace FSM
{
    public class StateMachine<TState> where TState : class
    {
        private TState _current;
        public TState Current => _current;

        public event Action<TState, TState> OnTransition;

        public void TransitionTo(TState next)
        {
            if (_current == next) return;
            var prev = _current;
            (_current as IExitable)?.Exit();
            _current = next;
            (_current as IEnterable)?.Enter();
            OnTransition?.Invoke(prev, next);
        }

        public void Tick(float deltaTime) => (_current as ITickable)?.Tick(deltaTime);
    }

    public interface IEnterable { void Enter(); }
    public interface IExitable  { void Exit();  }
    public interface ITickable  { void Tick(float deltaTime); }
}