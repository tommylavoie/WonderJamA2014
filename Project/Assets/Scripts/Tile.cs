using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile
{
	List<Entity> entities;
    int width;
    int height;
    int type;

	// Use this for initialization
	public Tile (int type)
    {
		entities = new List<Entity>();
        width = 1;
        height = 1;
		this.type = type;
	}

	public void addEntity(Entity entity)
	{
        if(entities != null)
		    entities.Add(entity);
	}

	public void removeEntity(Entity entity)
	{
        if (entities != null)
		    entities.Remove(entity);
	}

	public List<Entity> getEntities()
	{
		return entities;
	}

	void setType(int type)
	{
		this.type = type;
	}

	public int getType()
	{
		return type;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
	    
	}

	public static int EMPTY = -1;
	public static int GROUND = 0;
	public static int MOUNTAIN = 1;
	public static int MUD = 2;
	public static int SPIKE = 3;
}
