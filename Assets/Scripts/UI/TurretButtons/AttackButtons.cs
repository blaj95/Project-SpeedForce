using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackButtons : MonoBehaviour
{
    public Dictionary<int, Button> attackButtons;

    public List<GameObject> attackTurrets;

    private int index = 0;
    private void Start()
    {
       // attackButtons = new List<Button>();
       attackButtons = new Dictionary<int, Button>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Button b = transform.GetChild(i).GetComponent<Button>();
            attackButtons.Add(index,b);
            b.onClick.AddListener(Click);
            index += 1;
        }
    }

    public void Click()
    {
        


    }
    
    
}
