using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine("Transfer");

    }
    IEnumerator Transfer()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.parent.position = new Vector3(0, 0, gameObject.transform.parent.position.z+400);
    }
}
