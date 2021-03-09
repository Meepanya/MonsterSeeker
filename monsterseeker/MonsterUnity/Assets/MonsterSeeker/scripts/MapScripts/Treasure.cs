using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
        Player.agent.TakeTreasure();
    }
}
