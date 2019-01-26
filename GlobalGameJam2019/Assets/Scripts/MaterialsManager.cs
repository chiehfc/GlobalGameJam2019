using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsManager : MonoBehaviour
{
    public int[] materials;
    public Text[] materialsText;

    public static MaterialsManager instance = null;

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start() 
    {
        materials = new int[2];    
    }

    // Update is called once per frame
    void Update()
    {
        materialsText[(int)Materials.Wood].text = materials[(int)Materials.Wood].ToString();
        materialsText[(int)Materials.Metal].text = materials[(int)Materials.Metal].ToString();
    }

    public int GetMaterial(Materials material)
    {
        return materials[(int)material];
    }
}
