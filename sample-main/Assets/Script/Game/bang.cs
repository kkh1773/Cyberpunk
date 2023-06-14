using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bang : MonoBehaviour
{
    public GameObject bb;
    public GameObject Firepos;
    private float ss = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void shoot(float s){
        ss += Time.deltaTime;
        Debug.Log(Time.deltaTime);
        if (ss >= s)
        {
            GameObject obj=Instantiate(bb, Firepos.transform.position, Firepos.transform.rotation) ;
            Destroy(obj,3f);
            ss = 0;
        }
        
    }
}
