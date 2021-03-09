using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour {

    public Hexagon hexagon;

    private void OnCollisionEnter(Collision collision) {
        hexagon.ActivateObject();
    }
}
