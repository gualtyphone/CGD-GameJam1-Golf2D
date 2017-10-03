using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatMap : MonoBehaviour {
    public Texture2D heightmap;
    public Vector3 size = new Vector3(192, 0, 160);
    public float[] array;

    // Use this for initialization
    void Start () {
        array = new float[9];
        heightmap = GetComponent<SpriteRenderer>().sprite.texture;
        array = getPixelsAtPosition(new Vector3(0.0f, 0.0f, 0.0f));
	}

    void Update()
    {
       //if (Input.GetMouseButton(0))
       // {
            //Debug.Log(Camera.current.ScreenToWorldPoint(Input.mousePosition));
       //     array = getPixelsAtPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
       // } 
    }

    public float[] getPixelsAtPosition(Vector3 pos)
    {
        //var vec = Camera.main.WorldToScreenPoint(pos);
        int x = Mathf.FloorToInt(pos.x * 100.0f);
        int z = Mathf.FloorToInt(pos.y * 100.0f);
        float[] arr = new float[9];
        if (x - 1 > 0 && z - 1 > 0 && x + 2 < heightmap.width && z + 2 < heightmap.height)
        {
			if (heightmap == null)
			{
				return arr;
			}
            Color[] colArr = heightmap.GetPixels(x - 1, z - 1, 3, 3);
            for (int w = 0; w < 3; w++)
            {
                for (int h = 0; h < 3; h++)
                {
                    arr[w + h * 3] = colArr[w + h * 3].r;
                }
            }
            return arr;
        }
        else
        {
            return arr;
        }
    }

}
