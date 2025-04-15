using System;

public class DisabledState : State
{
    private Action _deactiveDelegate;

    public DisabledState(IStateChanger stateChanger, Action deactiveDelegate) : base(stateChanger)
    {
        _deactiveDelegate = deactiveDelegate;
    }

    public override void Enter()
    {
        _deactiveDelegate?.Invoke();
    }
}
