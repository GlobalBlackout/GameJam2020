using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject PortalToTP;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float unitToAddPlayer = _player.transform.position.x > 0 ? 2 : -2;
            _player.transform.position = new Vector3(PortalToTP.transform.position.x + unitToAddPlayer, _player.transform.position.y, 0);
        }
        else if (collision.gameObject.tag != "Bullet")
        {
            if (collision.gameObject.tag == "Brick")
                    GameManager.UpdateBrickStatus();

            Destroy(collision.gameObject);
        }
    }
}
