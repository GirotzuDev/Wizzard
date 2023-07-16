using UnityEngine;
using TMPro;
 using System;
public class SpellController : MonoBehaviour
{
    public string textLeftName = "TextLeft";
    public string textRightName = "TextRight";
    public string textUpName = "TextUp";
    public string textDownName = "TextDown";

    private TextMeshProUGUI textLeft;
    private TextMeshProUGUI textRight;
    private TextMeshProUGUI textUp;
    private TextMeshProUGUI textDown;

    private TextMeshProUGUI[] textComponents;
    private string[][] spellBank;
    public KeyCode tmpKey;


    private void fillSpellBank()
    {
        // Initialize the array of arrays
        
        spellBank = new string[3][];

        // Initialize the inner arrays
        spellBank[0] = new string[] { "Apple", "Banana", "Cherry","Beer" };
        spellBank[1] = new string[] { "Dog", "Cat", "Bird", "Fish" };
        spellBank[2] = new string[] { "Red", "Green", "Blue","Beer" };
    }

    private void Start()
    {

        fillSpellBank();
        textComponents = new TextMeshProUGUI[4];
     
        textLeft = GetTextByName(textLeftName);
        textRight = GetTextByName(textRightName);
        textUp = GetTextByName(textUpName);
        textDown = GetTextByName(textDownName);

        textComponents[0] = textLeft;
        textComponents[1] = textUp;
        textComponents[2] = textRight;
        textComponents[3] = textDown;

    }


    private TextMeshProUGUI GetTextByName(string name)
    {
        TextMeshProUGUI text = GameObject.Find(name)?.GetComponent<TextMeshProUGUI>();
        if (text == null)
        {
            Debug.LogError("TextMeshProUGUI component with name " + name + " not found!");
        }
        return text;
    }

    // Use the retrieved TextMeshProUGUI components as needed for your spell logic
    // Example methods:
    public void SetTextLeft(string message)
    {
        if (textLeft != null)
        {
           textComponents[0].text = message;
        }
    }

    public void SetTextRight(string message)
    {
        if (textRight != null)
        {
            textComponents[2].text = message;
        }
    }

    public void SetTextUp(string message)
    {
        if (textUp != null)
        {
            textComponents[1].text = message;
        }
    }

    public void SetTextDown(string message)
    {
        if (textDown != null)
        {
            textComponents[3].text = message;
        }
    }

    public void spelling(int idx)
    {

        if(textComponents[0].text == "")
        {
            if(textComponents[1].text == "")
            {
                if(textComponents[2].text == "")
                {
                    if(textComponents[3].text == "")
                    {
                        Debug.Log("Hexhizo lanzado");
                    }
                    else
                    {
                        if (Input.GetKeyDown(StringToKeyCode(textComponents[3].text.Substring(0,1))))
                        {
                            SetTextDown(textComponents[3].text.Substring(1));
                        }
                    }
                }
                else
                {
                    if (Input.GetKeyDown(StringToKeyCode(textComponents[2].text.Substring(0,1))))
                    {
                        SetTextRight(textComponents[2].text.Substring(1));
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(StringToKeyCode(textComponents[1].text.Substring(0,1))))
                {
                    SetTextUp(textComponents[1].text.Substring(1));
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(StringToKeyCode(textComponents[0].text.Substring(0,1))))
            {
                SetTextLeft(textComponents[0].text.Substring(1));
            }
        }
    }

    private KeyCode StringToKeyCode(string character)
    {
        KeyCode keyCode;
        Enum.TryParse(character.ToUpper(), out keyCode);
        return keyCode;
    }

    private void Update()
    {
    //    SetTextDown("Hechizo pendejo");
        spelling(2);
    }

    // ...
    // Implement your spell logic using the retrieved TextMeshProUGUI components
    // ...
}