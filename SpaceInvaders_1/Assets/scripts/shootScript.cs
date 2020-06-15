using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour {

	Rigidbody2D rigid;
	float speed = 20f;
	
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		Destroy(this.gameObject,1f);
	}
	
	// Update is called once per frame
	void Update () {
		rigid.velocity = new Vector2( 0, speed);
	}
}
