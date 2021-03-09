using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IInput
{
    public static Player agent;

    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }

    public GameObject[] hearts;
    private int lifes = 5;

    public Sprite[] treasureNumbers;
    public GameObject treasureCount;
    public GameObject scoreObject;
    private int treasures = 0;
    public GameObject GameOverBackGround;
    public GameObject VictoryBackGround;

    private void Start() {
        agent = this;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        GetMovementInput();
        GetMovementDirection();
        if (transform.position.y < -200) {
            transform.position = new Vector3(342f, 0f, 117.5f);
            TakeDamage();
        }
    }

    private void GetMovementInput() {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMovementInput?.Invoke(input);
    }

    private void GetMovementDirection() {
        Vector3 cameraForewardDirection = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, cameraForewardDirection * 10, Color.red);
        Vector3 directionToMoveIn = Vector3.Scale(cameraForewardDirection, (Vector3.right + Vector3.forward));
        Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 10, Color.blue);
        OnMovementDirectionInput?.Invoke(directionToMoveIn);
    }

    public void TakeDamage() {
        lifes -= 1;
        Destroy(hearts[lifes]);
        if (lifes == 0) {
            Destroy(this);
            GameOver();
        }
    }

    public void TakeTreasure() {
        treasureCount.GetComponent<Image>().sprite = treasureNumbers[treasures];
        treasures += 1;
        if (treasures >= 10) {
            DeclareVictory();
        }
    }

    private void GameOver() {
        GameOverBackGround.SetActive(true);
        if (treasures > 0) {
            scoreObject.GetComponent<Image>().sprite = treasureNumbers[treasures - 1];
        }
        Time.timeScale = 0;
    }

    private void DeclareVictory() {
        VictoryBackGround.SetActive(true);
        Time.timeScale = 0;
    }
}
