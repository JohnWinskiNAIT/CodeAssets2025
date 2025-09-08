using UnityEngine;
using UnityEngine.UI;

public class ButtonManager: MonoBehaviour
{
    [SerializeField] bool[] buttonStates;
    [SerializeField] GameObject[] buttons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonStates = new bool[buttons.Length];
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleButton(int index)
    {
        GameObject left, right, up, down;
        Selectable sel;
        buttonStates[index] = !buttonStates[index];

        sel = buttons[index].GetComponent<Button>().FindSelectableOnLeft();
        if (sel != null)
        {
            left = sel.GetComponent<Button>().gameObject;
        }
        else
        {
            left = null;
        }
        sel = buttons[index].GetComponent<Button>().FindSelectableOnRight();
        if (sel != null)
        {
            right = sel.GetComponent<Button>().gameObject;
        }
        else 
        { 
            right = null; 
        }

        sel = buttons[index].GetComponent<Button>().FindSelectableOnUp();
        if (sel != null)
        {
            up = sel.GetComponent<Button>().gameObject;
        }
        else
        {
            up = null;
        }

        sel = buttons[index].GetComponent<Button>().FindSelectableOnDown();
        if (sel != null)
        {
            down = sel.GetComponent<Button>().gameObject;
        }
        else
        {
            down = null;
        }

        for (int i = 0; i < buttons.Length; i++) 
        {
            if (buttons[i] == left ||
                buttons[i] == right ||
                buttons[i] == up ||
                buttons[i] == down)
                {
                    buttonStates[i] = !buttonStates[i];
                }
        }
        

        UpdateColor();
    }

    void UpdateColor()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttonStates[i])
            {
                buttons[i].GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                buttons[i].GetComponent<Image>().color = Color.black;
            }
        }        
    }
}
