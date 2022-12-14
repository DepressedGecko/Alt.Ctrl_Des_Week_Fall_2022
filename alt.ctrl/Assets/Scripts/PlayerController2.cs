using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public float maxMoveSpeed = 15;
    public float smoothTime = 1f;
    Vector2 currentVelocity;
    bool control;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 targetPos;
        float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
        transform.position = targetPos;*/
        
    
        if(control == true)
        {
            Cursor.lockState = CursorLockMode.None;
            control = false;
        }

        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Recenter");
            Cursor.lockState = CursorLockMode.Locked;
            control = true;
        }
        

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    }
}
