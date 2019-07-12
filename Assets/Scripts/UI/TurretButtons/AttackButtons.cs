using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackButtons : MonoBehaviour
{
    public Dictionary<Button, int> attackButtons;

    public List<GameObject> attackTurrets;

    private int index = 0;
    private void Start()
    {
       // attackButtons = new List<Button>();
       attackButtons = new Dictionary<Button,int>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Button b = transform.GetChild(i).GetComponent<Button>();
            attackButtons.Add(b,index);
            b.onClick.AddListener(delegate { Click(b); });
            index += 1;
        }
        gameObject.SetActive(false);
    }

    public void Click(Button button)
    {

        if (attackButtons.ContainsKey(button))
        {
            int i = attackButtons[button];
            GameObject g = attackTurrets[i];
            TurretPlacement.SetTurret(g);
        }

    }
    
    
}
