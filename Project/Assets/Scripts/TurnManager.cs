using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour{

    private static TurnManager instance;

    public List<ZombieController> lesJoueurs;

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
        lesJoueurs = new List<ZombieController>();
    }

    public void changeActivePlayer()
    {
        foreach(ZombieController z in lesJoueurs)
        {
            z.changeActive();
        }
    }
}
