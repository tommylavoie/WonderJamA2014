using UnityEngine;
using System.Collections;

public class ZombieController : Personnage {

    public bool actif;

	// Use this for initialization
	void Start () {
        // setStats(vie, Attack, speed)
        setStats(10, 2, 4);
        setName("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (actif)
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                base.MoveRight();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                base.MoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                base.MoveForward();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                base.MoveBackward();
            }
        }
	}

    public void changeActive()
    {
        actif = !actif;

        if(actif)
        {
            base.speed = 4;
        }
    }
}
