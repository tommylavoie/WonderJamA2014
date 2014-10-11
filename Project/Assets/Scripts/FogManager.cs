//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18052
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
public class FogManager
{
	GameObject[][] fogs;
	
	private static FogManager Instance;
	
	public static FogManager getInstance()
	{
		if(Instance == null)
		{
			Instance = new FogManager();
		}
		return Instance;
	}
	
	private FogManager()
	{
		fogs = new GameObject[MapGenerator.width][];
		for(int i=0;i<MapGenerator.width;i++)
		{
			fogs[i] = new GameObject[MapGenerator.height];
			for (int j = 0; j < MapGenerator.height; j++)
			{
				fogs[i][j] = null;
			}
		}
	}
	
	public void addFog(int x, int y, GameObject fog)
	{
		fogs[x][y] = fog;
	}

	public void unFog(int x, int y)
	{
		unFogCell(x,y-2);
		unFogCell(x-1,y-1);
		unFogCell(x,y-1);
		unFogCell(x+1,y-1);
		unFogCell(x-2,y);
		unFogCell(x-1,y);
		unFogCell(x,y);
		unFogCell(x+1,y);
		unFogCell(x+2,y);
		unFogCell(x-1,y+1);
		unFogCell(x,y+1);
		unFogCell(x+1,y+1);
		unFogCell(x,y-2);
	}

	public void unFogCell(int x, int y)
	{
		if(x >= 0 && y >= 0 && x < MapGenerator.width && y < MapGenerator.height)
		{
			if(fogs[x][y] != null)
			{
				MonoBehaviour.Destroy(fogs[x][y]);
				fogs[x][y] = null;
			}
		}
	}
}

