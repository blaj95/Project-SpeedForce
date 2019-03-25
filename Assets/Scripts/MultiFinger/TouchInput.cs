using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public GameObject[] markers;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPos = mainCamera.ScreenToWorldPoint(touch.position);
                markers[touch.fingerId].transform.position =
                    new Vector3(touchPos.x, touchPos.y, mainCamera.nearClipPlane);
                markers[touch.fingerId].GetComponent<MeshRenderer>().enabled = true;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPos = mainCamera.ScreenToWorldPoint(touch.position);
                markers[touch.fingerId].transform.position =
                    new Vector3(touchPos.x, touchPos.y, mainCamera.nearClipPlane);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                markers[touch.fingerId].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

//        switch (Input.touchCount)
//        {
//            case 1:
//                Touch touch = Input.GetTouch(0);
//                Vector3 touchPos = new Vector3();
//                if (touch.phase == TouchPhase.Began)
//                {
//                    touchPos = mainCamera.ScreenToWorldPoint(touch.position);
//                    currentMarker1 = Instantiate(touchMarker,new Vector3(touchPos.x, touchPos.y, mainCamera.nearClipPlane), Quaternion.identity);
//                }
//                else if (touch.phase == TouchPhase.Moved)
//                {
//                    touchPos = mainCamera.ScreenToWorldPoint(touch.position);
//                    currentMarker1.transform.position = new Vector3(touchPos.x, touchPos.y, mainCamera.nearClipPlane);
//                }
//                break;
//            case 2:
//                Touch touch2 = Input.GetTouch(1);
//                Vector3 touchPos2 = new Vector3();
//                if (touch2.phase == TouchPhase.Began)
//                {
//                    touchPos = mainCamera.ScreenToWorldPoint(touch2.position);
//                    currentMarker2 = Instantiate(touchMarker,new Vector3(touchPos.x, touchPos.y, mainCamera.nearClipPlane), Quaternion.identity);
//                }
//                else if (touch2.phase == TouchPhase.Moved)
//                {
//                    touchPos = mainCamera.ScreenToWorldPoint(touch2.position);
//                    currentMarker2.transform.position = new Vector3(touchPos.x, touchPos.y, mainCamera.nearClipPlane);
//                }
//                break;
//            default:
//                break;
//               
}
