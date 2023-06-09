using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public GameObject obj;
    private void Start() {
        obj.SetActive(false);
    }

    public void Interact()
    {
        // Debug.Log("Interact!");
        obj.SetActive(true);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            obj.SetActive(true);
            }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player"){
            obj.SetActive(false);
            }
    }

}
