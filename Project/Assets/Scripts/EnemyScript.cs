using UnityEngine;
using System.Collections;

public class EnemyScript : Personnage {

    int enemyType; 
    
    /* 0 = rapide mais faible (dep4, 
     * 1 = tank
     * 2 = Lent mais tres fort
    */


	// Use this for initialization
	void Start () {
        // Randomly choose the enemy type and set it stats
        setName("Enemy");
        enemyType = Random.Range(0, 2);
        switch (enemyType)
        {
            // setStats(vie, Attack, speed)
            // ADD SPRITE FOR EVERYONE
            case 0: setStats(3, 1, 4); break;
            case 1: setStats(10, 1, 1); break;
            case 2: setStats(5, 3, 1); break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    // Function permettant le déplacement d'un ennemie
    public void Action() {
        ZombieController player = isThereNearbyPlayer();
        if (player == null) { // Attack if true, move if false
            switch (Random.Range(0, 4))
            {
                case 0: base.MoveRight(); break;
                case 1: base.MoveBackward(); break;
                case 2: base.MoveForward(); break;
                case 3: base.MoveLeft(); break;
            }
        }
        else // ATTACK THE PLAYER
        {
            base.Attack(player);
        }
    }

    ZombieController isThereNearbyPlayer() {
        foreach (Entity e in TileManager.getInstance().getTile(getX() + 1, getY()).getEntities())
            if (e.name == "Player") 
            {
                return (ZombieController)e;
            }
        foreach (Entity e in TileManager.getInstance().getTile(getX() - 1, getY()).getEntities())
            if (e.name == "Player")
            {
                return (ZombieController)e;
            }
        foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() + 1).getEntities())
            if (e.name == "Player")
            {
                return (ZombieController)e;
            }
        foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() - 1).getEntities())
            if (e.name == "Player")
            {
                return (ZombieController)e;
            }
        
        return null;
    }


}
