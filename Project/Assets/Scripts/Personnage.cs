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
            base.setPosition(base.getX() + 1, base.getY());
            movementUnit = movingScale;
            movementX = 1;
            movementY = 0;
            decreaseSpeed();
        }
    }

    public void MoveLeft()
    {
        if(speed > 0)
        {
            base.setPosition(base.getX() - 1, base.getY());
            movementUnit = movingScale;
            movementX = -1;
            movementY = 0;
            decreaseSpeed();
        }
    }

    public void MoveBackward()
    {
        if(speed > 0)
        {
            base.setPosition(base.getX(), base.getY() - 1);
            movementUnit = movingScale;
            movementX = 0;
            movementY = -1;
            decreaseSpeed();
        }
    }

    public void MoveForward()
    {
        if(speed > 0)
        {
            base.setPosition(base.getX(), base.getY() + 1);
            movementUnit = movingScale;
            movementX = 0;
            movementY = 1;
            decreaseSpeed();
        }
    }

    public void Attack(Personnage Enemy)
    {
        Enemy.Defend(attaque);
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

    public void decreaseSpeed()
    {
        if (speed > 0)
        {
            speed--;
        }
    }
}
