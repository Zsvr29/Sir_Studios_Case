using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPrefab;
   public List<GameObject> Collectible = new List<GameObject>(); //objelerimizi kontrol etmek i�in liste olu�turdum.
    public int spawnCount = 0;
    public static Spawn �nstance;
        

    private void Start()
    {
        SpawnFunc();
        �nstance = this;
    }

  
  public  void SpawnFunc()
    {
        for (int i = spawnCount; i < 5; i++) //en fazla 5 obje istenildi�i i�in for d�ng�s�n� 5 kere d�nderiyoruz.
        {
            int xpos = Random.Range(-4, 4);
            int zpos = Random.Range(-9, 9);
            GameObject SpawnObject = Instantiate(spawnPrefab, new Vector3(xpos, 0.6f, zpos), Quaternion.identity);//objeleri olu�tural�m.
            for (int j = 0; j < Collectible.Count; j++)
            {
                if (Collectible[j].transform.position == SpawnObject.transform.position) //e�er olu�turdu�umuz objeler �st �ste olursa s�k�nt� olaca��ndan spawn etti�imiz objeyi listedeki di�er objelerle kar��la�t�rd�k.

                {
                    Destroy(SpawnObject);
                    SpawnFunc();
                }
            }
            SpawnObject.transform.parent = this.transform;
            Collectible.Add(SpawnObject);
            spawnCount++;
            if (Collectible.Count > 5)//haddinden fazla obje varsa kontrol etmek i�in.
            {
                for (int k = 4; k < Collectible.Count; k++)
                {
                    
                    Destroy(Collectible[k]);
                    Collectible.Remove(Collectible[k]);

                }
            }
            
        }
        
    } 

    public IEnumerator WaitSpawn() //toplad���m�z objelerin yerine tekrar obje olu�turma.
    {
        int rand = Random.Range(1, 4);

        yield return new WaitForSeconds(rand);
        if (spawnCount<4)
        {
            SpawnFunc();
        }
        

    }


}