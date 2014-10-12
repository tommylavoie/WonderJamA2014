
using UnityEngine;
using System.Collections;
using System.Linq;

public class MapGenerator : MonoBehaviour 
{
	public static int width = 20;
	public static int height = 20;
	public static int initialX = 0;
	public static int initialY = 0;
	
	TileManager tileManager;
	EnemyManager enemyManager;
	TurnManager turnManager;
	FogManager fogManager;

	public GameObject background;
	
	public GameObject groundTile;
	public GameObject mountainTile;
	public GameObject mudTile;
	public GameObject spikeTile;
	public GameObject fog;
	
	public GameObject ZombieMale;
	public GameObject ZombieFemale;
	public GameObject elephant;
	public GameObject ghost;
	public GameObject fish;
	
	public GameObject healUp;
	public GameObject attackUp;
	public GameObject speedUp;
	
	// Use this for initialization
	void Start ()
	{
		tileManager = TileManager.getInstance();
		enemyManager = EnemyManager.getInstance();
		turnManager = TurnManager.getInstance();
		fogManager = FogManager.getInstance();

		adjustBackground();
		generateTiles();
		//generateFog();
		
		generateZombies();
		generateEnnemis();
		generatePowerUps();
	}

	void adjustBackground()
	{
		int weight = (5*width)-20;
		background.transform.position = new Vector3(weight,weight, 101);
		background.transform.localScale = new Vector3(width+40,1,height+40);
	}
	
	void generateTiles()
	{
		int total = (width-2)*(height-2);
		int mountains = Random.Range ((int)(total*0.2),(int)(total*0.3));
		int mud = Random.Range((int)(total*0.1), (int)(total*0.15));
		int spikes = Random.Range ((int)(total*0.04),(int)(total*0.08));
		
		for(int i=0;i<width;i++)
		{
			Tile tile = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(i,0,tile);
			mountainTile.transform.position = new Vector3(initialY+(0),initialX+(10*i), 0);
			Instantiate(mountainTile);
			
			Tile tile2 = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(i,height-1,tile2);
			mountainTile.transform.position = new Vector3(initialY+((10*width)-10),initialX+(10*i), 0);
			Instantiate(mountainTile);
		}
		for(int i=1;i<width-1;i++)
		{
			Tile tile = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(0,i,tile);
			mountainTile.transform.position = new Vector3(initialY+(i*10),initialX+(0), 0);
			Instantiate(mountainTile);
			
			Tile tile2 = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(width-1,i,tile2);
			mountainTile.transform.position = new Vector3(initialY+(i*10),initialX+((10*height)-10), 0);
			Instantiate(mountainTile);
		}
		
		int cpt = 0;
		while(cpt != mountains)
		{
			int x = Random.Range(1,width-1);
			int y = Random.Range(1,height-1);
			
			if(tileManager.getTile(x,y).getType() == Tile.EMPTY)
			{
				Tile tile = new Tile(Tile.MOUNTAIN);
				tileManager.changeTile(x,y,tile);
				mountainTile.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
				Instantiate(mountainTile);
				cpt++;
			}
		}
		
		cpt = 0;
		while(cpt != mud)
		{
			int x = Random.Range(1,width-1);
			int y = Random.Range(1,height-1);
			
			if(tileManager.getTile(x,y).getType() == Tile.EMPTY)
			{
				Tile tile = new Tile(Tile.MUD);
				tileManager.changeTile(x,y,tile);
				mudTile.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
				Instantiate(mudTile);
				cpt++;
			}
		}
		
		cpt = 0;
		while(cpt != spikes)
		{
			int x = Random.Range(1,width-1);
			int y = Random.Range(1,height-1);
			
			if(tileManager.getTile(x,y).getType() == Tile.EMPTY)
			{
				Tile tile = new Tile(Tile.SPIKE);
				tileManager.changeTile(x,y,tile);
				spikeTile.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
				Instantiate(spikeTile);
				cpt++;
			}
		}
		
		//Reste des tiles
		for(int i=1;i<width-1;i++)
		{
			for(int j=1;j<height-1;j++)
			{
				int type = tileManager.getTile(i,j).getType();
				if(type == Tile.EMPTY)
				{
					Tile tile = new Tile(Tile.GROUND);
					tileManager.changeTile(i,j,tile);
					groundTile.transform.position = new Vector3(initialY+(10*i),initialX+(10*j), 0);
					Instantiate(groundTile);
				}
			}
		}
	}

	void generateFog()
	{
		for(int i=0;i<width;i++)
		{
			for(int j=0;j<height;j++)
			{
				fog.transform.position = new Vector3(initialY+(10*i),initialX+(10*j), -0.1f);
				Object fogInstance = Instantiate(fog);
				GameObject theFog = (GameObject)fogInstance;
				fogManager.addFog(i,j,theFog);
			}
		}
	}
	
