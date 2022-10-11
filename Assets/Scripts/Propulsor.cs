using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsor : MonoBehaviour
{

<<<<<<< Updated upstream
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
=======
    GameObject player1;
    GameObject player2;
>>>>>>> Stashed changes
    [SerializeField] float pushForce = 100.0f;
    [SerializeField] string tag_player1;
    [SerializeField] string tag_player2;
    bool attack;
    
    // Start is called before the first frame update
<<<<<<< Updated upstream
    void Start()
    {
        
    }

    void Update()
    {
        
    }

=======
    void Awake()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }
>>>>>>> Stashed changes
    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb_player1 = player1.GetComponent<Rigidbody>();
        Rigidbody rb_player2 = player2.GetComponent<Rigidbody>();
        if (other.CompareTag("player1"))
        {
            rb_player1.AddForce(Vector3.up * pushForce, ForceMode.Impulse);
        }
        if (other.CompareTag("player2"))
        {
            rb_player2.AddForce(Vector3.up * pushForce, ForceMode.Impulse);
        }
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
