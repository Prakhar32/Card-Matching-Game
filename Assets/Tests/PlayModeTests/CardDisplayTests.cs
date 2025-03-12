using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Moq;

public class CardDisplayTests
{
    [UnityTest]
    public IEnumerator DependancyNotInitialised()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        CardDisplay selected = g.AddComponent<CardDisplay>();

        yield return null;
        Assert.IsTrue(selected == null);
    }

    [UnityTest]
    public IEnumerator DependencyInitialised()
    {
        CardDisplay selected = HelperFunctions.getSelectedCard();
        yield return null;
        Assert.IsFalse(selected == null);
    }

    [UnityTest]
    public IEnumerator UsualImageSelectedAtStart()
    {
        CardDisplay selected = HelperFunctions.getSelectedCard();
        Sprite usualSprite = HelperFunctions.createSpriteStub();
        selected.UsualDisplaySprite = usualSprite;

        yield return null;

        Assert.IsTrue(selected.GetComponent<Image>().sprite == usualSprite);
    }

    [UnityTest]
    public IEnumerator SwitchImageOnSelection()
    {
        CardDisplay selected = HelperFunctions.getSelectedCard();
        Sprite flippedSprite = HelperFunctions.createSpriteStub();
        selected.FlippedDisplaySprite = flippedSprite;

        yield return null;

        selected.Selected();
        Assert.IsTrue(selected.GetComponent<Image>().sprite == flippedSprite);
    }
}