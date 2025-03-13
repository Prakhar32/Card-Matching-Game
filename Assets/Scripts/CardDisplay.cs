using UnityEngine;
using UnityEngine.UI;
using System;

public class CardDisplay : MonoBehaviour
{
    public Image DisplayImage;
    public Sprite UsualDisplaySprite;
    public Sprite FlippedDisplaySprite;

    public Choice CardChoice;
    public SelectionResponse response;
    public Button Button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        try
        {
            if (DisplayImage == null)
                throw new NullReferenceException();
            if (UsualDisplaySprite == null)
                throw new NullReferenceException();
            if (FlippedDisplaySprite == null)
                throw new NullReferenceException();
            if (CardChoice == null)
                throw new NullReferenceException();
            if (response == null)
                throw new NullReferenceException();
            if(Button == null)
                throw new NullReferenceException();
        }
        catch(Exception e)
        {
            Destroy(this);
            throw e;
        }

        DisplayImage.sprite = UsualDisplaySprite;
    }

    public void Selected()
    {
        DisplayImage.sprite = FlippedDisplaySprite;
        Button.interactable = false;
        response.CardSelected(this);
    }

    public void Revert()
    {
        DisplayImage.sprite = UsualDisplaySprite;
        Button.interactable = true;
    }
}
