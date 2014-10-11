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
    }
}
