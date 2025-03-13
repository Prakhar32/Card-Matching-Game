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
        CardDisplay display = createDisplay();
        display.CardChoice = new Circle();
        display.FlippedDisplaySprite = Circle;

        display = createDisplay(); 
        display.CardChoice = new Triangle();
        display.FlippedDisplaySprite = Triangle;

        display = createDisplay();
        display.CardChoice = new Circle();
        display.FlippedDisplaySprite = Circle;
    }

    private CardDisplay createDisplay()
    {
        GameObject card = Instantiate(CardPrefab, parent);
        CardDisplay display = card.GetComponent<CardDisplay>();
        display.StateMachine = stateMachine;
        return display;
    }
}
