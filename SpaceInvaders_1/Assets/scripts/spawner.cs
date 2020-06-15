using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject enemy;
	// Use this for initialization
	void Start () {
		Invoke ( "spawn" , 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void spawn()
	{
		//int index = Random.Range(0,4);
		Vector3 position = new Vector3( Random.Range(-10,10) ,  11 ,  2);
		Instantiate(enemy , position , Quaternion.identity );
		Invoke("spawn" , 1f);
	}
}
