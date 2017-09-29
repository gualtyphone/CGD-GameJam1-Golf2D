using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Terrains
{
    SAND,
    WATER,
    GREEN,
    ROUGH,
    FOREST
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

    //[SerializeField]
    //Terrains terrainMouse;

    // Use this for initialization
    void Start()
    {
        texMap = GetComponent<SpriteRenderer>().sprite.texture;
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
        Terrains terr = Terrains.FOREST;
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
