using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public Image baseHealthFill;

    public static UI Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        baseHealthFill.fillAmount = HomeBase.currentHealth / HomeBase.baseHealth;
    }

    void BaseHit()
    {
        baseHealthFill.fillAmount = HomeBase.currentHealth / HomeBase.baseHealth;
    }

    void EnemyKilled()
    {
        moneyText.text = "$" + PlayerResources.Money.ToString();
    }

    void MoneyChange()
    {
        moneyText.text = "$" + PlayerResources.Money.ToString();
    }
    
    public static void OnBaseHit()
    {
       Instance.BaseHit();
    }

    public static void OnEnemyKilled()
    {
       Instance.EnemyKilled();
    }

    public static void OnMoneyChange()
    {
        Instance.MoneyChange();
    }
}
