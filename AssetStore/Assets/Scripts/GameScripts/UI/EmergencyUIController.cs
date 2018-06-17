using Assets.Scripts.Events.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmergencyUIController : MonoBehaviour {

    public Text EmergencyText;

    [SerializeField]
    private EmergencyEvent Emergency;

    void Awake()
    {
        Emergency.AddListener(ShowPanel);
    }

    void OnDisable()
    {
        Emergency.RemoveListener(ShowPanel);
    }

    //Wypełnienie danymi bohatera
    public void ShowPanel(Emergency emergency)
    {
        Debug.Log(emergency.ToString());
        //Włączenie/ wyłączenie panelu
        gameObject.SetActive(!gameObject.activeSelf);
        EmergencyText.text = emergency.ToString();
        
    }
}
