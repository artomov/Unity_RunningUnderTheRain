using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionDetector : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"collided with {other}");
    }

}
