using UnityEngine;
using System.Collections;

public class PowerUp : Entity {

    public int heal;
    public int attackBonus;
    public int movSupplementaire;
    int type;

	public PowerUp()
	{
		type = Random.Range(0, 3);
	}

	void Start()
	{
		setIdentity("PowerUp");
	}

	public void setType(int type)
	{
		// Debug.Log ("Set type for: " + type);
		this.type = type;
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

	public int getType()
	{
		return type;
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public void takePowerUp(Personnage lePersonnage)
    {
		//Debug.Log ("GOT IT " + type);
        lePersonnage.vie += heal;

        if(lePersonnage.vieMaximale < lePersonnage.vie)
        {
            lePersonnage.vie = lePersonnage.vieMaximale;
        }

        lePersonnage.attaque += attackBonus;
        lePersonnage.maxSpeed += movSupplementaire;

        Tile laTuile = getTile();
        laTuile.removeEntity(this);
    }

	public static int HEAL = 0;
	public static int ATTACK = 1;
	public static int SPEED = 2;
}
