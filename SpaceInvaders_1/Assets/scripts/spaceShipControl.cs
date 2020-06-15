using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class spaceShipControl : MonoBehaviour {

	Rigidbody2D rigid;
	float speed = 10f;
	public GameObject shoot;
	public GameObject shoot2;
	
	public GameObject explode;
	GameObject explodeTemp;
	
	AudioSource shootAudio;
	
	bool die = false;
	
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		shootAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if( die == false )
		{
			if ( Input.GetKey(KeyCode.A))
			{
				rigid.velocity = new Vector2( -speed  , 0);
			}
			else if ( Input.GetKey(KeyCode.D))
			{
				rigid.velocity = new Vector2( speed , 0);
			}
			else
			{
				rigid.velocity = new Vector2( 0, 0);
			}
			
			
			if ( Input.GetKeyDown(KeyCode.Space) )
			{
				//rigid.velocity = new Vector2( -speed  , 0);
				Instantiate(shoot , new Vector3(transform.position.x,transform.position.y,2f) , Quaternion.identity );
				shootAudio.Play();
			}
			else if ( Input.GetKeyDown(KeyCode.Return) )
			{
				//rigid.velocity = new Vector2( -speed  , 0);
				Instantiate(shoot2 , new Vector3(transform.position.x,transform.position.y+9.5f,2f) , Quaternion.identity );
				shootAudio.Play();
			}
			else if( Input.GetKeyDown(KeyCode.Escape) )
			{
				Application.Quit();
			}
		}
		else
		{
			Invoke ( "reload" , 2f);
		}
		
		
	}
	
	void reload()
	{
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
	}
	
	void OnTriggerEnter2D(Collider2D hit)
	{
		if(die == false)
		{
			if(hit.gameObject.tag == "enemy")
			{
				explodeTemp = Instantiate(explode , transform.position , Quaternion.identity );
				Destroy(explodeTemp,1.5f);
				//Destroy(this.gameObject);
				GetComponent<Renderer>().enabled = false;
				
				die = true;
			}
		}
	}
}
