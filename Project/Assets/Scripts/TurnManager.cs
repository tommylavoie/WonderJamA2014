using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager {

    private static TurnManager instance;

	public ZombieController zombieMale;
	public ZombieController zombieFemale;

	public int next;

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
		next = 0;
    }

    public void changeActivePlayer()
    {
		zombieMale.changeActive();
		zombieFemale.changeActive();

		if (zombieMale.actif) 
		{
			zombieMale.actif = false;
			next = 0;
			EnemyManager.getInstance().updateEnemy(0);
		}
	}

	public void nextEnemy()
	{
		next++;
		if(next < EnemyManager.getInstance().lesEnemies.Count)
		{
			EnemyManager.getInstance().updateEnemy(next);
		}
		else
		{
			zombieMale.actif = true;
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
}
