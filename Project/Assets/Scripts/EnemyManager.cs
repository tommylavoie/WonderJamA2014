using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager{

    private static EnemyManager instance;

    public List<EnemyScript> lesEnemies;

    public static EnemyManager getInstance()
    {
        if (instance == null)
        {
            instance = new EnemyManager();
        }
        return instance;
    }

    private EnemyManager()
    {
		restartEnemies();
    }

	public void restartEnemies()
	{
		lesEnemies = new List<EnemyScript>();
	}

	public void updateEnemy(int index)
	{
		EnemyScript enemy = lesEnemies[index];
		if(lesEnemies[index] != null)
		{
			if(!FogManager.getInstance().isFog(enemy.getX(), enemy.getY()))
			{
				lesEnemies[index].actif = true;
				lesEnemies[index].StartActions();
			}
			else
				TurnManager.getInstance().nextEnemy();
		}
		else
		{
			TurnManager.getInstance().nextEnemy();
		}
	}

    public void updateEnemies()
    {
        foreach(EnemyScript enemy in lesEnemies)
        {
            enemy.Action();
            enemy.setSpeedBack();
        }
    }
}
