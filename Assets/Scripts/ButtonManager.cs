using UnityEngine;
using UnityEngine.UI;

public class ButtonManager: MonoBehaviour
{
    [SerializeField] bool[] buttonStates;
    [SerializeField] GameObject[] buttons;

    int[][] easyPattern = new int[32][];

    int randPattern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonStates = new bool[buttons.Length];

        // Set the patterns for the easy difficulty.
        easyPattern[0] = new int[] { 2, 4, 6, 8 };
        easyPattern[1] = new int[] { 1, 3, 5, 7 };
        easyPattern[2] = new int[] { 0 };
        easyPattern[3] = new int[] { 2, 6 };
        easyPattern[4] = new int[] { 2 };
        easyPattern[5] = new int[] { 0, 3 };
        easyPattern[6] = new int[] { 4 };
        easyPattern[7] = new int[] { 6 };
        easyPattern[8] = new int[] { 8 };
        easyPattern[9] = new int[] { 0, 1 };
        easyPattern[10] = new int[] { 0, 5 };
        easyPattern[11] = new int[] { 0, 7 };
        easyPattern[12] = new int[] { 4, 8 };
        easyPattern[13] = new int[] { 0, 2, 3 };
        easyPattern[14] = new int[] { 0, 2, 3, 5, 7, 8 };
        easyPattern[15] = new int[] { 1, 2, 4, 8 };
        easyPattern[16] = new int[] { 2, 3, 4, 8 };
        easyPattern[17] = new int[] { 0, 2 };
        easyPattern[18] = new int[] { 6, 8 };
        easyPattern[19] = new int[] { 0, 1, 2, 4, 6, 8 };
        easyPattern[20] = new int[] { 1, 3, 4, 5, 7 };
        easyPattern[21] = new int[] { 3, 5, 6, 8 };
        easyPattern[22] = new int[] { 3, 5 };
        easyPattern[23] = new int[] { 1, 4, 7 };
        easyPattern[24] = new int[] { 1, 4, 5, 8 };
        easyPattern[25] = new int[] { 0, 3, 4, 5, 8 };
        easyPattern[26] = new int[] { 0, 1, 7, 8 };
        easyPattern[27] = new int[] { 0, 1, 3, 6, 8 };
        easyPattern[28] = new int[] { 0, 1, 3, 5, 6, 7 };
        easyPattern[29] = new int[] { 0, 4, 6 };
        easyPattern[30] = new int[] { 0, 2, 5, 6, 8 };
        easyPattern[31] = new int[] { 0, 2, 6, 7 };

        randPattern = Random.Range(0, easyPattern.Length);

        for (int i = 0; i < easyPattern[randPattern].Length; i++)
        {
            buttonStates[easyPattern[randPattern][i]] = true;
        }
        
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
