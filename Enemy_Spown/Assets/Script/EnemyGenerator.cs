using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _enemy_Prefub;

    private Transform[] _spown_Positions;

    private float _waitSecond = 2;

    private void Start()
    {
        _spown_Positions = GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
        StartCoroutine(EnemyMaker(_spown_Positions));
    }

    private IEnumerator EnemyMaker(Transform[] positions)
    {
        WaitForSeconds waitTime = new WaitForSeconds(_waitSecond);

        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(_enemy_Prefub, positions[i].position, Quaternion.identity);
            yield return waitTime;
        }
    }
}
