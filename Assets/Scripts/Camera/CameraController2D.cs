using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    //private Vector3 cameraFollowPosition;
    //public Transform cameraTarget;
    //[Header()]
    public float edgeSize = 10f;
    public float moveAmount = 1;
    public float movmentWaitTime = 0.1f;

    private float waitedTime; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(0) && waitedTime >= movmentWaitTime)
        {
            waitedTime = 0;
            if (Input.mousePosition.x < edgeSize)
            {
                transform.position -= new Vector3(moveAmount, 0);
                Input.mousePosition.Set(edgeSize + 1, Input.mousePosition.y, Input.mousePosition.z);
            }

            if (Input.mousePosition.x > Screen.width - edgeSize)
            {
                transform.position += new Vector3(moveAmount, 0);
                Input.mousePosition.Set(Screen.width - edgeSize - 1, Input.mousePosition.y, Input.mousePosition.z);
            }

            if (Input.mousePosition.y < edgeSize)
            {
                transform.position -= new Vector3(0, moveAmount);
                Input.mousePosition.Set(Input.mousePosition.x, edgeSize + 1, Input.mousePosition.z);
            }

            if (Input.mousePosition.y > Screen.height - edgeSize)
            {
                transform.position += new Vector3(0, moveAmount);
                Input.mousePosition.Set(Input.mousePosition.x, Screen.height - edgeSize - 1, Input.mousePosition.z);
            }
        }
        else
        {
            waitedTime += Time.deltaTime;
            Mathf.Clamp(waitedTime, 0, movmentWaitTime);
        }
    }
}
