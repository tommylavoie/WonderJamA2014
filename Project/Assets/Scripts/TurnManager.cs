using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager {

    private static TurnManager instance;

	public ZombieController zombieMale;
	public ZombieController zombieFemale;

    public static TurnManager getInstance()
    {
        if (instance == null)
        {
            instance = new TurnManager();
        }
        return instance;
    }

    private TurnManager()
    {
        
    }

    public void changeActivePlayer()
    {
		zombieMale.changeActive();
		zombieFemale.changeActive();

		if (zombieMale.actif) 
		{
			EnemyManager.getInstance().updateEnemies ();
		}

		if(zombieMale.vie <= 0)
		{
			zombieMale.actif = true;
			zombieFemale.actif = false;
		}
		else if(zombieFemale.vie <= 0)
		{
			zombieFemale.actif = true;
			zombieMale.actif = false;
		}
	}
}
