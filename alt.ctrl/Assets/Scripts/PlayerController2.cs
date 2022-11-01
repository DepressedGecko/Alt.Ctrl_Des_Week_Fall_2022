using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetPos;
        float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
        transform.position = targetPos;

        targetPos = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothTime, maxMoveSpeed);

    }
}
