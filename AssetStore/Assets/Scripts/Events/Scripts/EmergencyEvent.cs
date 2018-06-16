using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Events.Scripts
{
    [CreateAssetMenu(menuName = "Gameplay/Events/EmergencyEvent")]
    class EmergencyEvent : NativeEvent<Emergency>{}
}
