using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public bool isDestroyable = false;
    public Materials[] materials;
    public int[] materialsCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObject()
    {
        // Gives you material.
        Debug.Log("Materials!!!");
        MaterialsManager.instance.materials[(int)Materials.Wood] += materialsCount[(int)Materials.Wood];
        MaterialsManager.instance.materials[(int)Materials.Metal] += materialsCount[(int)Materials.Metal];

        // Destroy object or change object's state.
        Destroy(gameObject);
    }
}
