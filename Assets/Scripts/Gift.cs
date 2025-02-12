using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    // Start is called before the first frame update
     [Header("Set in Inspector")]
    public static float bottomY = -20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
       if(transform.position.y < bottomY){
            Destroy(this.gameObject);


        }
        
    }

    void OnCollisionEnter(Collision coll)
    {
    
        GameObject collideWith = coll.gameObject;
        if(collideWith.tag=="Apple" || collideWith.tag == "GreenApple"){
        Destroy(collideWith);
        }

    }
}
