using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

    enum BossState { IDDLE, STREAMSHOT, RADIALSHOOT, CIRCULARSHOT };
    BossState CurState;

	// Use this for initialization
	void Start () {

        // Initialize the boss in his iddel state
        CurState = BossState.IDDLE;
	
	}
	
	// Update is called once per frame
	void Update () {

        UpdateState();
        switch(CurState)
        {
            case BossState.IDDLE:
                Debug.Log("Current State is: " + BossState.IDDLE);
                break;

            case BossState.STREAMSHOT:
                Debug.Log("Current State is: " + BossState.STREAMSHOT);
                break;

            case BossState.RADIALSHOOT:
                Debug.Log("Current State is: " + BossState.RADIALSHOOT);
                break;

            case BossState.CIRCULARSHOT:
                Debug.Log("Current State is: " + BossState.CIRCULARSHOT);
                break;
        }

        
	
	}
    // This Updates the State machine. States are time-based
    void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Space)) CurState++;
       
    }
}
