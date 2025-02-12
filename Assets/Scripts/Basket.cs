using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    private TMP_Text scoreGT;
    public static int score;
    public GameObject basketPrefab;
    void Start(){
        GameObject scoreGO = GameObject.Find("ScoreCounterReal");
        scoreGT = scoreGO.GetComponent<TMP_Text>();
        score = 0;
        scoreGT.text = "0";
    }
    void Update()
    {
        UnityEngine.Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;
        UnityEngine.Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        UnityEngine.Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
    void OnCollisionEnter(Collision coll){
        GameObject collideWith = coll.gameObject;
        if(collideWith.tag=="Apple"){
            Destroy(collideWith);

            score+=100;
            scoreGT.text = score.ToString();
            if ( score > HighScore.score){
                HighScore.score = score;
            }
        }
        else if(collideWith.tag == "GreenApple")
        {
            SceneManager.LoadScene("EndScreen");
            
        }
        else if(collideWith.tag == "Gift")
        {
            Destroy(collideWith);
            
            if(ApplePicker.basketList.Count < 4)
            {
            GameObject basket = Instantiate<GameObject>(basketPrefab);
            UnityEngine.Vector3 pos = UnityEngine.Vector3.zero;
            pos.y = ApplePicker.basketBottomY + ( ApplePicker.basketSpacingY * ApplePicker.basketList.Count);
            basket.transform.position = pos;
            ApplePicker.basketList.Add(basket);
            }
            else
            {
                score += 500;
                scoreGT.text = score.ToString();
                if ( score >HighScore.score)
                {
                    HighScore.score = score;
                }

            }

        }
    }
}
