using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject Cube;

    private Vector2 _mosePosition;
    public AudioClip SteelCraft;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mosePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(transform.position, _mosePosition) < 3f)
            {
                Instantiate(Cube, new Vector3(_mosePosition.x, _mosePosition.y, -5), Quaternion.identity);
                SoundManager.PlaySteelCraft(SteelCraft);
            }
        }
    }
}
