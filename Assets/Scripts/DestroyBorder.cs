using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBorder : MonoBehaviour
{
    [SerializeField] string tag_player1;
    [SerializeField] string tag_player2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player1"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("player2"))
        {
            Destroy(gameObject);
        }
    }
}
