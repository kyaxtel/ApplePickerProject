using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject branchPrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Object instantiations
    public float dropDelay = 1f;
    // Chance for a branch to drop
    public float branchChance = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start dropping apples
        Invoke( "DropObject", 2f );    
    }

    void DropObject() {
        if (Random.value < branchChance)
        {
            GameObject branch = Instantiate(branchPrefab);
            branch.transform.position = transform.position;

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            if (apScript != null) {
                Branch appleScript = branch.GetComponent<Branch>();
                if (appleScript != null) {
                    appleScript.SetSpeed(apScript.appleDropSpeed);
                }
            }
        }
        else {
            GameObject apple = Instantiate<GameObject>( applePrefab );
            apple.transform.position = transform.position;

            // If ApplePicker exists, apply the correct falling speed
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            if (apScript != null) {
                Apple appleScript = apple.GetComponent<Apple>();
                if (appleScript != null) {
                    appleScript.SetSpeed(apScript.appleDropSpeed);
                }
            }
        }
        
        Invoke( "DropObject", dropDelay );
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if ( pos.x < -leftAndRightEdge ) {
            speed = Mathf.Abs( speed ); // Move right
        }
        else if ( pos.x > leftAndRightEdge ) {
            speed = -Mathf.Abs( speed ); // Move left
        }
        // else if ( Random.value < changeDirChance ) {
        //     speed *= -1; // Change direction
        // }
    }

    void FixedUpdate()
    {
        //Random direction changes are now time-based due to FixedUpdate()
        if ( Random.value < changeDirChance ) {
            speed *= -1; // Change direction
        }
    }
}
