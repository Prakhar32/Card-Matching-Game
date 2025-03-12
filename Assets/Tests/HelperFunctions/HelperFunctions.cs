using UnityEngine;
using UnityEngine.UI;

public class HelperFunctions
{
    private static Texture2D createTexture()
    {
        var texture = new Texture2D(2, 2, TextureFormat.ARGB32, false);

        texture.SetPixel(0, 0, new Color(1.0f, 1.0f, 1.0f, 0.5f));
        texture.SetPixel(1, 0, Color.clear);
        texture.SetPixel(0, 1, Color.white);
        texture.SetPixel(1, 1, Color.black);

        texture.Apply();
        return texture;
    }

    public static Sprite createSpriteStub()
    {
        Sprite sprite = Sprite.Create(createTexture(), new Rect(0, 0, 2, 2), Vector2.zero);
        return sprite;
    }

    public static CardDisplay getSelectedCard()
    {
        GameObject g = new GameObject();
        CardDisplay selected = g.AddComponent<CardDisplay>();

        Image displayImage = g.AddComponent<Image>();
        selected.DisplayImage = displayImage;
        selected.UsualDisplaySprite = createSpriteStub();
        selected.FlippedDisplaySprite = createSpriteStub();
        selected.CardChoice = new Triangle();

        GameObject machine = new GameObject();
        machine.AddComponent<SelectionStateMachine>();
        selected.StateMachine = machine.GetComponent<SelectionStateMachine>();

        selected.Button = selected.gameObject.AddComponent<Button>();
        
        return selected;
    }
}
