﻿using UnityEngine;
using System.Collections;

public class ZombieController : Personnage {

    public bool actif;
	public Animator anim;
	int side;
	int attackCount;

	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponent<Animator>();
        // setStats(vie, Attack, speed)
        setStats(10, 2, 4);
		setIdentity("Player");
		side = 1;
		attackCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (actif)
        {
            base.Update();
            cameraFollow();
            if (vie <= 0)
            {
                Application.LoadLevel("GameOverScreen");
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (checkNearby(1, 0))
                {
					if(side == -1)
						side = 1;
					transform.localScale = new Vector3(4*side,4,0);
                    MoveRight();
					FogManager.getInstance().unFog(getX(), getY());
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (checkNearby(-1, 0))
                {
					if(side == 1)
						side = -1;
					transform.localScale = new Vector3(4*side,4,1);
                    MoveLeft();
					FogManager.getInstance().unFog(getX(), getY());
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (checkNearby(0, 1))
                {
					transform.localScale = new Vector3(4*side,4,1);
                    MoveForward();
					FogManager.getInstance().unFog(getX(), getY());
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (checkNearby(0, -1))
                {
					transform.localScale = new Vector3(4*side,4,1);
                    MoveBackward();
					FogManager.getInstance().unFog(getX(), getY());
                }
            }

			if(attackCount > 0)
			{
				attackCount--;
			}
        }

		anim.SetFloat("vitesse", movementUnit);
		anim.SetInteger("attackCount", attackCount);
	}

    bool checkNearby(int x, int y)
    {
        EnemyScript isEnemy = null;
        PowerUp isPowerUp = null;
        foreach (Entity e in TileManager.getInstance().getTile(getX() + x, getY() + y).getEntities())
        {
            if (e.getIdentity() == "Enemy")
            {
                isEnemy = (EnemyScript)e;
            }
            if (e.getIdentity() == "PowerUp")
            {
                isPowerUp = (PowerUp)e;
            }
            if (e.getIdentity() == "Player" && e != this)
            {
                Application.LoadLevel("WinScreen");
            }
        }
        if (isEnemy != null)
        {
			attackCount = 5;
            Attack(isEnemy);
            return false;
        }
        else
        {
            if (isPowerUp != null)
            {
                isPowerUp.takePowerUp(this);
            }
            return true;
        }
    }

    public void changeActive()
    {
        actif = !actif;

        if(actif)
        {
            speed = maxSpeed;
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
