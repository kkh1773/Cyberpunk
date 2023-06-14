using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bb : MonoBehaviour
{
    Rigidbody brg;
    public int damage=10;
    
    // Start is called before the first frame update
    void Start()
    {
        brg=GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        brg.velocity=transform.forward*30f;  //생성 시 전방으로 지속적으로 이동
    }
    private void OnCollisionEnter(Collision collision)  //물체와 부딫히면 파괴
    {
        Destroy(gameObject);
    }
}
