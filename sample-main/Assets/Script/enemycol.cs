using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycol : MonoBehaviour
{
    public int hp=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {  //총알 맞았을 때 대미지 입음
    if(other.gameObject.tag=="fire"){
        bb b=other.gameObject.GetComponent<bb>();
        Debug.Log(b.damage);
        hp-=b.damage;
    }
    }
}
