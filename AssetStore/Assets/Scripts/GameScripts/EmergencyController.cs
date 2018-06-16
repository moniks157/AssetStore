using Assets.Scripts.Events.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyController : MonoBehaviour {

    public List<Skill> allSkillsList;

    [SerializeField]
    private EmergencyEvent emergencyEvent;

    public float minIntervalSec;
    public int afterMinimalProbability;

    private float lastTimeEmergency; 

    private void Start() 
    {
        lastTimeEmergency = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad > lastTimeEmergency + minIntervalSec)
        {
            if(Random.Range(0,100) < afterMinimalProbability)
            {
                lastTimeEmergency = Time.timeSinceLevelLoad;
                Emergency emergency = new Emergency(Random.Range(1, 3), 30,allSkillsList);
                emergencyEvent.Invoke(emergency);
            }
        }
    }
}
