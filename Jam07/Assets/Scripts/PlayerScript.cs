using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float Health;

	// Use this for initialization
	void Start () {
        Health = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Health <= 0.0f)
        {
            Debug.Log("The player Died !!!!!");
        }

        if(Input.GetKey("up"))
        {
            this.rigidbody2D.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * 10.0f);
        }

        if (Input.GetKey("down"))
        {
            this.rigidbody2D.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * 10.0f);
        }

        if (Input.GetKey("left"))
        {
            this.rigidbody2D.AddForce(new Vector3(-1.0f, 0.0f, 0.0f) * 10.0f);
        }

        if (Input.GetKey("right"))
        {
            this.rigidbody2D.AddForce(new Vector3(1.0f, 0.0f, 0.0f) * 10.0f);
        }

        if(Input.GetKey("space"))
        {
            Debug.Log("FIRE!\n");
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "eBullet")
        {
            Health -= 10.0f;
        }

        if(col.name == "enemyCraft")
        {
            Health -= 25;
        }
    }


}
