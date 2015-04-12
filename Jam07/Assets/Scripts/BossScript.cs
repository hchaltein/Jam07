using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

    int BossState;
    float ElapsedTime;

	// Use this for initialization
	void Start () {

        // Initialize the boss in his iddel state
        BossState = 0; // Iddle

        // Reset Timer
        ElapsedTime = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

        UpdateState();
        switch (BossState)
        {
            case 0: // IDDLE
                Debug.Log("Current State is: IDDLE");
                break;

            case 1: // STREAMSHOT
                Debug.Log("Current State is: STREAMSHOT");
                break;

            case 2: // RADIALSHOOT
                Debug.Log("Current State is: RADIALSHOOT");
                break;

            case 3: //CIRCULARSHOT
                Debug.Log("Current State is: CIRCULARSHOT");
                break;
        }
	
	}
    // This Updates the State machine. States are time-based
    void UpdateState()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > 2.0f)
        {
            // Reset Timer
            ElapsedTime = 0.0f;
            if (BossState != 0) BossState = 0;
            else
            {
                BossState = Random.Range(1, 3);
            }
        }     
    }
}
