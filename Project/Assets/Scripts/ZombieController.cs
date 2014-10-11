using UnityEngine;
using System.Collections;

public class ZombieController : Personnage {

    public bool actif;


	// Use this for initialization
	void Start () {
        // setStats(vie, Attack, speed)
        setStats(10, 2, 4);
		setIdentity("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (actif)
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                EnemyScript isEnemy = null;
                PowerUp isPowerUp = null;
                foreach (Entity e in TileManager.getInstance().getTile(getX() + 1, getY()).getEntities())
                {
					if (e.getIdentity() == "Enemy")
					{
                        isEnemy = (EnemyScript)e;
                    }
					if (e.getIdentity() == "PowerUp")
                    {
                        isPowerUp = (PowerUp)e;
                    }
					if (e.getIdentity() == "Player")
					{
                        // ADD #WINTHEGAMEFUNCTION
                    }
                }
                if (isEnemy != null)
                {
                    Attack(isEnemy);
                }
                else
                {
                    MoveRight();
                    if (isPowerUp != null)
                    {
                        isPowerUp.takePowerUp(this);
                    }
                }
            }

            if (vie <= 0)
            {
                // #LOSETHEGAME
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                EnemyScript isEnemy = null;
                PowerUp isPowerUp = null;
                foreach (Entity e in TileManager.getInstance().getTile(getX() - 1, getY()).getEntities())
                {
					if (e.getIdentity() == "Enemy")
					{
                        isEnemy = (EnemyScript)e;
                    }
					if (e.getIdentity() == "PowerUp")
                    {
                        isPowerUp = (PowerUp)e;
                    }
					if (e.getIdentity() == "Player")
					{
                        // ADD #WINTHEGAMEFUNCTION
                    }
                }
                if (isEnemy != null)
                {
                    Attack(isEnemy);
                }
                else
                {
                    MoveLeft();
                    if (isPowerUp != null)
                    {
                        isPowerUp.takePowerUp(this);
                    }
                }
                
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                EnemyScript isEnemy = null;
                PowerUp isPowerUp = null;
                foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() + 1).getEntities())
                {
					if (e.getIdentity() == "Enemy")
					{
                        isEnemy = (EnemyScript)e;
                    }
					if (e.getIdentity() == "PowerUp")
                    {
                        isPowerUp = (PowerUp)e;
                    }
					if (e.getIdentity() == "Player")
					{
                        // ADD #WINTHEGAMEFUNCTION
                    }
                }
                if (isEnemy != null)
                {
                    Attack(isEnemy);
                }
                else
                {
                    MoveForward();
                    if (isPowerUp != null)
                    {
                        isPowerUp.takePowerUp(this);
                    }
                }
                
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                EnemyScript isEnemy = null;
                PowerUp isPowerUp = null;
                foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() - 1).getEntities())
                {
					if (e.getIdentity() == "Enemy")
					{
                        isEnemy = (EnemyScript)e;
                    }
					if (e.getIdentity() == "PowerUp")
                    {
                        isPowerUp = (PowerUp)e;
                    }
					if (e.getIdentity() == "Player")
					{
                        // ADD #WINTHEGAMEFUNCTION
                    }
                }
                if (isEnemy != null)
                {
                    Attack(isEnemy);
                }
                else
                {
                    MoveBackward();
                    if (isPowerUp != null)
                    {
                        isPowerUp.takePowerUp(this);
                    }
                }
                
            }
        }
	}

    public void changeActive()
    {
        actif = !actif;

        if(actif)
        {
            speed = 4;
        }
    }
}
