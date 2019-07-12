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
        if (currentPanel == aTurrets)
        {
            aTurrets.SetActive(false);
            currentPanel = null;
        }
        else
        {    
            aTurrets.SetActive(true);
            if(currentPanel)
                currentPanel.SetActive(false);
            currentPanel = aTurrets;
        }
    }
    
    public void OpenTurretMenuD()
    {
        if (currentPanel == dTurrets)
        {
            dTurrets.SetActive(false);
            currentPanel = null;
        }
        else
        {    
            dTurrets.SetActive(true);
            if(currentPanel)
                currentPanel.SetActive(false);
            currentPanel = dTurrets;
        }
    }
    
    public void OpenTurretMenuB()
    {
        if (currentPanel == bTurrets)
        {
            bTurrets.SetActive(false);
            currentPanel = null;
        }
        else
        {    
            bTurrets.SetActive(true);
            if(currentPanel)
                currentPanel.SetActive(false);
            currentPanel = bTurrets;
        }
    }
}
