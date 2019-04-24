using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseButtons : MonoBehaviour
{
    public Dictionary<Button, int> defenseButtons;

    public List<GameObject> defenseTurrets;

    private int index = 0;
    private void Start()
    {
        // attackButtons = new List<Button>();
        defenseButtons = new Dictionary<Button,int>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Button b = transform.GetChild(i).GetComponent<Button>();
            defenseButtons.Add(b,index);
            b.onClick.AddListener(delegate { Click(b); });
            index += 1;
        }
    }

    public void Click(Button button)
    {

        if (defenseButtons.ContainsKey(button))
        {
            int i = defenseButtons[button];
            GameObject g = defenseTurrets[i];
            TurretPlacement.SetTurret(g);
        }

    }
}
