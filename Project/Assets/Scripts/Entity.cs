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

public class Entity : MonoBehaviour
{
	int x;
	int y;
    string identity;

	public Entity ()
	{
        setIdentity("");
		/*x = 0;
		y = 0;
        TileManager.getInstance().addEntityToTile(x, y, this);*/
	}

	public void setPosition(int x, int y)
	{
        if (x >= 0 && y >= 0)
        {
            TileManager.getInstance().changeEntityPosition(this.x, this.y, x, y, this);
            this.x = x;
            this.y = y;
        }
	}

	public int getX()
	{
		return x;
	}

	public int getY()
	{
		return y;
	}

	public Tile getTile()
	{
		return TileManager.getInstance().getTile(x, y);
	}

    public void setIdentity(string leName)
    {
		this.identity = leName;
    }

	public string getIdentity()
	{
		return identity;
	}
}


