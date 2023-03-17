using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy Enemy_Prefub;

    private Transform[] Spown_Positions;

    private float waitSecond = 2;

    private void Start()
    {
        Spown_Positions = GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
        StartCoroutine(EnemyMaker(Spown_Positions));
    }

    private IEnumerator EnemyMaker(Transform[] positions)
    {
        WaitForSeconds waitTime = new WaitForSeconds(waitSecond);

        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(Enemy_Prefub, positions[i].position, Quaternion.identity);
            yield return waitTime;
        }
    }
}
