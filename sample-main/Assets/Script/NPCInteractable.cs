using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public GameObject obj;

    public void Interact()
    {
        // Debug.Log("Interact!");

        obj = GameObject.Find("ChatBubble");
        obj.SetActive(true);
    }
}
