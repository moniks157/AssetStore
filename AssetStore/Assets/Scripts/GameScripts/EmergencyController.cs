using Assets.Scripts.Events.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyController : MonoBehaviour {
   
    [SerializeField]
    private EmergencyEvent emergencyEvent;

    [SerializeField]
    private NativeEvent endEmergencyEvent;

    public float minIntervalSec;
    public int afterMinimalProbability;

    private float lastTimeEmergency;

    private List<Skill> allSkillsList;
    private bool isActivEmergency = false;

    private void OnEnable()
    {
        endEmergencyEvent.AddListener(ChangeState);
    }

    private void OnDisable()
    {
        endEmergencyEvent.RemoveListener(ChangeState);
    }

    private void Start() 
    {
        allSkillsList = FindObjectOfType<DataContainer>().allSkills;
        lastTimeEmergency = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad > lastTimeEmergency + minIntervalSec && !isActivEmergency)
        {
            if(Random.Range(0,100) < afterMinimalProbability)
            {
                isActivEmergency = true;
                lastTimeEmergency = Time.timeSinceLevelLoad;
                Emergency emergency = new Emergency(Random.Range(1, 3), Random.Range(20,50),new List<Skill>(allSkillsList));
                emergencyEvent.Invoke(emergency);
            }
        }
    }

    private void ChangeState()
    {
        isActivEmergency = false;
    }
}
