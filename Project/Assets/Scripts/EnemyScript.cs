using UnityEngine;
using System.Collections;

public class EnemyScript : Personnage {

    int enemyType;
	int attackCount;
	bool canAttack;
	int lastResort = 0;
	bool endTurn = false;

	public Animator anim;

	public GameObject healUp;
	public GameObject attackUp;
	public GameObject speedUp;
    
    /* 0 = rapide mais faible (dep4, 
     * 1 = tank
     * 2 = Lent mais tres fort
    */

	// Use this for initialization
	void Start () 
	{
		setIdentity("Enemy");
		anim = gameObject.GetComponent<Animator>();
		attackCount = 0;
		canAttack = false;
	}

	public void setEnemyType(int type)
	{
		this.enemyType = type;
		switch (enemyType)
		{
			// setStats(vie, Attack, speed)
			case 0: setStats(3, 1, 5); break;
			case 1: setStats(10, 5, 1); break;
			case 2: setStats(5, 3, 3); break;
		}
	}

	public int getEnemyType()
	{
		return enemyType;
	}
	
	// Update is called once per frame
	void Update () 
	{
		base.Update();

		if(actif && canAttack)
		{
			DoAction();
			if(endTurn  && lastResort < 6 && vie >=0)
			{
				endTurn = false;
				canAttack = false;
				actif = false;
				setSpeedBack();
				TurnManager.getInstance().nextEnemy();				
			}
			if(speed > 0)
			{
				lastResort++;
				canAttack = false;
				StartCoroutine(waitEnemy());
			}
			else
			{
				lastResort = 0;
				canAttack = false;
				endTurn = true;
				StartCoroutine(waitEnemy());

			}
		}

        if (vie <= 0)
        {
			int rand = Random.Range(1,3);
			Debug.Log (rand);
			if(rand == 2)
				addPowerUp(getX(), getY ());
			EnemyManager.getInstance().lesEnemies.Remove(this);
			if(actif)
				TurnManager.getInstance().nextEnemy();
            Destroy(this);
            Destroy(sprite);
        }

		anim.SetFloat("vitesse", movementUnit);
		anim.SetInteger("attackCount", attackCount);

		if(attackCount > 0)
		{
			attackCount--;
		}
	}

    // Function 
    public void Action() 
	{
		actif = true;

        while (speed > 0 && lastResort < 5)
        {
			DoAction();
		}
		actif = false;
	}

	public void StartActions()
	{
		StartCoroutine(waitEnemy());
	}

	public void DoAction()
	{
		ZombieController player = isThereNearbyPlayer();
		if (player == null)
		{ // Attack if there's a player nearby, move if not
			int random = Random.Range(0, 3);
			switch (random)
			{
			case 0:{
				bool canMove = true;
				foreach (Entity e in TileManager.getInstance().getTile(getX() + 1, getY()).getEntities())
				{
					if (e.getIdentity() == "Enemy")
						canMove = false;
				}
				if (canMove)
					MoveRight();
				break;}
			case 1: {
				bool canMove = true;
				foreach (Entity e in TileManager.getInstance().getTile(getX() - 1, getY()).getEntities())
				{
					if (e.getIdentity() == "Enemy")
						canMove = false;
				}
				if (canMove)
					MoveLeft();
				break;}
			case 2: {
				bool canMove = true;
				foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() + 1).getEntities())
				{
					if (e.getIdentity() == "Enemy")
						canMove = false;
				}
				if (canMove)
					MoveForward();
				break;}
			case 3:{
				bool canMove = true;
				foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() - 1).getEntities())
				{
					if (e.getIdentity() == "Enemy")
						MoveBackward();
				}
				if (canMove)
					MoveBackward();
				break;}
			}
		}
		else // ATTACK THE PLAYER
		{
			attackCount = 10;
			Attack(player);
			player = null;
		}
		//lastResort++;
	}
	
	// Check if there's a player in one of the four adjacent tile (will only one if the 2 player are adjacent to the enemy
	ZombieController isThereNearbyPlayer() {
		foreach (Entity e in TileManager.getInstance().getTile(getX() + 1, getY()).getEntities())
			if (e.getIdentity() == "Player") 
		{
			return (ZombieController)e;
		}
		foreach (Entity e in TileManager.getInstance().getTile(getX() - 1, getY()).getEntities())
			if (e.getIdentity() == "Player")
		{
			return (ZombieController)e;
		}
		foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() + 1).getEntities())
			if (e.getIdentity() == "Player")
		{
			return (ZombieController)e;
		}
		foreach (Entity e in TileManager.getInstance().getTile(getX(), getY() - 1).getEntities())
            if (e.getIdentity() == "Player")
            {
                return (ZombieController)e;
            }    
        return null;
    }

	IEnumerator waitEnemy()
	{
		yield return new WaitForSeconds (0.3f);
		canAttack = true;
	}

	void addPowerUp(int x, int y)
	{
		Debug.Log ("IN");
		int type = Random.Range(0, 3);
		if(type == PowerUp.HEAL)
		{
			healUp.transform.position = new Vector3(MapGenerator.initialY+(10*x),MapGenerator.initialX+(10*y), 0);
			Object powerInstance = Instantiate(healUp);
			GameObject power = (GameObject)powerInstance;
			PowerUp control = (PowerUp)power.GetComponent<PowerUp>();
			control.setPosition(x,y);
			control.setType(type);
			control.sprite = power;
		}
		if(type == PowerUp.ATTACK)
		{
			attackUp.transform.position = new Vector3(MapGenerator.initialY+(10*x),MapGenerator.initialX+(10*y), 0);
			Object powerInstance = Instantiate(attackUp);
			GameObject power = (GameObject)powerInstance;
			PowerUp control = (PowerUp)power.GetComponent<PowerUp>();
			control.setPosition(x,y);
			control.setType(type);
			control.sprite = power;
		}
		if(type == PowerUp.SPEED)
		{
			speedUp.transform.position = new Vector3(MapGenerator.initialY+(10*x),MapGenerator.initialX+(10*y), 0);
			Object powerInstance = Instantiate(speedUp);
			GameObject power = (GameObject)powerInstance;
			PowerUp control = (PowerUp)power.GetComponent<PowerUp>();
			control.setPosition(x,y);
			control.setType(type);
			control.sprite = power;
		}
	}
	
	public static int GHOST = 0;
	public static int ELEPHANT = 1;
	public static int FISH = 2;
}
