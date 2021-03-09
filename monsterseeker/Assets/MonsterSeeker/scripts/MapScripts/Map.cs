using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map map;
    [SerializeField] private GameObject hexPrefab = null;
    public GameObject[] ItemPrefabs = null;

    private int hard;

    private readonly int width = 10;
    private readonly int height = 10;

    private readonly float xOffset = 76f;
    private readonly float zOffset = 23.5f;

    private Hexagon[] hexList;

    public int[] monsterNum;
    private int[] treasureNum;
    private readonly int treasureAmount = 10; 

    private void Start() {
        map = this;
        hexList = new Hexagon[width*height];

        hard = width * height * 40 / 100;
        monsterNum = new int[hard];
        treasureNum = new int[treasureAmount];
        //medium = width * height * 25 / 100;
        //hard = width * height * 40 / 100;

        AssignHexagonItems();

        int hexNum = 0;
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < height; z++) {
                float xPos = x * xOffset;

                if (z % 2 == 1) {
                    xPos += xOffset / 2f;
                }
                GameObject hexObject = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, -7, z*zOffset), Quaternion.identity);

                hexObject.tag = "Hexagon";
                hexObject.name = "Hex_X:" + x + "_Z:" + z;
                hexObject.transform.SetParent(this.transform);

                Hexagon hexInstance = hexObject.GetComponentInChildren<Hexagon>();
                hexInstance.hexNum = hexNum;
                hexList[hexNum] = hexInstance;

                for(int i = hard - 1; i >= 0; i--) {
                    if (monsterNum[i] == hexNum) {
                        if (hexNum == 45) {
                            continue;
                        }
                        hexInstance.item = Hexagon.Item.Monster;
                        break;
                    } else {
                        if (i < 10) { 
                            if (treasureNum[i] == hexNum) {
                                hexInstance.item = Hexagon.Item.Treasure;
                                break;
                            }
                        }
                    }
                }
                
                hexNum++;
            }
        }
    }

    private void AssignHexagonItems() {
        for (int i = 0; i < hard; i++) {
            monsterNum[i] = Random.Range(0, width * height);
            ItemChecking(i, 1);
        }

        for(int t = 0; t < treasureAmount; t++) {
            treasureNum[t] = Random.Range(0, width * height);
            ItemChecking(t, 2);
        }
    }

    private void ItemChecking(int i, int itemType) {
        switch (itemType) {
            case 1:
                for (int c = i; c > 0; c--) {
                    if (monsterNum[i-c] == monsterNum[i]) {
                        monsterNum[i] = Random.Range(0, width * height);
                        ItemChecking(i, 1);
                    }
                }
                break;

            case 2:
                for (int c = i; c > 0; c--) {
                    if (treasureNum[i-c] == treasureNum[i]) {
                        treasureNum[i] = Random.Range(0, width * height);
                        ItemChecking(i, 2);
                    } else {
                        for (int m = hard - 1; m >= 0; m--) {
                            if (treasureNum[i] == monsterNum[m]) {
                                treasureNum[i] = Random.Range(0, width * height);
                                ItemChecking(i, 2);
                            }
                        }
                    }
                }
                break;

            default:
                Debug.LogError("Error occured.");
                break;
        }
    }
}
