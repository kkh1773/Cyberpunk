using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
   

    public Vector3 pos;
    public GameObject zone;
    private GameObject pl;
    public bool find=false;
    public float speed=0.1f;
    public int hp=10;
    void Start()
    {
        pos.y=this.transform.position.y;  //y축 고정
        StartCoroutine(Roaming());
    }

     IEnumerator Roaming()
    {
        

        toward();
       
       while (true) 
        {
           
            var dir = (pos - this.transform.position).normalized; // pos 포지션 - 몬스터포지션 normalized 한후 
            this.transform.LookAt(pos); // 몬스터가 이동할때 이동하는곳 바라보게하기위해 
            this.transform.position += dir * speed * Time.deltaTime; // 현재포지션에 normalize * 설정한 speed * Time.deltaTime 더해주기 

            float distance = Vector3.Distance(transform.position, pos); // 몬스터와 목적지 사이 거리 구하기 
            if (distance <=0.1f) // 목적지와의 거리가 0.1 이하라면 목적지 다시 정함
            {
                toward();
            }
            
            yield return null;  
        }

    }
    void toward(){
        do {
        pos.x = Random.Range(-3f, 3f); //목적지 x 값은 -3~3 사이 랜덤값
        pos.z = Random.Range(-3f, 3f); // 목적지 z 값은 -3~3 사이 랜덤값
        }while (Vector3.Distance(zone.transform.position,pos)>=5);
    }
    private void OnCollisionEnter(Collision other) {  //총알 맞았을 때 대미지 입음
    if(other.gameObject.tag=="fire"){
        bb b=other.gameObject.GetComponent<bb>();
        Debug.Log(b.damage);
        hp-=b.damage;
    }
    }
    
}
