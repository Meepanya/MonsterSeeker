using System;
using UnityEngine;

internal interface IInput {
    Action<Vector2> OnMovementInput { get; set; }
    Action<Vector3> OnMovementDirectionInput { get; set; }
}