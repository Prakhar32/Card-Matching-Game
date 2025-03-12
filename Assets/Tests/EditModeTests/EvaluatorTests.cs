using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EvaluatorTests
{
    [Test]
    public void TwoOfSameKindMatch()
    {
        Evaluator evaluator = new Evaluator();
        Choice choice1 = new Circle();
        Choice choice2 = new Circle();

        bool result = evaluator.Evaluate(choice1, choice2);
        Assert.IsTrue(result);
    }

    [Test]
    public void TwoOfDifferentKindMatch()
    {
        Evaluator evaluator = new Evaluator();
        Choice choice1 = new Triangle();
        Choice choice2 = new Circle();

        bool result = evaluator.Evaluate(choice1, choice2);
        Assert.IsFalse(result);
    }
}
