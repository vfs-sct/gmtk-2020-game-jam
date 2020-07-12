using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField]
    private float aimRange = 5f;
    [SerializeField]
    private LayerMask enemyLayer = default;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.right*aimRange);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.right, out hit,aimRange, enemyLayer))
        {
            if (hit.collider != null)
            {
                lineRenderer.SetPosition(1, hit.point);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.right*aimRange + transform.position);
        }
    }
}
