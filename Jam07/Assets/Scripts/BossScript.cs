using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossScript : MonoBehaviour {

    int BossState;
    float ElapsedTime;
    public float BossHP = 300;

    public GameObject BossHPDisplay;

    int DiagonalShootRate = 5;
    int RadialShootRate = 5;
    public int CircularShootRate = 5;

    public int CircularAngle = 10;

    ShootingPatterns CannonA, CannonB, CannonC, CannonD ;

	// Use this for initialization
	void Start () {

        // Initialize the boss in his iddel state
        BossState = 0; // Iddle

        // Reset Timer
        ElapsedTime = 0.0f;

        // Get Cannon children
       CannonA =  this.transform.FindChild("Cannon A").GetComponent<ShootingPatterns>();
       CannonB = this.transform.FindChild("Cannon B").GetComponent<ShootingPatterns>();
       CannonC = this.transform.FindChild("Cannon C").GetComponent<ShootingPatterns>();
       CannonD = this.transform.FindChild("Cannon D").GetComponent<ShootingPatterns>();
	
	}
	
	// Update is called once per frame
	void Update () {

        UpdateState();
        UpdateHealthUI();

        if (BossHP <= 0.0f)
        {
            Debug.Log("You win!");

            //Destroy(this.gameObject);

            Destroy(this.gameObject);
        }

        switch (BossState)
        {
            case 0: // IDDLE
                Debug.Log("Current State is: IDDLE");
                break;

            case 1: // STREAMSHOT
                // Regulates shoot speed
                if (Time.frameCount % DiagonalShootRate == 0)
                {
                    CannonA.ShootingRDiagonal();
                    CannonB.ShootingRDiagonal();
                    CannonC.ShootingLDiagonal();
                    CannonD.ShootingLDiagonal();
                }
                break;

            case 2: // RADIALSHOOT

                // Regulates shoot speed
                if (Time.frameCount % 1 == 0)
                {
                    CannonA.IncreaseAngle();
                    CannonB.IncreaseAngle();
                    CannonC.IncreaseAngle();
                    CannonD.IncreaseAngle();
                }
                // Regulates shoot speed
                if (Time.frameCount % RadialShootRate == 0)
                {
                    CannonA.ShootingRadial();
                    CannonB.ShootingRadial();
                    CannonC.ShootingRadial();
                    CannonD.ShootingRadial();
                }

                break;

            case 3: //CIRCULARSHOT

                // Regulates shoot speed
                if (Time.frameCount % CircularAngle == 0)
                {
                    CannonA.IncreaseAngle();
                    CannonB.IncreaseAngle();
                    CannonC.IncreaseAngle();
                    CannonD.IncreaseAngle();
                }
                // Regulates shoot speed
                if (Time.frameCount % CircularShootRate == 0)
                {
                    CannonA.ShootingRadial();
                    CannonB.ShootingRadial();
                    CannonC.ShootingRadial();
                    CannonD.ShootingRadial();
                }
                break;

            default:
                Debug.Log("Unknown State!!!!!!!!!!!!");
                break;  
        }
	
	}
    // This Updates the State machine. States are time-based
    void UpdateState()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > 3.0f)
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "SelfBulletPrefab(Clone)")
        {
            
            BossHP-= 10.0f;
        }
    }

    public void UpdateHealthUI()
    {
        BossHPDisplay.GetComponent<Text>().text = "Boss HP: " + BossHP.ToString();
    }
}
