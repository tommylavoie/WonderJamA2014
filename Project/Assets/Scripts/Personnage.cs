using UnityEngine;
using System.Collections;

public class Personnage : MonoBehaviour {

    public int vie;
    public int attaque;
    public int speed = 5;
    public int movingScale = 2;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame  
	void Update () 
    {
	}

    public void MoveRight()
    {
        transform.Translate(new Vector3(movingScale, 0, 0));
    }

    public void MoveLeft()
    {
        transform.Translate(new Vector3(-movingScale, 0, 0));
    }

    public void MoveBackward()
    {
        transform.Translate(new Vector3(0, -movingScale, 0));
    }

    public void MoveForward()
    {
        transform.Translate(new Vector3(0, movingScale, 0));
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
