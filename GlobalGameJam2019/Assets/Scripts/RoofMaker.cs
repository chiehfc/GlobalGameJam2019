using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofMaker : MonoBehaviour {
	public GameObject prefab;
	public Vector3 startPt;
	public float offSetX,offSetY;
	public float centerOff;
	public int sizeX,sizeY;

	public GameObject prefabeTop;
	public Vector3 roofTop;


    // Start is called before the first frame update
    void Start() {
        GenerateRoof();
    }

    // Update is called once per frame
    void GenerateRoof() {
		int x =0;
		
		for(x = 0; x < sizeX;x++) {
			float z = 0;
			for (int y = 0; y < sizeY; y++) {
				GameObject obj = Instantiate(prefab,transform);
				obj.transform.localScale = Vector3.one;
				obj.transform.localPosition = new Vector3(-(x+offSetX),z,-(y+offSetY));
				obj.name = "RoofTile";
			

				GameObject obj2 = Instantiate(prefab,transform);
				obj2.transform.localScale = Vector3.one;
				obj2.transform.eulerAngles = new Vector3(0,180f,0);
				obj2.transform.localPosition = new Vector3(-(x+offSetX),z,-(centerOff+sizeY-y));
				obj2.name = "RoofTile";
				z += 0.5f;
			}
		}
    }

}
