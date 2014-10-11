
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
		generate();
	}

	void generateTile()
	{
		/*float initialX = transform.position.x-95;
		float initialY = transform.position.y-95;
		for(int i=0;i<width;i++)
		{
			for(int j=0;j<height;j++)
			{
				Tile tile = new Tile(Tile.MOUNTAIN);
				tileManager.changeTile(i,j,tile);
				Instantiate(groundTile);
				groundTile.transform.position = new Vector3(initialX+(10*j),initialY+(10*i), 0);
			}
		}*/
	}

	void generate()
	{
		float initialX = transform.position.x-95;
		float initialY = transform.position.y-95;

		int mountains = Random.Range (65,81);
		int mud = Random.Range(30, 40);
		int spikes = Random.Range (10,20);

		for(int i=0;i<20;i++)
		{
			Tile tile = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(i,0,tile);
			Instantiate(mountainTile);
			mountainTile.transform.position = new Vector3(initialX+(10*i),initialY+(0), 0);

			Tile tile2 = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(i,19,tile2);
			Instantiate(mountainTile);
			mountainTile.transform.position = new Vector3(initialX+(10*i),initialY+(190), 0);
		}
		for(int i=1;i<19;i++)
		{
			Tile tile = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(0,i,tile);
			Instantiate(mountainTile);
			mountainTile.transform.position = new Vector3(initialX+(0),initialY+(i*10), 0);

			Tile tile2 = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(19,i,tile2);
			Instantiate(mountainTile);
			mountainTile.transform.position = new Vector3(initialX+(190),initialY+(i*10), 0);
		}
		for(int i=1;i<width-1;i++)
		{
			for(int j=1;j<height-1;j++)
			{
				Tile tile = new Tile(Tile.MOUNTAIN);
				tileManager.changeTile(i,j,tile);
				Instantiate(groundTile);
				groundTile.transform.position = new Vector3(initialX+(10*j),initialY+(10*i), 0);
			}
		}

		int cpt = 0;
		while(cpt != mountains)
		{
			int x = Random.Range(1,18);
			int y = Random.Range(1,18);

			if(tileManager.getTile(x,y).getType() != Tile.EMPTY)
			{
				Tile tile = new Tile(Tile.MOUNTAIN);
				tileManager.changeTile(x,y,tile);
				Instantiate(mountainTile);
				mountainTile.transform.position = new Vector3(initialX+(10*x),initialY+(10*y), 0);
				cpt++;
			}
		}

		cpt = 0;
		while(cpt != mud)
		{
			int x = Random.Range(1,18);
			int y = Random.Range(1,18);
			
			if(tileManager.getTile(x,y).getType() != Tile.EMPTY)
			{
				Tile tile = new Tile(Tile.MUD);
				tileManager.changeTile(x,y,tile);
				Instantiate(mudTile);
				mudTile.transform.position = new Vector3(initialX+(10*x),initialY+(10*y), 0);
				cpt++;
			}
		}

		cpt = 0;
		while(cpt != spikes)
		{
			int x = Random.Range(1,18);
			int y = Random.Range(1,18);
			
			if(tileManager.getTile(x,y).getType() != Tile.EMPTY)
			{
				Tile tile = new Tile(Tile.SPIKE);
				tileManager.changeTile(x,y,tile);
				Instantiate(spikeTile);
				spikeTile.transform.position = new Vector3(initialX+(10*x),initialY+(10*y), 0);
				cpt++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
