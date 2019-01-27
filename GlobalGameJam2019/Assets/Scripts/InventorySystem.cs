using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance = null;
    public GameObject itemPanel;
    public GameObject player;
    public Button[] items;
    public List<Item> listOfItems;

    public Item[] item;

    public Sprite imageSelected;

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpController;
    private bool m_isMenuOpened = false;

    private int numberOfItemSelected = 0;
    private GameObject placeObject = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach(Item i in item)
        {
            i.itemCount = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        itemPanel.SetActive(false);
        fpController = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpController.enabled = true;

        listOfItems.Add(item[0]);
        listOfItems.Add(item[1]);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < listOfItems.Count; i++)
        {
            //items[i].image = item[i].itemImage;
            items[i].GetComponentsInChildren<Text>()[0].text = listOfItems[i].itemCount.ToString();
            items[i].GetComponentsInChildren<Text>()[1].text = listOfItems[i].itemName;
            items[i].gameObject.SetActive(true);
        }
        for(int i=listOfItems.Count; i<16;i++)
        {
            items[i].gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.B))
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
        if(Input.GetKeyDown(KeyCode.V))
        {
            if (placeObject)
            {
                GameObject go = Instantiate(placeObject, placeObject.transform.position, placeObject.transform.rotation);
                go.AddComponent<Rigidbody>();
                //placeObject = null;
                Destroy(placeObject);
            }
        }
    }

    public void AddItem(Item item, int itemCount)
    {
        if (item.itemCount == 0)
        {
            item.itemCount += itemCount;
            //listOfItems.Add(item);
        }
        else
        {
            item.itemCount += itemCount;
        }
    }

    public void DeleteItem(Item item)
    {
        if (item.itemCount > 0)
        {
            item.itemCount--;
        }
        else 
        {
            item.itemCount--;
            //listOfItems.Remove(item);
        }
    }

    public void SelectItem(int buttonNumber)
    {
        // Add highlight for selection
        //if (numberOfItemSelected < 3)
        //{
        if (buttonNumber < listOfItems.Count && listOfItems[buttonNumber].itemCount > 0)
        {
            Image image = items[buttonNumber].GetComponentsInChildren<Image>()[1].GetComponent<Image>();
            if (!image.isActiveAndEnabled)
            {
                if (numberOfItemSelected < 2)
                {
                    image.enabled = true;
                    numberOfItemSelected++;
                }
            }
            else
            {
                if (numberOfItemSelected > 0)
                {
                    image.enabled = false;
                    numberOfItemSelected--;
                }
            }

            Debug.Log(buttonNumber + " Item selected!");
        }
    }

    public void Combine()
    {
        if(numberOfItemSelected==2)
        {
            for(int i=0;i<items.Length;i++)
            {
                Image image = items[i].GetComponentsInChildren<Image>()[1].GetComponent<Image>();
                if(image.isActiveAndEnabled)
                {
                    listOfItems[i].itemCount--;
                    image.enabled = false;
                }
            }

            numberOfItemSelected = 0;
            Debug.Log("Combine!");
            // Add new combined item
            // Check recipe 
            for(int i=0;i<item.Length;i++)
            {
                if(item[i].itemName == "Plastic")
                {
                    AddItem(item[i], 1);
                    listOfItems.Add(item[i]);
                }
            }


        }
    }
    public void Place()
    {
        if(numberOfItemSelected==1)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Image image = items[i].GetComponentsInChildren<Image>()[1].GetComponent<Image>();
                if (image.isActiveAndEnabled)
                {
                    listOfItems[i].itemCount--;
                    image.enabled = false;
                    numberOfItemSelected = 0;
                    GameObject go = Instantiate(listOfItems[i].model, fpController.transform);
                    placeObject = go;
                    //go.transform.position = Vector3.forward*2;
                    break;
                }
            }

            Debug.Log("Place item");
        }
    }
}
