using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plater : bang
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Attack")==1) //마우스 좌클릭 시 실행
        {
            shoot();
        }
    }
    

}
