using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
public class IntroUi : MonoBehaviour
{
    public GameObject[] panels;
    public TextAsset[] txt;
    public TMP_Text[] text;
    StringReader read;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject p in panels){
            p.SetActive(false);
        }
        for(int i=0;i<=txt.Length-1;i++){
            read=new StringReader(txt[i].text);
            text[i].text=read.ReadLine();
        }
        panels[3].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void page(int num){
        foreach(GameObject p in panels){
            p.SetActive(false);
        }
        panels[num].SetActive(true);
    }
    public void GameStart(){
        SceneManager.LoadScene("sample1");
    }

    public void Quit(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
