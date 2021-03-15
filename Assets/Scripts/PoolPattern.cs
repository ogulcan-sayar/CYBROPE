using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPattern : MonoBehaviour
{
    GameObject prefab;
    GameObject[] prefabArr;
    int index;

    public List<GameObject> Pool = new List<GameObject>();
    public void OlusturPoolPattern(GameObject prefab,int miktar)
    {

        this.prefab = prefab;
        HavuzuDoldur(miktar);
    }

    public void OlusturPoolPattern(GameObject[] prefabArr, int miktar)
    {
        for (int i = 0; i < miktar; i++)
        {
            GameObject obj = GameObject.Instantiate(prefabArr[Random.Range(0, prefabArr.Length)]);
            prefab = obj;

            HavuzaObjeEkle(obj);
        }
        Debug.Log(prefab.name);
    }

    void HavuzuDoldur(int miktar)
    {
        for(int i = 0; i < miktar; i++)
        {
          
            GameObject obj = GameObject.Instantiate(prefab);
            HavuzaObjeEkle(obj);
        }
    }


    public GameObject HavuzdanCek(Vector2 position, Quaternion rotation)
    {
        if (Pool.Count > 0)
        {
            GameObject anyObject = Pool[0];
            Pool.RemoveAt(0);
            anyObject.transform.position = position;
            anyObject.transform.rotation = rotation;
            anyObject.SetActive(true);
            return anyObject;
        }
        else
        {
            Debug.Log("olusturuldu");
            return GameObject.Instantiate(prefab,position,rotation);
        }
    }

    

    public void HavuzaObjeEkle(GameObject obj)
    {
        Debug.Log("Eklendi");
        obj.SetActive(false);
        Pool.Add(obj);
    }

    public void HavuzaGeriEkle(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void ShowCount()
    {

        Debug.Log(Pool.Count);
    }

}
