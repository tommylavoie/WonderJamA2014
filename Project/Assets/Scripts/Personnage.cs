using UnityEngine;
using System.Collections;

public class Personnage : Entity {

    public int vie;
    public int vieMaximale;
    public int attaque;
    public int speed = 1;
    public int maxSpeed;
    public int movingScale = 10;
    public int movementUnit;
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
            if (speed <= 0 && getIdentity() == "Player" && movementUnit == 0)
            {
                movementSynchronisation();
            }
        }
        else
        {
            transform.position = new Vector3(MapGenerator.initialX + (10 * getX()), MapGenerator.initialY + (10 * getY()), 0);
        }
	}

    public void MoveRight()
    {
        move(1, 0);
    }

    public void MoveLeft()
    {
        move(-1, 0);
    }

    public void MoveForward()
    {
        move(0, 1);
    }

    public void MoveBackward()
    {
        move(0, -1);
    }

    public void Attack(Personnage Enemy)
    {
        if (getIdentity() == "Player")
        {
            SoundScript.Instance.MakePlayerAttackSound();
        }
        else if (getIdentity() == "Enemy")
        {
            SoundScript.Instance.MakeenemyAttackSound();
        }
        Enemy.Defend(attaque);
        decreaseSpeed(1);
        if (speed <= 0 && getIdentity() == "Player")
        {
            movementSynchronisation();
        }
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
        maxSpeed = speedRecu;
    }

    public void setSpeedBack()
    {
        speed = maxSpeed;
    }

    void move(int x, int y)
    {
        if (speed > 0)
        {
            if (TileManager.getInstance().getTile(getX() + x, getY() + y).getType() != Tile.MOUNTAIN)
            {
                setPosition(getX() + x, getY() + y);
                movementUnit = movingScale;
                movementX = x;
                movementY = y;
                if (TileManager.getInstance().getTile(getX(), getY()).getType() == Tile.MUD)
                    decreaseSpeed(2);
                else
                    decreaseSpeed(1);
                if (TileManager.getInstance().getTile(getX(), getY()).getType() == Tile.SPIKE)
                {
                    if (getIdentity() == "Player")
                    {
                        SoundScript.Instance.MakeSpikeHurtSound();
                    }
                    vie -= 3;
                }
            }
        }
    }

    public void decreaseSpeed(int speedReduced)
    {
        if (speed > 0)
        {
            speed -= speedReduced;

            if(speed < 0)
            {
                speed = 0; //Pour l'affichage
            }
        }
    }

    public void movementSynchronisation()
    {
		wait();
        TurnManager.getInstance().changeActivePlayer();
    }

	public void wait()
	{
		try
		{
			System.Threading.Thread.Sleep(300);
		}catch{}
	}
}
