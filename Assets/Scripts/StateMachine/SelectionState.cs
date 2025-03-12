using UnityEngine;

public interface SelectionState
{
    void OptionSelected(CardDisplay display);
}


public class NoCardSelected : SelectionState
{
    private SelectionStateMachine _stateMachine;
    public NoCardSelected(SelectionStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OptionSelected(CardDisplay display)
    {
        _stateMachine.Display1 = display;
        _stateMachine.SetState(_stateMachine.OneCardSelected);
    }
}

public class OneCardSelected : SelectionState
{
    private SelectionStateMachine _stateMachine;
    public OneCardSelected(SelectionStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OptionSelected(CardDisplay display)
    {
        _stateMachine.Display2 = display;
        _stateMachine.Evaluate();
        _stateMachine.SetState(_stateMachine.NoCardSelected);
    }
}