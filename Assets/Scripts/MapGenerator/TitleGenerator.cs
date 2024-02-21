using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGenerator : MonoBehaviour
{
    [SerializeField] private Transform Plaform;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float circleRadius = 0.4f;
    [SerializeField] private bool Here;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }

    private void Awake()
    {
            Transform instance = Instantiate(Plaform, transform.position, Quaternion.identity);
            instance.parent = transform;
    }
}
