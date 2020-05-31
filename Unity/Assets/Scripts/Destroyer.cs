using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.z<player.transform.position.z -11)
        {
            Destroy(gameObject);
        }
    }
}
