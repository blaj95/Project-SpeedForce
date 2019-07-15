using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static float Money
    {
        get => money;
        set
        {
            money = value;
            UI.OnMoneyChange();
        }
    }

  
    public float startingMoney;
    
    private static float money;
    
    // Start is called before the first frame update
    void Awake()
    {
        money = startingMoney;
    }
}
