using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inven : MonoBehaviour
{
    public GameObject[] item;
    public bool[] count;
    // Start is called before the first frame update
    void Start()
    {
        count[0]=false;
        count[1]=false;
        count[2]=false;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<item.Length;i++){
            if(count[i]){
                item[i].SetActive(true);
            }else if(!count[i]){
                item[i].SetActive(false);
            }
        }
    }
}
