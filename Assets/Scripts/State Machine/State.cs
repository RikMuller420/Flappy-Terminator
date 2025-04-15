using System.Collections.Generic;

public class State
{
    private readonly IStateChanger _stateChanger;
    private readonly List<Transition> _transitions;

    public State(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
        _transitions = new List<Transition>();
    }

    public void Update()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.TryTransit(out State nextState))
            {
                _stateChanger.ChangeState(nextState);

                return;
            }
        }

        OnUpdate();
    }

    public void AddTransition(Transition transition)
    {
        _transitions.Add(transition);
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    protected virtual void OnUpdate() { }
}
