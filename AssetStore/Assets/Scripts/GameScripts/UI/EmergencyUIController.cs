using Assets.Scripts.Events.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmergencyUIController : MonoBehaviour {

    public Text EmergencyText;
    public GameObject panel;
    public GameObject TilePrefab;

    [SerializeField]
    private EmergencyEvent EmergencyEvent;

    [SerializeField]
    private CharacterEvent CharacterClickedEvent;

    public GameObject CharacterPanel;
    private List<Character> characterList = new List<Character>();
    private List<GameObject> characterTileList = new List<GameObject>();

    private Emergency emergency;
    private bool isEmergencyActive = false;

    private void Start()
    {
        
    }

    void OnEnable()
    {
        EmergencyEvent.AddListener(ShowPanel);
        CharacterClickedEvent.AddListener(AddCharacterToList);
    }

    void OnDisable()
    {
        EmergencyEvent.RemoveListener(ShowPanel);
        CharacterClickedEvent.RemoveListener(AddCharacterToList);
    }

    //Wypełnienie danymi bohatera
    public void ShowPanel(Emergency emergency)
    {
        isEmergencyActive = true;
        this.emergency = emergency;
        Debug.Log(emergency.ToString());
        //Włączenie/ wyłączenie panelu
        panel.SetActive(true);
        EmergencyText.text = emergency.ToString();
    }

    public void SendHeroes()
    {
        if (characterList.Count != 0)
        {
            var showdownResult = Showdown.Battle(characterList, emergency.enemies);
            Debug.Log(showdownResult);
            isEmergencyActive = false;
        }
    }

    private List<Character> GetCharacyerList(List<GameObject> tileList)
    {

        List<Character> result = new List<Character>();

        foreach(var g in tileList)
        {
            result.Add(g.GetComponentInChildren<TileController>().tile as Character);
        }

        return result;
    }

    private void AddCharacterToList(Character character)
    {
        if (isEmergencyActive)
        {
            if (!characterList.Contains(character) && characterList.Count < 5)
            {
                var tile = Instantiate(TilePrefab, CharacterPanel.transform);
                characterTileList.Add(tile);
                var tileClass = tile.GetComponentInChildren<TileController>();
                tileClass.tile = character;
                tileClass.SetData();
                characterList.Add(character);
            }
            else
            {
                var toDestroy = characterTileList[characterList.IndexOf(character)];
                characterTileList.Remove(toDestroy);
                Destroy(toDestroy);
                characterList.Remove(character);
            }
        }
    }
}
