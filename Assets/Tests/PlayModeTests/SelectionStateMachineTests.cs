using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SelectionStateMachineTests
{
    [UnityTest]
    public IEnumerator TwoOfAKindSelected()
    {
        GameObject g = new GameObject();
        SelectionStateMachine stateMachine = g.AddComponent<SelectionStateMachine>();
        CardDisplay option1 = HelperFunctions.getSelectedCard();
        CardDisplay option2 = HelperFunctions.getSelectedCard();
        stateMachine.OptionSelected(option1);
        stateMachine.OptionSelected(option2);

        yield return null;
        Assert.IsTrue(option1 == null);
        Assert.IsTrue(option2 == null);
    }

    [UnityTest]
    public IEnumerator DifferentKindsSelected()
    {
        GameObject g = new GameObject();
        SelectionStateMachine stateMachine = g.AddComponent<SelectionStateMachine>();
        CardDisplay option1 = HelperFunctions.getSelectedCard();
        CardDisplay option2 = HelperFunctions.getSelectedCard();
        option2.CardChoice = new Circle();
        stateMachine.OptionSelected(option1);
        stateMachine.OptionSelected(option2);

        yield return null;
        Assert.IsFalse(option1 == null);
        Assert.IsFalse(option2 == null);
    }
}
