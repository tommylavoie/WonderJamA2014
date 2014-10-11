using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour 
{
	TileManager tileManager;

	// Use this for initialization
	void Start () 
    {
		tileManager = TileManager.getInstance();
		generateTile();
	}

	void generateTile()
	{
		for(int i=0;i<20;i++)
		{
			for(int j=0;j<20;j++)
			{
				Tile tile = new Tile();
				tileManager.changeTile(i,j,tile);
				Debug.Log(i + " : " + j);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
