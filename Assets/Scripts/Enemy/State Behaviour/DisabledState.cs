using System;

public class DisabledState : State
{
    private Action _enemyDeactiveDelegate;

    public DisabledState(IStateChanger stateChanger, Action deactiveDelegate) : base(stateChanger)
    {
        _enemyDeactiveDelegate = deactiveDelegate;
    }

    public override void Enter()
    {
        _enemyDeactiveDelegate?.Invoke();
    }
}
