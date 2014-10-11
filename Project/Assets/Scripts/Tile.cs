﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
	List<Entity> entities;
    int width;
    int height;
    int type;

	// Use this for initialization
	void Start ()
    {
		entities = new List<Entity>();
        width = 1;
        height = 1;
		type = 0;
	}

	public void addEntity(Entity entity)
	{
		entities.Add(entity);
	}

	public void removeEntity(Entity entity)
	{
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
	
	// Update is called once per frame
	void FixedUpdate () 
    {
	    
	}
}
