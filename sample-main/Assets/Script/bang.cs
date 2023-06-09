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
    public void shoot(){
        if (ss >= 0.2)
            {
            GameObject obj=Instantiate(bb, Firepos.transform.position, Firepos.transform.rotation) ;
            Destroy(obj,3f);
                ss = 0;
            }
            ss += Time.deltaTime;
    }
}
