
using UnityEngine;
using System.Collections;
using System.Linq;

public class MapGenerator : MonoBehaviour 
{
	public static int width = 20;
	public static int height = 20;

	TileManager tileManager;
	EnemyManager enemyManager;

	public GameObject groundTile;
	public GameObject mountainTile;
	public GameObject mudTile;
	public GameObject spikeTile;

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
		generateTiles();

		generateZombies();
		generateEnnemis();
		generatePowerUps();
	}

	void generateTiles()
	{
		float initialX = transform.position.x-95;
		float initialY = transform.position.y-95;

		int mountains = Random.Range (65,81);
		int mud = Random.Range(30, 40);
		int spikes = Random.Range (10,20);

		for(int i=0;i<20;i++)
		{
			Tile tile = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(i,0,tile);
			mountainTile.transform.position = new Vector3(initialY+(0),initialX+(10*i), 0);
			Instantiate(mountainTile);

			Tile tile2 = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(i,19,tile2);
			mountainTile.transform.position = new Vector3(initialY+(190),initialX+(10*i), 0);
			Instantiate(mountainTile);
		}
		for(int i=1;i<19;i++)
		{
			Tile tile = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(0,i,tile);
			mountainTile.transform.position = new Vector3(initialY+(i*10),initialX+(0), 0);
			Instantiate(mountainTile);

			Tile tile2 = new Tile(Tile.MOUNTAIN);
			tileManager.changeTile(19,i,tile2);
			mountainTile.transform.position = new Vector3(initialY+(i*10),initialX+(190), 0);
			Instantiate(mountainTile);
		}

		int cpt = 0;
		while(cpt != mountains)
		{
			int x = Random.Range(1,19);
			int y = Random.Range(1,19);

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
			int x = Random.Range(1,19);
			int y = Random.Range(1,19);
			
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
			int x = Random.Range(1,19);
			int y = Random.Range(1,19);
			
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

	void generateZombies()
	{
		float initialX = transform.position.x-95;
		float initialY = transform.position.y-95;

		bool onGround = false;
		while(!onGround)
		{
			int x = Random.Range(1,3);
			int y = Random.Range(1,19);
			
			int type = tileManager.getTile(x,y).getType();
			if(type == Tile.GROUND)
			{
				ZombieMale.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
				Instantiate(ZombieMale);
				onGround = true;
			}
		}
		
		onGround = false;
		while(!onGround)
		{
			int x = Random.Range(16,19);
			int y = Random.Range(1,19);
			
			int type = tileManager.getTile(x,y).getType();
			if(type == Tile.GROUND)
			{
				ZombieFemale.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
				Instantiate(ZombieFemale);
				onGround = true;
			}
		}
	}

	bool isCharacterOnTile(int x, int y)
	{
		var query =
			from c in tileManager.getTile(x,y).getEntities()
			where c.name == "Player" || c.name == "Enemy"
				select c;
		if(query.Count() != 0)
			return true;
		else
			return false;
	}
	
	void generateEnnemis()
	{
		float initialX = transform.position.x-95;
		float initialY = transform.position.y-95;
		int ennemies = Random.Range(5,8);

		int cpt = 0;
		while(cpt != ennemies)
		{
			int x = Random.Range(1,19);
			int y = Random.Range(1,19);
			
			if(tileManager.getTile(x,y).getType() == Tile.GROUND && !isCharacterOnTile(x,y))
			{
				EnemyScript enemy = new EnemyScript();
				enemyManager.lesEnemies.Add (enemy);
				int type = enemy.getEnemyType();
				if(type == EnemyScript.GHOST)
				{
					ghost.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Instantiate(ghost);
				}
				if(type == EnemyScript.ELEPHANT)
				{
					elephant.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Instantiate(elephant);
				}
				if(type == EnemyScript.FISH)
				{
					fish.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Instantiate(fish);
				}
				cpt++;
			}
		}
	}

	void generatePowerUps()
	{
		float initialX = transform.position.x-95;
		float initialY = transform.position.y-95;

		int powerUps = Random.Range(5,8);

		int cpt = 0;
		while(cpt != powerUps)
		{
			int x = Random.Range(1,19);
			int y = Random.Range(1,19);
			
			if(tileManager.getTile(x,y).getType() != Tile.MOUNTAIN)
			{
				PowerUp powerUp = new PowerUp();
				int type = powerUp.getType();
				if(type == PowerUp.HEAL)
				{
					healUp.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Instantiate(healUp);
				}
				if(type == PowerUp.ATTACK)
				{
					attackUp.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Instantiate(attackUp);
				}
				if(type == PowerUp.SPEED)
				{
					speedUp.transform.position = new Vector3(initialY+(10*x),initialX+(10*y), 0);
					Instantiate(speedUp);
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
