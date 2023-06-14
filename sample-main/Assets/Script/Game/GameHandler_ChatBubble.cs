using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler_ChatBubble : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform[] npcTransformArray;

    private void Start()
    {
        ChatBubble3D.Create(playerTransform, new Vector3(3, 3), ChatBubble3D.IconType.Neutral, "Here is some text!");
    }

    // private string GetRandomMessage()
}
