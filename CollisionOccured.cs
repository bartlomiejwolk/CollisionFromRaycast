
// 
// This file is part of the CollisionFromRaycast extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using UnityEngine.Events;

namespace CollisionFromRaycastEx {

    [System.Serializable]
    public class CollisionOccured : UnityEvent<RaycastHit> { }

}