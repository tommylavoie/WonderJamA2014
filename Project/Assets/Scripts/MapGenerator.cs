
using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour 
{
	public static int width = 20;
	public static int height = 20;

	TileManager tileManager;
	public GameObject groundTile;
	public GameObject mountainTile;
	public GameObject mudTile;
	public GameObject spikeTile;

	// Use this for initialization
	void Start () 
    {
		tileManager = TileManager.getInstance();
		generateTile();
	}

	void generateTile()
	{
		float initialX = transform.position.x-95;
		float initialY = transform.position.y-95;
		for(int i=0;i<width;i++)
		{
			for(int j=0;j<height;j++)
			{
				Tile tile = new Tile();
				tileManager.changeTile(i,j,tile);
				if(j %2 == 0)
				{
					Instantiate(groundTile);
					groundTile.transform.position = new Vector3(initialX+(10*j),initialY+(10*i), 0);
				}
				else
				{
					Instantiate(mountainTile);
					mountainTile.transform.position = new Vector3(initialX+(10*j),initialY+(10*i), 0);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
