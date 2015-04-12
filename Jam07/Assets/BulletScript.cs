using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//Invoke("DestroySelf",2f);
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < -6 || Mathf.Abs(this.transform.position.x) > 10 || this.transform.position.y > 10)
		{
			DestroySelf();
		}
	}
	void DestroySelf()
	{
		Debug.Log("Destroyed");
		Destroy(this.gameObject);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name != "BulletPrefab(Clone)" )
            DestroySelf();
    }
}
