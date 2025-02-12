using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class ApplePicker : MonoBehaviour
{

    [Header("Set in Inspector")]
    public TMP_Text rounds;
    public static int round = 0;
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public static float basketBottomY = -14f;
    public static float basketSpacingY = 2f;
    public static List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        round = 1;
        rounds.text = "Round: " + round.ToString();
        basketList = new List<GameObject>();
        for (int i = 0; i < 4 ; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }
    public void AppleDestroyed(){

        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGo in tAppleArray){
            Destroy(tGo);
        }
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
        
        basketList.RemoveAt(basketIndex);
        
        round++;
        rounds.text = "Round: " + round.ToString();
        Destroy(tBasketGo);
        if ( basketList.Count == 0){
            SceneManager.LoadScene("EndScreen");
        
        }
    }
}
