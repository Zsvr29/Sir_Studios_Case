using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPrefab;
   public List<GameObject> Collectible = new List<GameObject>(); //objelerimizi kontrol etmek için liste oluþturdum.
    public int spawnCount = 0;
    public static Spawn Ýnstance;
        

    private void Start()
    {
        SpawnFunc();
        Ýnstance = this;
    }

  
  public  void SpawnFunc()
    {
        for (int i = spawnCount; i < 5; i++) //en fazla 5 obje istenildiði için for döngüsünü 5 kere dönderiyoruz.
        {
            int xpos = Random.Range(-4, 4);
            int zpos = Random.Range(-9, 9);
            GameObject SpawnObject = Instantiate(spawnPrefab, new Vector3(xpos, 0.6f, zpos), Quaternion.identity);//objeleri oluþturalým.
            for (int j = 0; j < Collectible.Count; j++)
            {
                if (Collectible[j].transform.position == SpawnObject.transform.position) //eðer oluþturduðumuz objeler üst üste olursa sýkýntý olacaðýndan spawn ettiðimiz objeyi listedeki diðer objelerle karþýlaþtýrdýk.

                {
                    Destroy(SpawnObject);
                    SpawnFunc();
                }
            }
            SpawnObject.transform.parent = this.transform;
            Collectible.Add(SpawnObject);
            spawnCount++;
            if (Collectible.Count > 5)//haddinden fazla obje varsa kontrol etmek için.
            {
                for (int k = 4; k < Collectible.Count; k++)
                {
                    
                    Destroy(Collectible[k]);
                    Collectible.Remove(Collectible[k]);

                }
            }
            
        }
        
    } 

    public IEnumerator WaitSpawn() //topladýðýmýz objelerin yerine tekrar obje oluþturma.
    {
        int rand = Random.Range(1, 4);

        yield return new WaitForSeconds(rand);
        if (spawnCount<4)
        {
            SpawnFunc();
        }
        

    }


}