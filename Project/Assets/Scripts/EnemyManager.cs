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
        lesEnemies = new List<EnemyScript>();
    }

    public void updateEnemies()
    {
        foreach(EnemyScript enemy in lesEnemies)
        {
            enemy.Action();
        }
    }
}
