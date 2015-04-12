using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float Health;

    public GameObject PlayerHPDisplay;

    public GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
        Health = 100.0f;
        UpdateHealthUI();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHealthUI();
        
        if(Health <= 0.0f)
        {
            Debug.Log("The player Died !!!!!");
            
            //Destroy(this.gameObject);

            Application.LoadLevel("MainMenu");
        }

        if (this.transform.position.y < -6 || Mathf.Abs(this.transform.position.x) > 10 || this.transform.position.y > 10)
        {
            this.transform.position = new Vector3(0.0f, -5.0f, 0.0f);
            this.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
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

        if(Input.GetKeyDown("space"))
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position + new Vector3(0.0f,1.0f,0.0f), this.transform.rotation);
            bullet.transform.Rotate(180.0f, 0.0f, 0.0f);
            bullet.transform.localScale -= bullet.transform.localScale/2;
            bullet.rigidbody2D.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * 200.0f);
            //recoil
            this.rigidbody2D.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * 1.0f);
            Debug.Log("FIRE!\n");
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "BulletPrefab(Clone)")
        {
            Health -= 10.0f;
        }

        if(col.name == "BossCore")
        {
            Health -= 25;
        }
    }


        public void UpdateHealthUI()
    {
        PlayerHPDisplay.GetComponent<Text>().text = "Player HP: " + Health.ToString();
    }
}


