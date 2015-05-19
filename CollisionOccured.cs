using UnityEngine;
using UnityEngine.Events;

namespace CollisionFromRaycastEx {

    [System.Serializable]
    public class CollisionOccured : UnityEvent<RaycastHit> { }

}