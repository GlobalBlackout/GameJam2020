using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public GameObject PortalToTP;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float unitToAddPlayer = Player.transform.position.x > 0 ? 2 : -2;
            Player.transform.position = new Vector3(PortalToTP.transform.position.x + unitToAddPlayer, Player.transform.position.y, 0);
        }
    }
}
