using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hexagon : MonoBehaviour {

    private bool isActivated;
    public int hexNum;

    public Item item;
    public enum Item {
        Empty,
        Monster,
        Treasure
    }

    private void Start() {
        if (hexNum == 45) {
            ActivateObject();
        }
    }

    public void ActivateObject() {
        if (isActivated) { return; }
        isActivated = true;

        int itemNum = (int)item;
        GameObject itemObject = null;
        if (itemNum > 0) {
            itemObject = Instantiate(Map.map.ItemPrefabs[itemNum], transform);
            itemObject.transform.SetParent(transform);
        }
        CreateAlienAmountSign(); 

        StartCoroutine(LiftUpHexagon(2.5f));
        if (item == Item.Monster) {
            StartCoroutine(ChaseAgent(itemObject, 1.3f));
            Player.agent.TakeDamage();
        }
    }

    private void CreateAlienAmountSign() {
        int aliensAmount = CountAliensNearby();
        if (aliensAmount > 0) { 
            GameObject itemObject = Instantiate(Map.map.ItemPrefabs[0], transform);
            itemObject.transform.SetParent(transform);

            SetNumberOfAliens(itemObject, aliensAmount);
        }
    }

    private int CountAliensNearby() {
        int aliensAroundNumber = 0;
        if (hexNum % 2 == 1) {
            IEnumerable<Hexagon> selectedHexagons = from hexagon in FindObjectsOfType<Hexagon>()
                                   where hexagon.hexNum - hexNum == 2 || hexagon.hexNum - hexNum == 11 || hexagon.hexNum - hexNum == 9
                                   || hexagon.hexNum - hexNum == -2 || hexagon.hexNum - hexNum == -1 || hexagon.hexNum - hexNum == 1
                                   select hexagon;
            foreach( Hexagon hex in selectedHexagons) {
                if (hex.item == Item.Monster) {
                    aliensAroundNumber += 1;
                }
            }
        } else {
            IEnumerable<Hexagon> selectedHexagons = from hexagon in FindObjectsOfType<Hexagon>()
                                   where hexagon.hexNum - hexNum == 2 || hexagon.hexNum - hexNum == 1 || hexagon.hexNum - hexNum == -1
                                   || hexagon.hexNum - hexNum == -2 || hexagon.hexNum - hexNum == -11 || hexagon.hexNum - hexNum == -9
                                   select hexagon;
            foreach( Hexagon hex in selectedHexagons) {
                if (hex.item == Item.Monster) {
                    aliensAroundNumber += 1;
                }
            }
        }
        return aliensAroundNumber;
    }

    private void SetNumberOfAliens(GameObject itemObject, int aliensAmount) {
        switch (aliensAmount) {
            case 1:
                itemObject.transform.localScale = new Vector3(50f, 0.1f, 50f);
                itemObject.transform.localRotation = Quaternion.Euler(180,0,0);
                break;
            case 2:
                itemObject.transform.localScale = new Vector3(50f, 50f, 0.1f);
                itemObject.transform.localRotation = Quaternion.Euler(90, 0, 0);
                break;
            case 3:
                itemObject.transform.localScale = new Vector3(50f, 0.1f, 50f);
                break;
            case 4:
                itemObject.transform.localScale = new Vector3(0.1f, 50f, 50f);
                itemObject.transform.localRotation = Quaternion.Euler(0, 0, 90);
                break;
            case 5:
                itemObject.transform.localScale = new Vector3(50f, 50f, 0.1f);
                itemObject.transform.localRotation = Quaternion.Euler(270, 0, 0);
                break;
            case 6:
                itemObject.transform.localScale = new Vector3(0.1f, 50f, 50f);
                itemObject.transform.localRotation = Quaternion.Euler(180, 0, 90);
                break;
            default:
                Debug.LogError("IndexError: AliensNum more than 6.");
                break;
        }
    }

    private IEnumerator LiftUpHexagon(float time) {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = new Vector3(transform.position.x, transform.position.y + 7, transform.position.z);

        float elapsedTime = 0;

        while (elapsedTime < time) {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ChaseAgent(GameObject alien, float time) {
        Player agent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        float elapsedTime = 0;

        while (elapsedTime < time) {
            alien.transform.LookAt(agent.gameObject.transform);
            alien.transform.position = Vector3.Lerp(alien.transform.position, agent.transform.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(alien);
    }
}
