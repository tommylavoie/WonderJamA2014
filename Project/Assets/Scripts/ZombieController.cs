﻿using UnityEngine;
using System.Collections;

public class ZombieController : Personnage {

    public bool actif;
	public Animator anim;
	int side;
	int attackCount;
    string sex = "";

	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponent<Animator>();
        // setStats(vie, Attack, speed)
        setStats(20, 2, 4);
		vieMaximale = 20;
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

            if ((sex == "F" && Input.GetKeyDown(KeyCode.RightArrow)) || (sex == "M" && Input.GetKeyDown(KeyCode.D)))
            {
                if (checkNearby(1, 0))
                {
                    if (side == -1)
                        side = 1;
                    transform.localScale = new Vector3(4 * side, 4, 0);
                    MoveRight();
                    FogManager.getInstance().unFog(getX(), getY());
                }
            }


            if ((sex == "F" && Input.GetKeyDown(KeyCode.LeftArrow)) || (sex == "M" && Input.GetKeyDown(KeyCode.A)))
            {
                if (checkNearby(-1, 0))
                {
                    if (side == 1)
                        side = -1;
                    transform.localScale = new Vector3(4 * side, 4, 1);
                    MoveLeft();
                    FogManager.getInstance().unFog(getX(), getY());
                }
            }

            if ((sex == "F" && Input.GetKeyDown(KeyCode.UpArrow)) || (sex == "M" && Input.GetKeyDown(KeyCode.W)))
            {
                if (checkNearby(0, 1))
                {
                    transform.localScale = new Vector3(4 * side, 4, 1);
                    MoveForward();
                    FogManager.getInstance().unFog(getX(), getY());
                }
            }

            if ((sex == "F" && Input.GetKeyDown(KeyCode.DownArrow)) || (sex == "M" && Input.GetKeyDown(KeyCode.S)))
            {
                if (checkNearby(0, -1))
                {
                    transform.localScale = new Vector3(4 * side, 4, 1);
                    MoveBackward();
                    FogManager.getInstance().unFog(getX(), getY());
                }
            }

			if(vie <= 0)
            {
                actif = false;
                SoundScript.Instance.MakePlayerDeathSound();
            }


			if(attackCount > 0)
			{
				attackCount--;
			}
        }

		anim.SetFloat("vitesse", movementUnit);
		anim.SetInteger("attackCount", attackCount);
		anim.SetInteger("life", vie);
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
                SoundScript.Instance.MakePowerUpSound();
            }
            return true;
        }
    }

    public void changeActive()
    {
		attackCount = 0;
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

	string getKillerName()
	{
		Personnage killer = getKiller();
		if(killer != null)
		{
			if(((EnemyScript)killer).getEnemyType() == EnemyScript.GHOST)
			{
				return "un fantome";
			}
			if(((EnemyScript)killer).getEnemyType() == EnemyScript.ELEPHANT)
			{
				return "un elephant";
			}
			if(((EnemyScript)killer).getEnemyType() == EnemyScript.FISH)
			{
				return "un poisson";
			}
		}
		return "vous-meme";
	}

    void OnGUI() 
    {
        if (actif)
        {
            GUI.Label(new Rect(Screen.width * 0.02f, Screen.height * 0.02f, Screen.width * 0.5f, Screen.height * 0.1f), "Actions Restantes: " + speed +
                ", Vie: " + vie + "/" + vieMaximale + ", Attaque: " + attaque);
        }
        if (vie <= 0)
        {
            float decalageGauche = (Screen.width - Screen.width * 0.333f) / 2;
            GUI.Label(new Rect(decalageGauche-Screen.width*0.25f, Screen.height * 0.25f, Screen.width * 2f, Screen.height * 0.4f), 
			          "<color=white><size=30>Vous avez été tué par " + getKillerName() + ".</size></color>");
            if (GUI.Button(new Rect(decalageGauche, Screen.height * 0.45f, Screen.width * 0.3f, Screen.height * 0.1f), "Rejouer"))
            {
				TileManager.getInstance().resetTiles();
				EnemyManager.getInstance().restartEnemies();
				FogManager.getInstance().restartFog();
                Application.LoadLevel("Main");
            }
            if (GUI.Button(new Rect(Screen.width * 0.333f, Screen.height * 0.65f, Screen.width * 0.3f, Screen.height * 0.1f), "Quitter"))
            {
                Application.Quit();
            }
        }
    }
    public void setSexe(string sexe)
    {
        sex = sexe; 
    }
}
