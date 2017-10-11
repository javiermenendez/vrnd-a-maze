using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAMaze : MonoBehaviour {
	public GameObject wall_A;
	public GameObject wall_B;
	public GameObject wall_Pillar;
	public GameObject wall_Pillar_Ext_Wall_A;
	public GameObject wall_Pillar_Ext_Wall_B;

	// Use this for initialization
	void Start () {
		
		BuildHorizontalWall ();


//		Object.Instantiate(wall_Pillar, new Vector3(2, 4, 6), Quaternion.identity);
//		Object.Instantiate(wall_Pillar_Ext_Wall_A, new Vector3(2, 4, 6), Quaternion.identity);
//		Object.Instantiate(wall_Pillar_Ext_Wall_B, new Vector3(2, 4, 6), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void BuildHorizontalWall()
	{
		// Make an object
		for (int i = 0; i < 100; i=i+8){
			Object.Instantiate(wall_A, new Vector3(i, 0f, 20f), Quaternion.Euler(new Vector3(-90f,0f,0f)));
			Object.Instantiate(wall_B, new Vector3(i + 4f, 0f, 20f), Quaternion.Euler(new Vector3(-90f,0f,0f)));
		}
	}
}
