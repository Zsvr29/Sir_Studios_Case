using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject baslangic;
    public GameObject bitis;
    void Start()
    {
        string key = PlayerPrefs.GetString("key");
        Debug.Log(key);
        if (key == "begin")
        {
            baslangic.SetActive(false);
        }
        else
        
            baslangic.SetActive(true);
            PlayerPrefs.DeleteAll();
        
        
    }

   public void Basla()
    {
        baslangic.SetActive(false);
       

}public void Restart()
    {
        baslangic.SetActive(false);
        bitis.SetActive(false);
        string baslad�m� = "notbegin";
        baslad�m� = "begin";
        PlayerPrefs.SetString("key", baslad�m�);
        SceneManager.LoadScene("Game");
        
       

}
}

