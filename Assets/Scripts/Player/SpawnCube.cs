using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject Cube;

    [Header("Spawn Brick")]
    [Range(1, 5)]
    public float DistanceSpawn = 3;

    private Vector2 _mosePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mosePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(transform.position, _mosePosition) < DistanceSpawn)
            {
                Instantiate(Cube, new Vector3(_mosePosition.x, _mosePosition.y, 0), Quaternion.identity);
            }
        }
    }
}
