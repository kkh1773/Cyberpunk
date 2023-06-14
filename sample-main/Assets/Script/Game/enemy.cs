using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameObject con;
    public int hp=10;
    void Start()
    {
        this.gameObject.GetComponent<Animation>().Play("idle");
    }
    private void Update() {
    if(hp<=0){
        con.SetActive(false);
        this.gameObject.GetComponent<Animation>().Play("death");
    }
    }
     

    
    private void OnCollisionEnter(Collision other) {  //총알 맞았을 때 대미지 입음
    if(other.gameObject.tag=="fire"){
        bb b=other.gameObject.GetComponent<bb>();
        hp-=b.damage;
    }
    }
    
}
