using FSM;

namespace PlayerFSM
{
    public interface ICharacterState : ITickableWithResult<ICharacterState>, IEnterable, IExitable
    {
        
    }
}