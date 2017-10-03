using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Terrains
{
    GRASS,
    SAND,
    WATER,
    WALL,
    HILL,
    START,
    FINISH
}

[System.Serializable]
public struct TerrainColor
{
    public Terrains terr;
    public Color col;
}


public class TextureMap : MonoBehaviour {
    public Texture2D texMap;
    public Vector3 size = new Vector3(192, 0, 160);

    [SerializeField]
    public TerrainColor[] terrainColors;

	[SerializeField]
	public GameObject hole;
    //[SerializeField]
    //Terrains terrainMouse;

    // Use this for initialization
    void Start()
    {
        texMap = GetComponent<SpriteRenderer>().sprite.texture;
        Color[] col = texMap.GetPixels();
        float dist = 1000000;
		Vector2 startPos = Vector2.zero;
		Vector2 holePos = Vector2.zero;
        foreach (var terrColor in terrainColors)
        {
            if (terrColor.terr == Terrains.START)
            {
                for (int x = 0; x < texMap.width; x++)
                {
                    for (int y = 0; y < texMap.height; y++)
                    {
                        var currentDist = Vector4.Distance(col[x+y*texMap.width], terrColor.col);
                        if (currentDist < dist)
                        {
                            dist = currentDist;
                            startPos = new Vector2(x, y);
                        }
                    }
                }
            }
            if (terrColor.terr == Terrains.FINISH)
            {
                for (int x = 0; x < texMap.width; x++)
                {
                    for (int y = 0; y < texMap.height; y++)
                    {
                        var currentDist = Vector4.Distance(col[x + y * texMap.width], terrColor.col);
                        if (currentDist < dist)
                        {
                            dist = currentDist;
                            holePos = new Vector2(x, y);
                        }
                    }
                }
            }
        }

        GameObject holeInstance = Instantiate(hole);
		Vector3 pos = Camera.main.ScreenToWorldPoint(holePos);
		pos.z = 0.0f;
		holeInstance.transform.position  = pos;

    }

    void Update()
    {
       // terrainMouse = getTerrainAtPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public Terrains getTerrainAtPosition(Vector3 pos)
    {
        var vec = Camera.main.WorldToScreenPoint(pos);
        int x = Mathf.FloorToInt(vec.x * texMap.width / Camera.main.pixelWidth);
        int z = Mathf.FloorToInt(vec.y * texMap.height / Camera.main.pixelHeight);
        Color col = texMap.GetPixel(x, z);

        float dist = 1000000;
        Terrains terr = Terrains.WATER;
        foreach (var terrColor in terrainColors)
        {
            var currentDist = Vector4.Distance(col, terrColor.col);
            if (currentDist < dist)
            {
                dist = currentDist;
                terr = terrColor.terr;
            }
        }
        return terr;
    }

}
