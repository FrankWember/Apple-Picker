using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;
    [SerializeField] private bool isTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < bottomY){
            Destroy(this.gameObject);

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            if (!isTutorial)
                apScript.AppleDestroyed();
        }
    }
   
}
