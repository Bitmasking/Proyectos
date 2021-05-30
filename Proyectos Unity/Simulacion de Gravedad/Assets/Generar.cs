using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generar : MonoBehaviour
{
    public int gen = 10;
    public GameObject prefab;
    List<GameObject> prefabs;
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("RESET");
            prefabs = new List<GameObject>();
            gen = Random.Range(10, 20);
            print(gen);
            for (int i = 0; i < gen; i++)
            {
                int x = Random.Range(-1500, 1500);
                int y = Random.Range(-1500, 1500);
                prefabs.Add(Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity));
                int uwu = Random.Range(200, 500);
                prefabs[i].transform.localScale = new Vector3(uwu, uwu, uwu);
                prefabs[i].GetComponent<Rigidbody>().mass = uwu * 500;
                float r = Random.Range(10f, 255f);
                float g = Random.Range(10f, 255f);
                float b = Random.Range(10f, 255f);
                Color col = new Vector4(r / 255f, g / 255f, b / 255f, 0);
                prefabs[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", col);
            }
        }

    }

}
