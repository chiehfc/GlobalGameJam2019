using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectObjectScript : MonoBehaviour
{
    public Text destroyPrompt;
    private GameObject lockedObject;
    // Start is called before the first frame update
    void Start()
    {
        destroyPrompt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyPrompt.enabled)
        {
            if(Input.GetKey(KeyCode.C))
            {
                if (lockedObject != null)
                {
                    Debug.Log("Destroyed!!!");
                    lockedObject.GetComponent<Object>().DestroyObject();
                    lockedObject = null;
                    destroyPrompt.enabled = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DestroyableObject"))
        {
            Debug.Log("DestroyableObject");
            destroyPrompt.enabled = true;
            lockedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        destroyPrompt.enabled = false;
    }
}
