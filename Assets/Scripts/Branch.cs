using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Branch : MonoBehaviour
{
    public static float bottomY = -20f;
    private float fallSpeed = 2.0f; // Default fall speed

    // Method to set fall speed from AppleTree
    public void SetSpeed(float newSpeed) 
    {
        fallSpeed = newSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        // Move the apple down using the current speed
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        
        if ( transform.position.y < bottomY ) {
            Destroy( this.gameObject );
        }    
    }
}

