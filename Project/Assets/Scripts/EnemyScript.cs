using UnityEngine;
using System.Collections;

public class EnemyScript : Personnage {

    int vie;
    int force;
    int déplacement;
    int type; 
    /* 0 = rapide mais faible (dep4, 
     * 1 = tank
     * 2 = Lent mais tres fort
    */


	// Use this for initialization
	void Start () {
        // Randomly choose the enemy type and set it stats
        type = Random.Range(0, 2);
        switch (type)
        {
            // setStats(vie, Attack, speed)
            case 0: base.setStats(3, 1, 4); break;
            case 1: base.setStats(10, 1, 1); break;
            case 2: base.setStats(5, 3, 1); break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    // Function permettant le déplacement d'un ennemie
    void Action() {
        if (!isThereNearbyPlayer()) { // Attack if true, move if false
            int direction = Random.Range(0, 4);
            switch (direction)
            {
                case 0: base.MoveRight(); break;
                case 1: base.MoveBackward(); break;
                case 2: base.MoveForward(); break;
                case 3: base.MoveLeft(); break;
            }
        }
        else // ATTACK THE PLAYER
        {
            //base.Attack();
        }
    }

    bool isThereNearbyPlayer() {
        return false; // Temporaire
    }


}
