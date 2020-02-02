using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject Cube;
    public SpriteRenderer PlayerRange;

    [Header("Spawn Brick")]
    [Range(1, 5)]
    public float DistanceSpawn = 3;
    [Range(0, 5)]
    public float DelaySpawn = 3;

    private Vector2 _mosePosition;
    private float _timeLeft;
    private bool _brickInStorage = true;

    private void Start()
    {
        _timeLeft = DelaySpawn;
        PlayerRange.transform.localScale = new Vector3(DistanceSpawn * 2, DistanceSpawn * 2, 0);
    }

    void Update()
    {
        if (!_brickInStorage)
        {
            TimerForPlaceBrick();
            PlayerRange.enabled = false;
        }

        if (_brickInStorage)
        {
            SpawnBrick();
            PlayerRange.enabled = true;
        }
    }

    private void SpawnBrick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_brickInStorage)
            {
                _mosePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(transform.position, _mosePosition) < DistanceSpawn)
                {
                    FindObjectOfType<SoundManager>().PlaySteelCraft();
                    Instantiate(Cube, new Vector3(_mosePosition.x, _mosePosition.y, 0), Quaternion.identity);
                    _brickInStorage = false;
                }
            }
        }
    }

    private void TimerForPlaceBrick()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft < 0)
        {
            _brickInStorage = true;
            _timeLeft = DelaySpawn;
        }
    }
}
