using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wp : MonoBehaviour
{
    public GameObject[] wp;
    private int wpNum=0; 
    private bool wparmed=false;
    private float cooltime=0f;
    private bool coolTimeStart=false;     
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject w in wp){   //시작시 무기 전부 비활성화
            w.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        coolTime();
        if(Input.GetAxisRaw("Armed")==1&&cooltime==0.0f) Armed();        //input manager에서 키 확인 및 변경 가능 현재 e
        if(Input.GetAxisRaw("wpChange")==1&&cooltime==0.0f) WPChange();  //input manager에서 키 확인 및 변경 가능 현재 z
    }
    void Armed(){  //무기 장착&해제
        coolTimeStart=true;         //무기교체 쿨타임 시작
        if(!wparmed){               //장착한 무기 없을 시
        wp[wpNum].SetActive(true);  //현재 무기 활성화
        wparmed=true;               //장비상태 갱신
        }else if(wparmed){          //장착한 무기 있을 시
        wp[wpNum].SetActive(false); //현재 무기 활성화
        wparmed=false;              //장비상태 갱신
        }
    }
    void WPChange(){  //무기 바꾸기
        coolTimeStart=true;          //무기교체 쿨타임 시작
        wp[wpNum].SetActive(false);  //현재 무기 비활성화
        wpNum++;                     //다음 무기로 바꿈 불러올 준비
        if(wpNum>wp.Length) wpNum=0; //무기 번호가 최대치보다 클 시 처음으로 돌아옴
        wp[wpNum].SetActive(true);   //바뀐 무기 활성화
    }
    public void coolTime(){          //쿨타임 계산
    if(coolTimeStart){
        cooltime+=Time.deltaTime;
    }
    if(cooltime>=1.0f){
        coolTimeStart=false;
        cooltime=0.0f;
    }
}
}
