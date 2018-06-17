using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class StoreController : MonoBehaviour {
    public GameObject storeObject;
    static int PRICE_INDEX=5;

    public GameObject hero1;
    public GameObject hero2;
    public GameObject hero3;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;


    // Use this for initialization

    void Awake () {


        System.Random r = new System.Random();
        DataContainer dataContainer = GameObject.FindObjectOfType<DataContainer>();
        
        if (dataContainer == null)
        {
            Debug.Log("null list");
        }
        else
        {
            List<int> indexsList = new List<int>();
            if (dataContainer.notBoughtCharacters.Count > 2)
            {

                while (indexsList.Count < 3)
                {
                    Debug.Log("while");
                    int index = r.Next(0, dataContainer.notBoughtCharacters.Count);
                    if (!indexsList.Contains(index))
                    {
                        indexsList.Add(index);
                    }
                }
                Debug.Log("init method");
                hero1.GetComponent<TitleStore>().init(dataContainer.notBoughtCharacters[indexsList[0]], false);
                hero2.GetComponent<TitleStore>().init(dataContainer.notBoughtCharacters[indexsList[1]], false);
                hero3.GetComponent<TitleStore>().init(dataContainer.notBoughtCharacters[indexsList[2]], false);
            }else
            {
                if (dataContainer.notBoughtCharacters.Count == 1)
                {
                    hero1.GetComponent<TitleStore>().init(dataContainer.notBoughtCharacters[indexsList[0]], false);
                    hero2.SetActive(false);
                    hero3.SetActive(false);
                } 
                if (dataContainer.notBoughtCharacters.Count ==0)
                {
                    hero1.SetActive(false);
                    hero2.SetActive(false);
                    hero3.SetActive(false);

                }
                else
                {
                    hero1.GetComponent<TitleStore>().init(dataContainer.notBoughtCharacters[indexsList[0]], false);
                    hero2.GetComponent<TitleStore>().init(dataContainer.notBoughtCharacters[indexsList[1]], false);
                    hero3.SetActive(false);
                }
            }

            indexsList.Clear();

            if (dataContainer.notBoughtItems.Count > 2)
            {
        
                while (indexsList.Count < 3)
                {
                    Debug.Log("while");
                    int index = r.Next(0, dataContainer.notBoughtItems.Count);
                    if (!indexsList.Contains(index))
                    {
                        indexsList.Add(index);
                    }
                }
                Debug.Log("init method");
            item1.GetComponent<TitleStore>().init(dataContainer.notBoughtItems[indexsList[0]], true);
            item2.GetComponent<TitleStore>().init(dataContainer.notBoughtItems[indexsList[1]], true);
            item3.GetComponent<TitleStore>().init(dataContainer.notBoughtItems[indexsList[2]], true);
        }
            else
            {
                if (dataContainer.notBoughtItems.Count == 1)
                {
                    item1.GetComponent<TitleStore>().init(dataContainer.notBoughtItems[indexsList[0]], true);
                    item2.SetActive(false);
                    item3.SetActive(false);
                }
                if (dataContainer.notBoughtItems.Count == 0)
                {
                    item1.SetActive(false);
                    item2.SetActive(false);
                    item3.SetActive(false);

                }
                else
                {
                    item1.GetComponent<TitleStore>().init(dataContainer.notBoughtItems[indexsList[0]], true);
                    item2.GetComponent<TitleStore>().init(dataContainer.notBoughtItems[indexsList[1]], true);
                    item3.SetActive(false);
                }
            }

            indexsList.Clear();
            
           
        }
    }
   public void Buy()
    {
        
    }

}
