using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField] private GameObject Enemy_Prefub;
    private Transform[] Spown_Positions;
    
    void Start()
    {
        Spown_Positions = GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
        StartCoroutine(EnemyMaker(Spown_Positions));       
    }

    IEnumerator EnemyMaker(Transform[]positions) 
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(Enemy_Prefub,positions[i].position,Quaternion.identity);
            yield return new WaitForSeconds(2);
        }      
    }
}
