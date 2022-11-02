using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
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
        transform.position = targetPos;
        */
    
        if(control == true)
        {
            Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;

            control = false;
        }

        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE");
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            control = true;
        }
        */

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    }
}
