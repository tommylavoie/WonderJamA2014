using UnityEngine;
using System.Collections;

public class PowerUp : Entity {

    public int heal;
    public int attackBonus;
    public int movSupplementaire;

	// Use this for initialization
	void Start () 
    {
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
