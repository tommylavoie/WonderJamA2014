using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TileManager
{
	Tile[][] tiles;

	private static TileManager Instance;

	public static TileManager getInstance()
	{
		if(Instance == null)
		{
			Instance = new TileManager();
		}
		return Instance;
	}

	private TileManager()
	{
		tiles = new Tile[20][];
		for(int i=0;i<20;i++)
		{
			tiles[i] = new Tile[20];
		}
	}

	public Tile getTile(int x, int y)
	{
		return tiles[x][y];
	}

	public void changeTile(int x, int y, Tile tile)
	{
		tiles[x][y] = tile;
	}
}
