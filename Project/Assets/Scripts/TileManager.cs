using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
		tiles = new Tile[MapGenerator.width][];
		for(int i=0;i<20;i++)
		{
			tiles[i] = new Tile[MapGenerator.height];
            for (int j = 0; j < 20; j++)
            {
                tiles[i][j] = new Tile(Tile.EMPTY);
            }
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

    public void addEntityToTile(int x, int y, Entity entity)
    {
        tiles[x][y].addEntity(entity);
    }

    public void changeEntityPosition(int oldX, int oldY, int newX, int newY, Entity entity)
    {
        tiles[oldX][oldY].removeEntity(entity);
        tiles[newX][newY].addEntity(entity);
    }
}
