﻿using UnityEngine;
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
            cameraFollow();
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
			Debug.Log ("AJSDHOISAJK");
            speed = 4;
        }
    }

    void cameraFollow()
    {
        Vector3 cameraPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        Camera.main.transform.Translate(transform.position - cameraPosition);
    }

    void OnGUI() 
    {
        if (actif)
        {
            GUI.Label(new Rect(Screen.width * 0.02f, Screen.height * 0.02f, Screen.width * 0.5f, Screen.height * 0.1f), "Actions Restantes: " + speed +
                ", Vie: " + vie + "/" + vieMaximale + ", Attaque: " + attaque);
        }
    }
}
