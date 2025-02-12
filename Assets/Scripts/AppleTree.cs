using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject applePrefab;
    public GameObject greenApplePrefab;

    public GameObject giftPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 20f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    public float secondsBetweenGiftDrops = 50f;

    public float secondsBetweenGreenAppleDrops = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
        
        Invoke("DropApple",2f); 
      
      
        Invoke("DropGreenApple",10f);
        Invoke("DropRedGift",50f);
      
        
    }

   void DropRedGift()
   {
    GameObject Gift = Instantiate<GameObject>(giftPrefab);
    Gift.transform.position = transform.position;
    Invoke("DropRedGift",secondsBetweenGiftDrops);
   }

    void DropGreenApple()
    {
        
        GameObject greenApple = Instantiate<GameObject>(greenApplePrefab);
        greenApple.transform.position = transform.position;

         if(Basket.score <= 6500)
        {

            float difference = (float)Basket.score/1321;
            secondsBetweenGreenAppleDrops = 10f - difference;
          
        }
        else
        {
        secondsBetweenGreenAppleDrops =4f;
        }
            
        Invoke("DropGreenApple",secondsBetweenGreenAppleDrops);
        
        
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;

        if(Basket.score <= 7000)
        {

            float difference = (float)Basket.score/10000;
            secondsBetweenAppleDrops = 1f - difference;
           
        }
        else
        {
        secondsBetweenAppleDrops = 0.3f;
        }

        Invoke("DropApple", secondsBetweenAppleDrops);
        
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if(pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        } else if (pos.x> leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        }
    }
    void FixedUpdate(){
        if (Random.value < chanceToChangeDirections){
            speed *= -1;
        }
    }
}
