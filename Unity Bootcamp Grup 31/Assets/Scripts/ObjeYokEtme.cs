using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeYokEtme : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(gameObject);
        }
    }
}
