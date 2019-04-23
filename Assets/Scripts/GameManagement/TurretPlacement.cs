using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretPlacement : MonoBehaviour
{
    public TurretPlacement Instance;
    public static GameObject selectedTurret;
    public Camera mainCamera;
    private int ignoreMask;
    
    void Start()
    {
        Instance = this;
        ignoreMask = 18;
    }

    public static void SetTurret(GameObject turret)
    {
        selectedTurret = turret;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (selectedTurret)
            {
                PlaceTurret();
            }
          
        }
    }

    void PlaceTurret()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Instantiate(selectedTurret, hit.point, Quaternion.identity);
        }
       
    }
}
