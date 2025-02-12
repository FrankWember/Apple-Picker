using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenApple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;
    // Start is called before the first frame update
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
        if(collideWith.tag=="Apple"){
        Destroy(collideWith);
        }
    }
}
