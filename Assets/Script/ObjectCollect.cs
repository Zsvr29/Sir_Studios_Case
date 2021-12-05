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
        if (other.gameObject.tag == "top")//oyuncumuz eðer objelerimize temas ederse
        {
            Destroy(other.gameObject);
            skor += 10;
            Spawn.Ýnstance.spawnCount--; //sayacý azaltalým ki objeler oluþsun
            Spawn.Ýnstance.Collectible.Remove(other.gameObject);//toplanan objeyi listeden silelim.
          
            StartCoroutine(Spawn.Ýnstance.WaitSpawn());//yeni obje oluþtur
           
            text.text = skor.ToString();
            if (skor == 100)//oyunun bittiði durum.
            {
                restartmenu.SetActive(true);
                text2.text = skor.ToString();

            }
        }


    }
}
