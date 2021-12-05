using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    Vector3 aradkýMesafe;

    void Start()
    {
        aradkýMesafe = transform.position - Player.transform.position;//kamera ve playerimiz arasýndaki mesafeyi hesapladýk
    }

    
    void Update()
    {
        transform.position = Player.transform.position + aradkýMesafe;  //kameramýzýn objeyi takip etmesini saðladýk
    }
}
