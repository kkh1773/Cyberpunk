using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonView : MonoBehaviour
{
    public bool view=true;
    public GameObject thirdCamera;
    public GameObject firstCamera;
    private float cooltime=0f;
    private bool coolTimeStart=false;

//3인칭-1인칭 변환용 필요업으면 안씀

    void Start()
    {
        
    }

    void Update()
    {
        viewChange();
        coolTime();
    }
    public void viewChange(){
        if(Input.GetAxisRaw("viewChange")==1&&view&&cooltime==0){
            coolTimeStart=true;
            StartCoroutine(RotateTowardsAngle(this.transform,firstCamera.transform));
            view=false;
        }else if(Input.GetAxisRaw("viewChange")==1&&!view&&cooltime==0){
            coolTimeStart=true;
            StartCoroutine(RotateTowardsAngle(this.transform,thirdCamera.transform));
            view=true;
        }
        
    }
        public IEnumerator RotateTowardsAngle(Transform myTransform, Transform Transform)
{
    Quaternion startRotation = myTransform.rotation;
    Quaternion targetRotation = Quaternion.Euler(Transform.eulerAngles.x, myTransform.eulerAngles.y, myTransform.eulerAngles.z);

    float elapsedTime = 0f;
    float duration=0.4f;
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        myTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
        this.transform.position=Vector3.MoveTowards(myTransform.position,Transform.position,0.05f);
        yield return null;
    }
    
    // 보간이 완료된 후 최종 목표 회전을 설정해줍니다.
    myTransform.rotation = targetRotation;
}

public void coolTime(){
    if(coolTimeStart){
        cooltime+=Time.deltaTime;
    }
    if(cooltime>=2.0f){
        coolTimeStart=false;
        cooltime=0.0f;
    }
}
}
