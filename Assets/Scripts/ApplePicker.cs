using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    [Header("Round System")]
    public int round = 1;
    public int maxRounds = 4;
    public TextMeshProUGUI roundText; // UI Text for showing the round
    public float appleDropSpeed = 2.0f; // Base speed of falling apples
    public float speedIncreasePerRound = 0.5f; // Speed increase each round

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i=0; i < numBaskets; i++) {
            GameObject tbasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i );
            tbasketGO.transform.position = pos;
            basketList.Add( tbasketGO );
        }
        if(roundText != null) {
            roundText.text = "Round " + round;
        }
    }

    public void AppleMissed() {
        // Destroy all of the falling Apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] branchArray=GameObject.FindGameObjectsWithTag("Branch");
        foreach ( GameObject tempGO in appleArray ){
            Destroy( tempGO );
        }
        foreach ( GameObject tempGO in branchArray){
            Destroy( tempGO );
        }

        //Destroy one fo the Baskets
        //Get the index of the last Basket in basketList
        int basketIndex = basketList.Count -1;
        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt( basketIndex );
        Destroy( basketGO );

        // If there are no Baskets left, restart the game
        if ( basketList.Count == 0 ) {
            if (round < maxRounds) {
                NextRound();
            }
            else {
                SceneManager.LoadScene( "Game_Over" );
            }
        }
    }

    public void BranchCollected() 
    {
        // Destroy all of the falling Apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] branchArray=GameObject.FindGameObjectsWithTag("Branch");
        foreach ( GameObject tempGO in appleArray ){
            Destroy( tempGO );
        }
        foreach ( GameObject tempGO in branchArray){
            Destroy( tempGO );
        }

        SceneManager.LoadScene( "Game_Over" );
    }

    void NextRound()
    {
        round++;
        numBaskets--;
        appleDropSpeed += speedIncreasePerRound; // Apples fall faster
        for (int i=0; i < numBaskets; i++) {
            GameObject tbasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i );
            tbasketGO.transform.position = pos;
            basketList.Add( tbasketGO );
        }
        if(roundText != null) {
            roundText.text = "Round " + round;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
