using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class day : MonoBehaviour
{
    private float cooltime=0f;
    bool timechage=false;
    private bool daytime=false;
    bool bottn=false;
    public GameObject sun; 
    public TMP_Text timeText; 
    public GameObject camera1; 
    public GameObject camera2; 

    //밤낮을 아예 따로 구현할 경우 고침
    void Start()
    {
        camera2.SetActive(false);
        sun.transform.rotation=Quaternion.Euler(50,0,0);
    }

    void Update()
    {
        timeText.text=Mathf.Round(cooltime).ToString();  //쿨타임 잘 작동하는지 확인용
        if(!timechage){  //쿨타임이 안차면 시간 계산
        coolTime();
        }else if(timechage){
            timeText.text="change";
        }

        if(daytime&&bottn){            //낮일 때 버튼을 눌러서 변경
            camera1.SetActive(false);  //카메라 조작
            camera2.SetActive(true);
        sun.transform.Rotate(new Vector3(-10, 0, 0) * Time.deltaTime);         //광원을 돌려서 해가 진것처럼 연출
        if(sun.transform.eulerAngles.x>320&&sun.transform.eulerAngles.x<330){  //적당히 돌린뒤 고정
            sun.transform.rotation=Quaternion.Euler(-30,0,0);
            timechage=false;
            bottn=false;
            camera2.SetActive(false);
            camera1.SetActive(true);
        }
        }
         if(!daytime){  //밤에 시간이 지나면 낮으로 자동 변경
            camera1.SetActive(false);
            camera2.SetActive(true);
        sun.transform.Rotate(new Vector3(10, 0, 0) * Time.deltaTime);
        if(sun.transform.eulerAngles.x>50&&sun.transform.eulerAngles.x<60){
            sun.transform.rotation=Quaternion.Euler(50,0,0);
            timechage=false;
            camera2.SetActive(false);
            camera1.SetActive(true);
            }
        }
    }

    public void dayChanger(){    //밤으로 바꾸는 버튼
        if(timechage&&daytime){
            bottn=true;
        }
    }

    public void coolTime(){  //쿨타임 계산용
    cooltime+=Time.deltaTime;
    
    if(cooltime>=5.0f){      //5초(시험용) 가 지나면 daytime을 반전시키고 쿨타임 초기화하여 정지
        daytime=!daytime;
        cooltime=0f;
        timechage=true;
    }
}

}
