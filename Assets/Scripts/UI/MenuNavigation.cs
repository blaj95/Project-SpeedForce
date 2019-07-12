using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public GameObject mainButtons;
    public GameObject turretButtons;
    public GameObject aTurrets;
    public GameObject dTurrets;
    public GameObject bTurrets;
    private GameObject currentPanel;
    
    public void OpenTurretMenu()
    {
        mainButtons.SetActive(false);
    }

    public void Back()
    {
        if(currentPanel)
            currentPanel.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void OpenTurretMenuA()
    {
        if(currentPanel)
            currentPanel.SetActive(false);
        aTurrets.SetActive(true);
        currentPanel = aTurrets;
    }
    
    public void OpenTurretMenuD()
    {
        if(currentPanel)
            currentPanel.SetActive(false);
        dTurrets.SetActive(true);
        currentPanel = dTurrets;
    }
    
    public void OpenTurretMenuB()
    {
        if(currentPanel)
            currentPanel.SetActive(false);
        bTurrets.SetActive(true);
        currentPanel = bTurrets;
    }
}