	void generateZombies()
	{	
		bool onGround = false;
		while(!onGround)
		{
			int x = Random.Range(1,3);
			int y = Random.Range(1,height-1);
			
			int type = tileManager.getTile(x,y).getType();
			if(type == Tile.GROUND)
			{
				ZombieMale.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
				Object zomb2 = Instantiate(ZombieMale);
				GameObject zomb = (GameObject)zomb2;
				ZombieController control = (ZombieController)zomb.GetComponent<ZombieController>();
				control.setPosition(x,y);
				turnManager.zombieMale = control;
				control.sprite = zomb;
				fogManager.unFog(x,y);
				onGround = true;
			}
		}
		
		onGround = false;
		while(!onGround)
		{
			int x = Random.Range(width-4,width-1);
			int y = Random.Range(1,height-1);

			int type = tileManager.getTile(x,y).getType();
			if(type == Tile.GROUND)
			{
				ZombieFemale.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
				Object zomb2 = Instantiate(ZombieFemale);
				GameObject zomb = (GameObject)zomb2;
				ZombieController control = (ZombieController)zomb.GetComponent<ZombieController>();
				control.setPosition(x,y);
				turnManager.zombieFemale = control;
				control.sprite = zomb;
				fogManager.unFog(x,y);
				onGround = true;
			}
		}
	}
	
	bool isCharacterOnTile(int x, int y)
	{
		var query =
			from c in tileManager.getTile(x,y).getEntities()
				where c.getIdentity() == "Player" || c.getIdentity() == "Enemy"
				select c;
		if(query.Count() != 0)
			return true;
		else
			return false;
	}

	bool isPowerUpOnTile(int x, int y)
	{
		var query =
			from p in tileManager.getTile(x,y).getEntities()
				where p.getIdentity() == "PowerUp"
				select p;

		if(query.Count() != 0)
			return true;
		else
			return false;
	}
	
	void generateEnnemis()
	{
		int total = (width-2)*(height-2);
		int ennemies = Random.Range ((int)(total*0.015),(int)(total*0.025));
		
		int cpt = 0;
		while(cpt != ennemies)
		{
			int x = Random.Range(1,width-1);
			int y = Random.Range(1,height-1);
			
			if(tileManager.getTile(x,y).getType() == Tile.GROUND && !isCharacterOnTile(x,y))
			{
				int type = Random.Range(0, 2);
				if(type == EnemyScript.GHOST)
				{
					ghost.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Object enemyInstance = Instantiate(ghost);
					GameObject enemy = (GameObject)enemyInstance;
					EnemyScript control = (EnemyScript)enemy.GetComponent<EnemyScript>();
					control.setPosition(x,y);
					control.setEnemyType(type);
					enemyManager.lesEnemies.Add (control);
					control.sprite = enemy;

				}
				if(type == EnemyScript.ELEPHANT)
				{
					elephant.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Object enemyInstance = Instantiate(elephant);
					GameObject enemy = (GameObject)enemyInstance;
					EnemyScript control = (EnemyScript)enemy.GetComponent<EnemyScript>();
					control.setPosition(x,y);
					control.setEnemyType(type);
					enemyManager.lesEnemies.Add (control);
					control.sprite = enemy;
				}
				if(type == EnemyScript.FISH)
				{
					fish.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Object enemyInstance = Instantiate(fish);
					GameObject enemy = (GameObject)enemyInstance;
					EnemyScript control = (EnemyScript)enemy.GetComponent<EnemyScript>();
					control.setPosition(x,y);
					control.setEnemyType(type);
					enemyManager.lesEnemies.Add (control);
					control.sprite = enemy;
				}
				cpt++;
			}
		}
	}
	
	void generatePowerUps()
	{
		int powerUps = Random.Range(5,8);
		
		int cpt = 0;
		while(cpt != powerUps)
		{
			int x = Random.Range(1,width-1);
			int y = Random.Range(1,height-1);
			
			if(tileManager.getTile(x,y).getType() != Tile.MOUNTAIN && !isPowerUpOnTile(x,y))
			{
				int type = Random.Range(0, 3);
				if(type == PowerUp.HEAL)
				{
					healUp.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Object powerInstance = Instantiate(healUp);
					GameObject power = (GameObject)powerInstance;
					PowerUp control = (PowerUp)power.GetComponent<PowerUp>();
					control.setPosition(x,y);
					control.setType(type);
					control.sprite = power;
				}
				if(type == PowerUp.ATTACK)
				{
					attackUp.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Object powerInstance = Instantiate(attackUp);
					GameObject power = (GameObject)powerInstance;
					PowerUp control = (PowerUp)power.GetComponent<PowerUp>();
					control.setPosition(x,y);
					control.setType(type);
					control.sprite = power;
				}
				if(type == PowerUp.SPEED)
				{
					speedUp.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Object powerInstance = Instantiate(speedUp);
					GameObject power = (GameObject)powerInstance;
					PowerUp control = (PowerUp)power.GetComponent<PowerUp>();
					control.setPosition(x,y);
					control.setType(type);
					control.sprite = power;
				}
				cpt++;
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
