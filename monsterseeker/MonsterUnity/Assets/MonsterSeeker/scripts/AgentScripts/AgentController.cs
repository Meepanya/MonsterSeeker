using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {
    private IInput input;
    private AgentMovement movement;

    private void Start() {
        input = GetComponent<IInput>();
        movement = GetComponent<AgentMovement>();
        input.OnMovementDirectionInput +=  movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }

    private void OnDisable() {
        input.OnMovementDirectionInput -= movement.HandleMovementDirection;
        input.OnMovementInput -= movement.HandleMovement;
    }
}
