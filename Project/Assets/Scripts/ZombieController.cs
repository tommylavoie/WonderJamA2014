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
            cameraFollow();

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (checkNearby(1, 0))
                {
                    MoveRight();
					FogManager.getInstance().unFog(getX(), getY());
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (checkNearby(-1, 0))
                {
                    MoveLeft();
					FogManager.getInstance().unFog(getX(), getY());
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (checkNearby(0, 1))
                {
                    MoveForward();
					FogManager.getInstance().unFog(getX(), getY());
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (checkNearby(0, -1))
                {
                    MoveBackward();
					FogManager.getInstance().unFog(getX(), getY());
                }
            }
        }
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
        if (vie <= 0)
        {
            float decalageGauche = (Screen.width - Screen.width * 0.3f) / 2;
            GUI.Label(new Rect(decalageGauche, Screen.height * 0.25f, Screen.width * 0.3f, Screen.height * 0.1f), "<color=white><size=40>Mort, vous êtes</size></color>");
            if (GUI.Button(new Rect(decalageGauche, Screen.height * 0.45f, Screen.width * 0.3f, Screen.height * 0.1f), "Rejouer"))
            {
                //Application.LoadLevel(Application.loadedLevel);
            }
            if (GUI.Button(new Rect(decalageGauche, Screen.height * 0.65f, Screen.width * 0.3f, Screen.height * 0.1f), "Quitter"))
            {
                Application.Quit();
            }
        }
    }

    override public void Defend(int enemyForce)
    {
        if (actif)
        {
            vie -= enemyForce;
        }
    }
}
