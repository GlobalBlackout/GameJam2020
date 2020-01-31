using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    private Vector2 target;
    public GameObject Cube;
    public GameObject Player;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 playerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
            Vector2 mousePosition = new Vector2(target.x, target.y);

            if (Vector2.Distance(playerPosition, mousePosition) < 3f)
            {
                Instantiate(Cube, new Vector2(target.x, target.y), Quaternion.identity);
            }

            
        }
    }
}
