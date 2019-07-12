using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffButtons : MonoBehaviour
{
    public Dictionary<Button, int> buffButtons;

    public List<GameObject> buffTurrets;

    private int index = 0;
    private void Start()
    {
        // attackButtons = new List<Button>();
        buffButtons = new Dictionary<Button,int>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Button b = transform.GetChild(i).GetComponent<Button>();
            buffButtons.Add(b,index);
            b.onClick.AddListener(delegate { Click(b); });
            index += 1;
        }
        gameObject.SetActive(false);
    }

    public void Click(Button button)
    {

        if (buffButtons.ContainsKey(button))
        {
            int i = buffButtons[button];
            GameObject g = buffTurrets[i];
            TurretPlacement.SetTurret(g);
        }

    }
}
