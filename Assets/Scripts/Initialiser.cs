using UnityEngine;

public class Initialiser : MonoBehaviour
{
    public GameObject CardPrefab;
    public Sprite Circle;
    public Sprite Triangle;
    public Transform parent;
    public SelectionStateMachine stateMachine;

    void Awake()
    {
        GameObject first = Instantiate<GameObject>(CardPrefab, parent);
        CardDisplay display = first.GetComponent<CardDisplay>();
        display.StateMachine = stateMachine;
        display.CardChoice = new Circle();
        display.FlippedDisplaySprite = Circle;

        GameObject second = Instantiate<GameObject>(CardPrefab, parent);
        display = second.GetComponent<CardDisplay>();
        display.StateMachine = stateMachine;
        display.CardChoice = new Triangle();
        display.FlippedDisplaySprite = Triangle;

        GameObject third = Instantiate<GameObject>(CardPrefab, parent);
        display = third.GetComponent<CardDisplay>();
        display.StateMachine = stateMachine;
        display.CardChoice = new Circle();
        display.FlippedDisplaySprite = Circle;
    }
}
