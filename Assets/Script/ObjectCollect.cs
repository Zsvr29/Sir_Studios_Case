using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollect : MonoBehaviour
{
    public int skor;
    public Text text;
    public Text text2;
    public GameObject restartmenu;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "top")//oyuncumuz e�er objelerimize temas ederse
        {
            Destroy(other.gameObject);
            skor += 10;
            Spawn.�nstance.spawnCount--; //sayac� azaltal�m ki objeler olu�sun
            Spawn.�nstance.Collectible.Remove(other.gameObject);//toplanan objeyi listeden silelim.
          
            StartCoroutine(Spawn.�nstance.WaitSpawn());//yeni obje olu�tur
           
            text.text = skor.ToString();
            if (skor == 100)//oyunun bitti�i durum.
            {
                restartmenu.SetActive(true);
                text2.text = skor.ToString();

            }
        }


    }
}
