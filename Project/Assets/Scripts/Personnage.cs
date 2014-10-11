using UnityEngine;
using System.Collections;

public class Personnage : Entity {

    public int vie;
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
	void Update () 
    {
        if (movementUnit > 0)
        {
            transform.Translate(new Vector3(movementX, movementY, 0));
            movementUnit--;
        }
	}

    public void MoveRight()
    {
        base.setPosition(base.getX() + 1, base.getY());
        movementUnit = 50;
        movementX = 1;
        movementY = 0;
        //transform.Translate(new Vector3(movingScale, 0, 0));
    }

    public void MoveLeft()
    {
        base.setPosition(base.getX() - 1, base.getY());
        movementUnit = 50;
        movementX = -1;
        movementY = 0;
        //transform.Translate(new Vector3(-movingScale, 0, 0));
    }

    public void MoveBackward()
    {
        base.setPosition(base.getX(), base.getY() - 1);
        movementUnit = 50;
        movementX = 0;
        movementY = -1;
        //transform.Translate(new Vector3(0, -movingScale, 0));
    }

    public void MoveForward()
    {
        base.setPosition(base.getX(), base.getY() + 1);
        movementUnit = 50;
        movementX = 0;
        movementY = 1;
        //transform.Translate(new Vector3(0, movingScale, 0));
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
}
