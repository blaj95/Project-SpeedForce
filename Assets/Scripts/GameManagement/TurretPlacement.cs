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
    private bool iscurrentSelectedGameObjectNull;

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
        if (Input.GetMouseButtonUp(0)&& !EventSystem.current.IsPointerOverGameObject())
        {
            if (selectedTurret)
            {
                PlaceTurret();
            }
        }

        foreach (Touch touch in Input.touches)
        {
            if (Input.touchCount == 1)
            {
                if (touch.phase == TouchPhase.Began && EventSystem.current.currentSelectedGameObject == null)
                {
                    PlaceTurret();
                }
            }
        }
    }

    void PlaceTurret()
    {
        if (PlayerResources.Money >= selectedTurret.GetComponent<TurretBase>().CheckCost())
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Instantiate(selectedTurret, hit.point, Quaternion.identity);
            }   
        }
    }
}