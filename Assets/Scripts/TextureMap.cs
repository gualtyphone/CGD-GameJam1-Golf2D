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

	[SerializeField]
	public GameObject wall;

	public List<GameObject> walls;

	public Vector2 startPos = Vector2.zero;
    //[SerializeField]
    //Terrains terrainMouse;

    // Use this for initialization
    void Start()
    {
		walls = new List<GameObject>();
        texMap = GetComponent<SpriteRenderer>().sprite.texture;
        Color[] col = texMap.GetPixels();
		float dist1 = 100000000;
		float dist2 = 100000000;
		Vector2 holePos = Vector2.zero;
		for (int x = 0; x < texMap.width; x++)
		{
			for (int y = 0; y < texMap.height; y++)
			{
		        foreach (var terrColor in terrainColors)
		        {
		            if (terrColor.terr == Terrains.START)
		            {
						
                        var currentDist = Vector4.Distance(col[x+y*texMap.width], terrColor.col);
                        if (currentDist < dist1)
                        {
                            dist1 = currentDist;
                            startPos = new Vector2(x, y);
                        }
                    }
					if (terrColor.terr == Terrains.FINISH)
					{
						var currentDist = Vector4.Distance(col[x+ (y*texMap.width)], terrColor.col);
						if (currentDist < dist2)
						{
							dist2 = currentDist;
							holePos = new Vector2(x, y);
						}
					}
					if (terrColor.terr == Terrains.WALL)
					{
						if (Vector4.Distance(col[x+ (y*texMap.width)], terrColor.col) <= 0.1f)
						{
							walls.Add(Instantiate(wall,new Vector3(x/100.0f , y/100.0f, 0),new Quaternion()));
						}
					}
				}
			}
            
        }

        GameObject holeInstance = Instantiate(hole);
		Vector2 position = new Vector2();
		position.x = holePos.x /100.0f;
		position.y = holePos.y /100.0f;

		startPos = startPos/100.0f;

		GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
		foreach (GameObject ball in balls)
		{
			ball.transform.position = startPos;
		}

		holeInstance.transform.position = position;
		//pos.x = (holePos.x / texMap.width * Camera.main.pixelWidth);
		//pos.y = (holePos.y / texMap.height * Camera.main.pixelHeight);
		//pos.z = 0.0f;
		//holeInstance.transform.position = pos;

    }

    void Update()
    {
       // terrainMouse = getTerrainAtPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public Terrains getTerrainAtPosition(Vector3 pos)
    {
        //var vec = Camera.main.WorldToScreenPoint(pos);
        int x = Mathf.FloorToInt(pos.x * 100);
        int z = Mathf.FloorToInt(pos.y * 100);
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
