using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    Vector3 aradk�Mesafe;

    void Start()
    {
        aradk�Mesafe = transform.position - Player.transform.position;//kamera ve playerimiz aras�ndaki mesafeyi hesaplad�k
    }

    
    void Update()
    {
        transform.position = Player.transform.position + aradk�Mesafe;  //kameram�z�n objeyi takip etmesini sa�lad�k
    }
}
