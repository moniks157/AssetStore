using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour {
    public GameObject storeObject;
    static int PRICE_INDEX=5;
    public const float offsetY = 1.9f;
    // Use this for initialization
    void Awake () {
        DataContainer dataContainer = GameObject.FindObjectOfType<DataContainer>();
        if (dataContainer == null)
        {
            Debug.Log("null list");
        }
        else
        {
            Debug.Log("inicjacja"+ dataContainer.notBoughtCharacters.Count);
            for (int i = 0; i < dataContainer.notBoughtCharacters.Count; i++)
            {
                Debug.Log("inicjacja");
                GameObject newStoredObject = Instantiate(storeObject);
                gameObject.transform.GetChild(0).GetComponentInChildren<StoreTailController>().init(dataContainer.notBoughtCharacters[i]);
                Debug.Log(dataContainer.notBoughtItems[i].Name);
                gameObject.transform.GetComponentInChildren<TitleStore>().ObjectName.text = dataContainer.notBoughtCharacters[i].Name;
                gameObject.transform.GetComponentInChildren<TitleStore>().Price.text = dataContainer.notBoughtCharacters[i].SkillValueSum * PRICE_INDEX + "@";

                Vector3 startPos = storeObject.transform.position;

                    float posY = (offsetY * i) + startPos.y;
                    gameObject.transform.position = new Vector3(startPos.x, posY, startPos.z);
            }
            for (int i = 0; i < dataContainer.notBoughtItems.Count; i++)
            {

                Debug.Log("inicjacja");
                GameObject newStoredObject = Instantiate(storeObject);
                gameObject.transform.GetChild(0).GetComponentInChildren<StoreTailController>().init(dataContainer.notBoughtItems[i]);
                Debug.Log(dataContainer.notBoughtItems[i].Name);
                gameObject.transform.GetComponentInChildren<TitleStore>().ObjectName.text = dataContainer.notBoughtItems[i].Name;
                gameObject.transform.GetComponentInChildren<TitleStore>().Price.text = dataContainer.notBoughtItems[i].ItemValueSum* PRICE_INDEX+"@";
                Vector3 startPos = storeObject.transform.position;

                float posY = (offsetY * i) + startPos.y;
                gameObject.transform.position = new Vector3(startPos.x, posY, startPos.z);

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
