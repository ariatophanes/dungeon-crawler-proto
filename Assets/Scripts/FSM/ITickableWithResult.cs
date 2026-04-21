namespace FSM
{
    public interface ITickableWithResult<TState> where TState : class
    {
        TState Tick(float deltaTime);
    }
}