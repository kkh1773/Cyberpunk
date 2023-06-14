using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class NPCInteractable : MonoBehaviour
{
    public TextAsset txt;
    public GameObject obj;
    public TMP_Text talk;
    StringReader read;
    private void Start() {
        obj.SetActive(false);
        
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)){
            next();
        }
    }

    public void Interact()
    {
        // Debug.Log("Interact!");
        obj.SetActive(true);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            obj.SetActive(true);
            read=new StringReader(txt.text);
            talk.text=read.ReadLine();
            }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player"){
            
            obj.SetActive(false);
            }
    }
    public void next(){
        string s=read.ReadLine();
        if(s!=null){
        talk.text=s;
        }else if(s==null){
            obj.SetActive(false);
            read=new StringReader(txt.text);
            talk.text=read.ReadLine();
        }
    }
}
