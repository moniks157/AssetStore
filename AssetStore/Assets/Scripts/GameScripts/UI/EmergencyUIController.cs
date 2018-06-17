using Assets.Scripts.Events.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class EmergencyUIController : MonoBehaviour {

    public Text EmergencyText;
    public GameObject panel;
    public GameObject TilePrefab;
    public Image timer;
    public float timeToSend;
    public GameObject ResultPanel;
    public Text ResultDescription;

    [SerializeField]
    private NativeEvent endEmergensiEvent;

    [SerializeField]
    private EmergencyEvent EmergencyEvent;

    [SerializeField]
    private CharacterEvent CharacterClickedEvent;

    public GameObject CharacterPanel;
    private List<Character> characterList = new List<Character>();
    private List<GameObject> characterTileList = new List<GameObject>();

    private Emergency emergency;
    private bool isEmergencyActive = false;
    private float emergencyTimeStart;
    private float timerTimeLeft;
    private DataContainer dataContainer;

    private void Start()
    {
        dataContainer = FindObjectOfType<DataContainer>();
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
        //Włączenie/ wyłączenie panelu
        panel.SetActive(true);
        EmergencyText.text = emergency.ToString();
        emergencyTimeStart = Time.timeSinceLevelLoad;
        timerTimeLeft = timeToSend;
    }

    private void Update()
    {
        if (isEmergencyActive)
        {
            if (Time.timeSinceLevelLoad > emergencyTimeStart + timeToSend)
            {
                SendHeroes();
                timer.fillAmount = 0;
            }
            else
            {
                timer.fillAmount = ((timerTimeLeft ) / timeToSend);
            }
        }
    }

    private void FixedUpdate()
    {
        timerTimeLeft -= Time.deltaTime;
    }

    public void SendHeroes()
    {
        if (characterList.Count != 0)
        {
            var showdownResult = Showdown.Battle(characterList, emergency.enemies);
            isEmergencyActive = false;
            panel.SetActive(false);
            foreach(var h in characterList)
            {
                if(h.actualHpPoints <= 0)
                {
                    dataContainer.boughtCharacters.Remove(h);
                    dataContainer.deadHeroes.Add(h);
                }
            }

            if (showdownResult)
            {
                dataContainer.money += emergency.money;
            }
            else
            {
                dataContainer.money -= emergency.money;
            }

            ResultDescription.text = GetResult(characterList, emergency.enemies, showdownResult);
            ResultPanel.SetActive(true);
            endEmergensiEvent.Invoke();
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

    private string GetResult(List<Character> heroes, List<Character> enemies, bool result)
    {
        StringBuilder builder = new StringBuilder();

        if (result)
        {
            builder.AppendLine("Victory!");
        }
        else
        {
            builder.AppendLine("Defet!");
        }

        builder.AppendLine("enemies defeted:");
        foreach(var h in enemies)
        {
            if(h.actualHpPoints <= 0)
            {
                builder.AppendLine(h.Name);
            }
        }

        builder.AppendLine("dead heroes");
        foreach (var h in heroes)
        {
            if (h.actualHpPoints <= 0)
            {
                builder.AppendLine(h.Name);
            }
        }
        gameObject.SendMessage("LoadItems");

        characterList.Clear();
        foreach (var g in characterTileList)
        {
            Destroy(g);
        }
        return builder.ToString();
        
    }
}
