using UnityEngine;

public class Evaluator
{
    public bool Evaluate(Choice choice1, Choice choice2)
    {
        if (choice1.GetType().IsAssignableFrom(choice2.GetType()))
            return true;
        return false;
    }
}
