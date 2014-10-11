using UnityEngine;
using System.Collections;

public class PowerUp : Entity {

    public int heal;
    public int attackBonus;
    public int movSupplementaire;
    int type;

	// Use this for initialization
	void Start () 
    {
        setName("PowerUp");
        type = Random.Range(0, 2);
        switch (type)
        {
            case 0: heal = 5;
                attackBonus = 0;
                movSupplementaire = 0;
                break;
            case 1: heal = 0;
                attackBonus = 1;
                movSupplementaire = 0;
                break;
            case 2: heal = 0;
                attackBonus = 0;
                movSupplementaire = 1;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public void takePowerUp(Personnage lePersonnage)
    {
        lePersonnage.vie += heal;

        if(lePersonnage.vieMaximale < lePersonnage.vie)
        {
            lePersonnage.vie = lePersonnage.vieMaximale;
        }

        lePersonnage.attaque += attackBonus;
        lePersonnage.speed += movSupplementaire;
    }
}
