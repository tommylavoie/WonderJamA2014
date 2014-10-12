﻿using UnityEngine;
using System.Collections;

public class EnemyScript : Personnage {

    int enemyType; 
    
    /* 0 = rapide mais faible (dep4, 
     * 1 = tank
     * 2 = Lent mais tres fort
    */

	// Use this for initialization
	void Start () 
	{
		setIdentity("Enemy");
	}

	public void setEnemyType(int type)
	{
		this.enemyType = type;
		switch (enemyType)
		{
			// setStats(vie, Attack, speed)
			// ADD SPRITE FOR EVERYONE
			case 0: setStats(3, 1, 5); break;
			case 1: setStats(10, 5, 1); break;
			case 2: setStats(5, 3, 3); break;
		}
	}

	public int getEnemyType()
	{
		return enemyType;
	}
	
	// Update is called once per frame
	void Update () 
	{
		base.Update();
        if (vie <= 0)
        {
            Destroy(this);
            Destroy(sprite);
        }
	}

    // Function 
    public void Action() {
		int lastResort = 0;
        while (speed > 0 && lastResort < 5)
        {
            ZombieController player = isThereNearbyPlayer();
            if (player == null)
            { // Attack if there's a player nearby, move if not
				int random = Random.Range(0, 3);
                switch (random)
                {
					case 0:{
						bool canMove = true;
						foreach (Entity e in TileManager.getInstance().getTile(getX() + 1, getY()).getEntities())
						{
							if (e.getIdentity() == "Enemy")
								canMove = false;
						}
						if (canMove)
							MoveRight();
						break;}
					case 1: {
						bool canMove = true;
						foreach (Entity e in TileManager.getInstance().getTile(getX() - 1, getY()).getEntities())
						{
							if (e.getIdentity() == "Enemy")
								canMove = false;
						}
						if (canMove)
							MoveLeft();
						break;}
					case 2: {
						bool canMove = true;
						foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() + 1).getEntities())
						{
							if (e.getIdentity() == "Enemy")
								canMove = false;
						}
						if (canMove)
							MoveForward();
						break;}
					case 3:{
						bool canMove = true;
						foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() - 1).getEntities())
						{
							if (e.getIdentity() == "Enemy")
								MoveBackward();
						}
						if (canMove)
							MoveBackward();
						break;}
					}
			}
			else // ATTACK THE PLAYER
			{
				Attack(player);
			}
			lastResort++;
		}
	}
	
	// Check if there's a player in one of the four adjacent tile (will only one if the 2 player are adjacent to the enemy
	ZombieController isThereNearbyPlayer() {
		foreach (Entity e in TileManager.getInstance().getTile(getX() + 1, getY()).getEntities())
			if (e.getIdentity() == "Player") 
		{
			return (ZombieController)e;
		}
		foreach (Entity e in TileManager.getInstance().getTile(getX() - 1, getY()).getEntities())
			if (e.getIdentity() == "Player")
		{
			return (ZombieController)e;
		}
		foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() + 1).getEntities())
			if (e.getIdentity() == "Player")
		{
			return (ZombieController)e;
		}
		foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() - 1).getEntities())
            if (e.getIdentity() == "Player")
            {
                return (ZombieController)e;
            }    
        return null;
    }

    

	public static int GHOST = 0;
	public static int ELEPHANT = 1;
	public static int FISH = 2;
}
