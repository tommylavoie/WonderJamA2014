using UnityEngine;
using System.Collections;

public class Personnage : Entity {

    public int vie;
    public int vieMaximale;
    public int attaque;
    public int speed = 1;
    public int movingScale = 2;
    int movementUnit;
    int movementX;
    int movementY;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame  
	public void Update () 
    {
        if (movementUnit > 0)
        {
            transform.Translate(new Vector3(movementX, movementY, 0));
            movementUnit--;
        }
	}

    public void MoveRight()
    {
        if (speed > 0)
        {
            setPosition(getX() + 1, getY());
            movementUnit = movingScale;
            movementX = 1;
            movementY = 0;
            if (TileManager.getInstance().getTile(getX() + 1, getY()).getType() == Tile.MUD)
                decreaseSpeed(2);
            else
                decreaseSpeed();
            if (TileManager.getInstance().getTile(getX() + 1, getY()).getType() == Tile.SPIKE)
                vie -= 3;
        }
    }

    public void MoveLeft()
    {
        if(speed > 0)
		{
            setPosition(getX() - 1, getY());
            movementUnit = movingScale;
            movementX = -1;
            movementY = 0;
            if (TileManager.getInstance().getTile(getX() - 1, getY()).getType() == Tile.MUD)
                decreaseSpeed(2);
            else
                decreaseSpeed();
            if (TileManager.getInstance().getTile(getX() - 1, getY()).getType() == Tile.SPIKE)
                vie -= 3;
        }
    }

    public void MoveForward()
    {
        if(speed > 0)
        {
            setPosition(getX(), getY() + 1);
            movementUnit = movingScale;
            movementX = 0;
            movementY = 1;
            if (TileManager.getInstance().getTile(getX(), getY() + 1).getType() == Tile.MUD)
                decreaseSpeed(2);
            else
                decreaseSpeed();
            if (TileManager.getInstance().getTile(getX(), getY() + 1).getType() == Tile.SPIKE)
                vie -= 3;
        }
    }

    public void MoveBackward()
    {
        if (speed > 0)
        {
            setPosition(getX(), getY() - 1);
            movementUnit = movingScale;
            movementX = 0;
            movementY = -1;
            if (TileManager.getInstance().getTile(getX(), getY() - 1).getType() == Tile.MUD)
                decreaseSpeed(2);
            else
                decreaseSpeed();
            if (TileManager.getInstance().getTile(getX(), getY() - 1).getType() == Tile.SPIKE)
                vie -= 3;
        }
    }

    public void Attack(Personnage Enemy)
    {
        Enemy.Defend(attaque);
        decreaseSpeed();
    }

    public void Defend(int enemyForce)
    {
        vie -= enemyForce;
    }

    public void setStats(int vieRecu, int attaqueRecu, int speedRecu)
    {
        vie = vieRecu;
        attaque = attaqueRecu;
        speed = speedRecu;
    }

    public void decreaseSpeed(int speedReduced = 1)
    {
        if (speed > 0)
        {
            speed -= speedReduced;
        }
        else if(name == "Player")
        {
            TurnManager.getInstance().changeActivePlayer();
        }
    }

    public void afficherStats()
    {
    }
}
