using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour {
	public GameObject prefab;
	public Vector2Int size = new Vector2Int(40,38);
	public float offX,offY;
	public string objName ="GrassTile";

    // Start is called before the first frame update
    void Start(){
        Generate();
    }
	
    void Generate()  {
		for (int x = 0; x < size.x; x++) {
			for (int y = 0; y < size.y; y++) {
				GameObject obj = Instantiate(prefab,transform);
				obj.transform.localScale = Vector3.one;
				obj.transform.position = new Vector3(-(x+offX),0f,y+offY);
				obj.name = objName;
			}
		}
    }
}
