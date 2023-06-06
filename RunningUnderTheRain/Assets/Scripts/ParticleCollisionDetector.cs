using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionDetector : MonoBehaviour
{
    public System.Action OnCollisionDetected;

    void OnParticleCollision(GameObject other)
    {
        OnCollisionDetected?.Invoke();
    }

}
