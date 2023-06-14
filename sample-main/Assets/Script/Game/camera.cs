using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField]
    private GameObject pl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical")!=0||Input.GetAxisRaw("Horizontal")!=0){ //방향키 인식이 있을 때
            if(!(Input.GetAxisRaw("Vertical")==-1)){                            //뒤 방향이 아니면  코루틴 실행
         StartCoroutine(RotateTowardsAngle(this.transform,pl.transform));
        
        }
            
        }
        this.transform.position = pl.transform.position; //카메라 위치 조정
    }
    /*void rotating(){  //바꾼건데 혹시 몰라서 놔둠
        if(!(Input.GetAxisRaw("Vertical")==-1)){
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, pl.transform.rotation,360);
        
        }
    }*/
    public IEnumerator RotateTowardsAngle(Transform myTransform, Transform Transform)  //카메라 화면을 플레이어의 방향에 따라 회전시키는 코루틴
{
    Quaternion startRotation = myTransform.rotation;
    Quaternion targetRotation = Quaternion.Euler(myTransform.eulerAngles.x, Transform.eulerAngles.y, myTransform.eulerAngles.z);

    float elapsedTime = 0f;
    float duration=0.1f;
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        myTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
        yield return null;
    }
    
    // 보간이 완료된 후 최종 목표 회전을 설정해줍니다.
    myTransform.rotation = targetRotation;
}
}
