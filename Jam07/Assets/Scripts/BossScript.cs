using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

    int BossState;
    float ElapsedTime;

    int DiagonalShootRate = 5;

    ShootingPatterns CannonA, CannonB, CannonC, CannonD ;

	// Use this for initialization
	void Start () {

        // Initialize the boss in his iddel state
        BossState = 1; // Iddle

        // Reset Timer
        ElapsedTime = 0.0f;
       CannonA =  this.transform.FindChild("Cannon A").GetComponent<ShootingPatterns>();
       CannonB = this.transform.FindChild("Cannon B").GetComponent<ShootingPatterns>();
       CannonC = this.transform.FindChild("Cannon C").GetComponent<ShootingPatterns>();
       CannonD = this.transform.FindChild("Cannon D").GetComponent<ShootingPatterns>();
	
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
                if (Time.frameCount % DiagonalShootRate == 0)
                    CannonA.ShootingRDiagonal();
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

        if (ElapsedTime > 1.0f)
        {
            // Reset Timer
            ElapsedTime = 0.0f;
            if (BossState != 0) BossState = 0;
            else
            {
                //BossState = Random.Range(1, 3);
                BossState = 1;
            }
        }     
    }
}
