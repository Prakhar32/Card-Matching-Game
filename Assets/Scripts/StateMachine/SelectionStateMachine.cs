using UnityEngine;

public interface SelectionResponse
{
    void CardSelected(CardDisplay display);
}


public class SelectionStateMachine : MonoBehaviour, SelectionResponse
{
    private Evaluator _evaluator;

    internal CardDisplay Display1;
    internal CardDisplay Display2;

    internal SelectionState NoCardSelected;
    internal SelectionState OneCardSelected;

    private SelectionState _currentState;

    void Start()
    {
        _evaluator = new Evaluator();
        initialiseStates();
    }

    private void initialiseStates()
    {
        NoCardSelected = new NoCardSelected(this);
        OneCardSelected = new OneCardSelected(this);
        _currentState = NoCardSelected;
    }

    internal void SetState(SelectionState state)
    {
        _currentState = state;
    }

    public void CardSelected(CardDisplay display)
    {
        _currentState.OptionSelected(display);
    }

    internal void Evaluate()
    {
        bool areSame = _evaluator.Evaluate(Display1.CardChoice, Display2.CardChoice);
        if (areSame)
        {
            Destroy(Display1.gameObject);
            Destroy(Display2.gameObject);
        }

        else
        {
            Display1.Revert();
            Display2.Revert();
            Display1 = null;
            Display2 = null;
        }
    }
}
