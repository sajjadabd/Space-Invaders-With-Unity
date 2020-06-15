using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript1 : MonoBehaviour {

	GameObject spaceShip;
	public GameObject explode;
	GameObject explodeTemp;

	Rigidbody2D rigid;
	float speed = 6f;
	
	// Use this for initialization
	void Start () {
		spaceShip = GameObject.FindGameObjectWithTag("Player");
		rigid = GetComponent<Rigidbody2D>();
		//Destroy(this.gameObject,4f);
	}
	
	// Update is called once per frame
	void Update () {
		//Mathf.Abs(spaceShip.transform.position.x-transform.position.x)
		//if( transform.position.x > spaceShip.transform.position.x )
		if( transform.position.y < 5f )
		{
			if( Mathf.Abs(spaceShip.transform.position.x-transform.position.x) < 0.5f )
			{
				rigid.velocity = new Vector2( 0 , rigid.velocity.y);
			}
			else if( transform.position.x > spaceShip.transform.position.x )
			{
				rigid.velocity = new Vector2( -speed , rigid.velocity.y);
			}
			else if( transform.position.x < spaceShip.transform.position.x )
			{
				rigid.velocity = new Vector2( speed , rigid.velocity.y);
			}
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D hit)
	{
		if(hit.gameObject.tag == "shoot")
		{
			explodeTemp = Instantiate(explode , transform.position , Quaternion.identity );
			Destroy(explodeTemp,1f);
			Destroy(hit.gameObject);
			Destroy(this.gameObject);
			//print("kill enemy");
		}
	}
}
