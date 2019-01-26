using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject itemPanel;
    public GameObject player;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpController;
    private bool m_isMenuOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        itemPanel.SetActive(false);
        fpController = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            if (!m_isMenuOpened)
            {
                itemPanel.SetActive(true);
                fpController.enabled = false;
                m_isMenuOpened = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                itemPanel.SetActive(false);
                fpController.enabled = true;
                m_isMenuOpened = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
