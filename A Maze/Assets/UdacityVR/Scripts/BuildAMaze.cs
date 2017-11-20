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
		// ---------------		-----------------------
		BuildHorizontalWallWithCenterDoor(-36, 44, 20);
		// ------
		// |	|
		// |	|
		// 		|
		BuildXWall(-24,	52,	2);
		BuildZWall(-28, 36, 4);
		BuildZWall(-20, 20, 8);
		//				_____
		// 				|	|
		// -------------	|
		// |				|
		// |____________	|
		// 				|	
		BuildZWall(20, 20, 2);
		BuildXWall(-8, 28, 8);
		BuildZWall(-12, 28, 2);
		BuildXWall(-8, 36, 8);
		BuildZWall(20, 36, 2);
		BuildXWall(24, 44, 2);
		BuildZWall(28, 28, 4);

		//				
		// ------------------
		// |				|
		// |				|
		// |		________|
		// |		|
		// |________|
		//
		BuildXWall(-8, 44, 6);
		BuildZWall(-12, 44, 6);
		BuildZWall(12, 44, 2);
		BuildXWall(16, 52, 4);
		BuildXWall(-8, 68, 10);
		BuildZWall(28, 52, 4);

		//				
		// ------------------|
		// |	_____________|
		// |   |
		// |___|
		//
		BuildZWall(-28, 76, 4);
		BuildXWall(-24, 92, 14);
		BuildXWall(-24, 76, 2);
		BuildZWall(-20, 76, 2);
		BuildXWall(-16, 84, 12);
		BuildZWall(28, 84, 2);

		//  _________________
		// |_________________
		BuildXWall(-8, 76, 10);
		BuildZWall(-12, 68, 2);

		// ---------------		-----------------------
		BuildHorizontalWallWithCenterDoor(-36, 44, 100);

	}


	
	// Update is called once per frame
	void Update () {
		
	}

	private void BuildSquareBox(int x, int z, int lengthInBlocks){
		// Side A
		BuildXWall (x, z, lengthInBlocks);
		// Side B
		BuildZWall (x - (lengthInBlocks * 2), z, lengthInBlocks);
		// Side C
		BuildXWall (x, z + (lengthInBlocks * 4), 2);
		// Side D
		BuildZWall (x  + (lengthInBlocks * 2), z, lengthInBlocks);

	}

	private void BuildHorizontalWallWithCenterDoor(int fromX, int toX, int z)
	{
		// Make an object
		for (int x = fromX; x < toX; x = x + 4)
		{
			if (x != 4 && x != 0) 
			{	
				if (x % 8 == 0)
					Object.Instantiate (wall_A, new Vector3 (x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
				else
					Object.Instantiate (wall_B, new Vector3 (x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
			} 
			else // Open the door
			{
				Debug.Log (x);
				if (x == 0) {
					Object.Instantiate (wall_Pillar_Ext_Wall_A, new Vector3 (-4, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
					Object.Instantiate (wall_Pillar, new Vector3 (-4, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
				} 
				else if (x == 4) 
				{
					Object.Instantiate(wall_Pillar_Ext_Wall_B, new Vector3(x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
					Object.Instantiate(wall_Pillar, new Vector3(x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
				}
			}
		}
	}

	private void BuildXWall(int x, int z, int lengthInBlocks){

		AddPillarToXWall (x, z);
			
		for (int step = 0; step < lengthInBlocks; step++) 
		{
			if (x % 8 == 0)
				Object.Instantiate (wall_A, new Vector3 (x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
			else
				Object.Instantiate (wall_B, new Vector3 (x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));

			x += 4;
		}

		AddPillarToXWall (x, z);
	}

	private void AddPillarToXWall(int x, int z)
	{
		if (x % 8 == 0) 
		{
			Object.Instantiate (wall_Pillar_Ext_Wall_A, new Vector3 (x-4, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
			Object.Instantiate (wall_Pillar, new Vector3 (x-4, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
		}
		else
		{
			Object.Instantiate(wall_Pillar_Ext_Wall_B, new Vector3(x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
			Object.Instantiate(wall_Pillar, new Vector3(x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 0f)));
		}
	}

	private void AddPillarToZWall(int x, int z)
	{
		if (z % 8 == 0) 
		{
			Object.Instantiate (wall_Pillar_Ext_Wall_A, new Vector3 (x, 0, z-4), Quaternion.Euler (new Vector3 (-90f, 0f, 90f)));
			Object.Instantiate (wall_Pillar, new Vector3 (x, 0, z-4), Quaternion.Euler (new Vector3 (-90f, 0f, 90f)));
		}
		else
		{
			Object.Instantiate(wall_Pillar_Ext_Wall_B, new Vector3(x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 90f)));
			Object.Instantiate(wall_Pillar, new Vector3(x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 90f)));
		}
	}

	private void BuildZWall(int x, int z, int lengthInBlocks){
		AddPillarToZWall (x, z);

		for (int step = 0; step < lengthInBlocks; step++) 
		{
			if (x % 8 == 0)
				Object.Instantiate (wall_A, new Vector3 (x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 90f)));
			else
				Object.Instantiate (wall_B, new Vector3 (x, 0, z), Quaternion.Euler (new Vector3 (-90f, 0f, 90f)));

			z += 4;
		}

		AddPillarToZWall (x, z);

	}
}
