using UnityEngine;
using System.Collections;

public class Personnage : Entity 
{
	public bool actif;
	public int vie;
    public int vieMaximale;
    public int attaque;
    public int speed = 1;
    public int maxSpeed;
    public int movingScale = 10;
    public int movementUnit;
    int movementX;
    int movementY;
	Personnage killer;
	public bool waitActive;

	// Use this for initialization
	void Start () 
    {
		killer = null;
		waitActive = false;
	}
	
	// Update is called once per frame  
	public void Update () 
    {
		if(actif)
		{
			cameraFollow();
		}
		
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
        Enemy.Defend(this);
        decreaseSpeed(1);
        if (speed <= 0 && getIdentity() == "Player")
        {
            movementSynchronisation();
        }
    }

    public void Defend(Personnage attacker)
    {
        vie -= attacker.attaque;
		if(vie <= 0)
		{
			killer = attacker;
		}
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

	public void cameraFollow()
	{
		Vector3 cameraPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
		Camera.main.transform.Translate(transform.position - cameraPosition);
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

	public Personnage getKiller()
	{
		return killer;
	}

    public void movementSynchronisation()
    {
		wait(300);
		TurnManager.getInstance().changeActivePlayer();
    }

	IEnumerator waitCharacter()
	{
		Debug.Log ("WAIT");
		waitActive = true;
		yield return new WaitForSeconds (1.0f);
		Debug.Log ("FIN WAIT");
		waitActive = false;
	}

	public void wait(int ms)
	{
		try
		{
			System.Threading.Thread.Sleep(ms);
		}catch{}
	}
}
