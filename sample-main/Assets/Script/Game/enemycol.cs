using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycol : bang
{
    public Vector3 pos;
    public GameObject zone;
    public GameObject enemy;
    private bool back=false;
    private bool stop=false;
     public float speed=0.1f;
     private float delay=2f;
    // Start is called before the first frame update
    void Start()
    {
        enemy.gameObject.GetComponent<Animation>().Play("walk");
        pos.y=enemy.transform.position.y;  //y축 고정
        StartCoroutine("Roaming");
    }

    // Update is called once per frame
    void Update()
    {
        if(back){
            transform.position=Vector3.MoveTowards(enemy.transform.position,zone.transform.position,speed * Time.deltaTime);
            if( Vector3.Distance(enemy.transform.position, zone.transform.position)<=0.1f){
                enemy.GetComponent<Animation>().Play("walk");
                StartCoroutine("Roaming");
                back=false;
            }
        }
    }
     IEnumerator Roaming()
    {
        

        toward();
       
       while (true) 
        {
           going();
            

            float distance = Vector3.Distance(enemy.transform.position, pos); // 몬스터와 목적지 사이 거리 구하기 
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
    void going(){
        
        var dir = (pos - enemy.transform.position).normalized; // pos 포지션 - 몬스터포지션 normalized 한후 
            enemy.transform.LookAt(pos); // 몬스터가 이동할때 이동하는곳 바라보게하기위해 
            enemy.transform.position += dir * speed * Time.deltaTime; // 현재포지션에 normalize * 설정한 speed * Time.deltaTime 더해주기 
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            StopCoroutine("Roaming");
            GameObject a=other.gameObject;
            StartCoroutine(aproach(a));
        }
    }
    

    IEnumerator aproach(GameObject other){
        enemy.gameObject.GetComponent<Animation>().Play("run");
        while(true){
            
        pos.x=other.transform.position.x;
        pos.z=other.transform.position.z;
            float dis= Vector3.Distance(enemy.transform.position, other.transform.position);
            if(!back&&!stop){
                going();
                if(dis<5){
                    stop=true;
                }
            }else if(stop){
                enemy.transform.LookAt(pos);
                if(delay>=3){
                enemy.gameObject.GetComponent<Animation>().Play("attack");
                shoot(1);
                }else if(delay>=5) delay=0;
                delay+=Time.deltaTime;
                //Debug.Log(delay);
                if(dis>8f){
                    stop=false;
                }
            }
            
            float distance = Vector3.Distance(enemy.transform.position, zone.transform.position);
            if(distance>=10){
                back=true;
                StopCoroutine(aproach(other));
            }
            
        yield return new WaitForEndOfFrame();
        }
    }
    

    
}
