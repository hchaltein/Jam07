using UnityEngine;
using System.Collections;

public class ShootingPatterns : MonoBehaviour {
public GameObject bullet;
public GameObject bulletSpawnPos;
public Vector2 vel;
	private float startingPoint;
	public float radians;
	
	// Use this for initialization
	void Start () {
		startingPoint = 0f;
		radians = startingPoint;
        /*
        if (this.gameObject.name == "Cannon A")
        {
			InvokeRepeating("ShootingRadial",0.1f,.1f);
			InvokeRepeating("IncreaseAngle",0.1f,.001f);
		}
        //if (this.gameObject.name == "Cannon A")
		//InvokeRepeating("ShootingRDiagonal",0.1f,.1f);
//		if(this.gameObject.name == "Center")
//		InvokeRepeating("ShootingStraight",0.1f,.2f);
        //if (this.gameObject.name == "Cannon A")
		//InvokeRepeating("ShootingLDiagonal",0.1f,.1f);
        */
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

    public void ShootingStraight()
	{
		GameObject bulls = GameObject.Instantiate(bullet,bulletSpawnPos.transform.position, Quaternion.identity) as GameObject;
		bulls.rigidbody2D.AddForce(-Vector2.up*200);
	}
	public void ShootingRDiagonal()
	{
		GameObject bulls = GameObject.Instantiate(bullet,bulletSpawnPos.transform.position, Quaternion.identity) as GameObject;
		bulls.rigidbody2D.AddForce(-Vector2.up *200);
		bulls.rigidbody2D.AddForce(Vector2.right*200);
		bulls.transform.Rotate (Vector3.forward  * 45  );
	
	}
    public void ShootingLDiagonal()
	{
		GameObject bulls = GameObject.Instantiate(bullet,bulletSpawnPos.transform.position, Quaternion.identity) as GameObject;
		bulls.rigidbody2D.AddForce(-Vector2.up *200);
		bulls.rigidbody2D.AddForce(-Vector2.right*200);
		bulls.transform.Rotate (Vector3.forward  * -45  );
		
	}

    public void IncreaseAngle()
    {
		radians+= 0.01f;
	}
    public void ShootingRadial()
	{
		GameObject bulls = GameObject.Instantiate(bullet,bulletSpawnPos.transform.position, Quaternion.identity) as GameObject;
		if (radians > startingPoint + 3.14f) radians = startingPoint;
		bulls.transform.Rotate (Vector3.forward * (radians*180.0f/3.14f) + Vector3.forward  * -90  );
		bulls.rigidbody2D.AddForce(-new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * 200);
		
	}
	
}