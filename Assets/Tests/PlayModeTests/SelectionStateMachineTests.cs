using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SelectionStateMachineTests
{
    [UnityTest]
    public IEnumerator TwoOfAKindSelected()
    {
        CardDisplay option1 = HelperFunctions.getSelectedCard();
        CardDisplay option2 = HelperFunctions.getSelectedCard();
        SelectionStateMachine stateMachine = option1.StateMachine;
        option2.StateMachine = stateMachine;

        yield return null;

        stateMachine.OptionSelected(option1);
        stateMachine.OptionSelected(option2);

        yield return null;
        Assert.IsTrue(option1 == null);
        Assert.IsTrue(option2 == null);
    }

    [UnityTest]
    public IEnumerator DifferentKindsSelected()
    {
        CardDisplay option1 = HelperFunctions.getSelectedCard();
        CardDisplay option2 = HelperFunctions.getSelectedCard();
        SelectionStateMachine stateMachine = option1.StateMachine;
        option2.StateMachine = stateMachine; 
        
        option2.CardChoice = new Circle();

        yield return null;

        option1.Selected();
        option2.Selected();

        yield return null;
        Assert.IsFalse(option1 == null);
        Assert.IsFalse(option2 == null);

        Assert.IsTrue(option1.DisplayImage.sprite == option1.UsualDisplaySprite);
        Assert.IsTrue(option2.DisplayImage.sprite == option2.UsualDisplaySprite);

        Assert.IsTrue(option1.Button.interactable == true);
        Assert.IsTrue(option2.Button.interactable == true);
    }
}
