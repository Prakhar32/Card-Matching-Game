using UnityEngine;

public class Initialiser : MonoBehaviour
{
    public GameObject CardPrefab;
    public Sprite Circle;
    public Sprite Triangle;
    public Transform parent;
    
    void Awake()
    {
        SelectionStateMachine stateMachine = new SelectionStateMachine();

        CardDisplay display = createDisplay(stateMachine);
        display.CardChoice = new Circle();
        display.FlippedDisplaySprite = Circle;

        display = createDisplay(stateMachine); 
        display.CardChoice = new Triangle();
        display.FlippedDisplaySprite = Triangle;

        display = createDisplay(stateMachine);
        display.CardChoice = new Circle();
        display.FlippedDisplaySprite = Circle;
    }

    private CardDisplay createDisplay(SelectionStateMachine stateMachine)
    {
        GameObject card = Instantiate(CardPrefab, parent);
        CardDisplay display = card.GetComponent<CardDisplay>();
        display.response = stateMachine;
        return display;
    }
}
