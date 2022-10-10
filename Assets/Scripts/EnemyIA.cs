using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    //Patrolling
    [Header("Patrol Settings")]
    [SerializeField] Transform[] movementPoints;
    [SerializeField] float speed;
    int changePoint = 0;

    //Attack
    [Header("Attack Settings")]
    [SerializeField] GameObject[] targetPlayer1;
    [SerializeField] GameObject[] targetPlayer2;
    [SerializeField] float attackRadius;
    [SerializeField] float attackSpeed;
    [SerializeField] float pushForce = 1000.0f;
    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstructionMask;
    float angle = 360.0f;
    bool attack;
    float minDist = 0.9f;

    void Start()
    {
        targetPlayer1 = GameObject.FindGameObjectsWithTag("player1");
        targetPlayer2 = GameObject.FindGameObjectsWithTag("player2");
        StartCoroutine(AttackRoutine());
    }

    void Update()
    {
        if (attack == false)
        {
            if (changePoint != -1)
            {
                transform.position = Vector3.MoveTowards(transform.position, movementPoints[changePoint].position, Time.deltaTime * speed);
                if (transform.position == movementPoints[changePoint].position)
                {
                    changePoint++;
                }
            }
            if (changePoint == movementPoints.Length)
            {
                changePoint = 0;
            }
        }
        else
        {
            Collider[] rangeChecks = Physics.OverlapSphere(transform.position, attackRadius, targetMask);
            if (rangeChecks.Length != 0)
            {
                Transform target = rangeChecks[0].transform;

                transform.LookAt(target.position);
 
                if (Vector3.Distance(transform.position, target.position) >= minDist)
                {
                    transform.position += transform.forward * attackSpeed * Time.deltaTime;
                }
            }
        }

    }

    private IEnumerator AttackRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, attackRadius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    attack = true;
                }
                else
                    attack = false;
            }
            else
                attack = false;
        }
        else if (attack)
            attack = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, attackRadius, targetMask);
        if (rangeChecks.Length != 0)
        {
            Rigidbody target = rangeChecks[0].GetComponent<Rigidbody>();
            if(other.CompareTag("player1"))
            {
                int random = UnityEngine.Random.Range(1, 8);
                //Direcciones de empuje
                Vector3 directionPush1 = new Vector3(1, 0, 1);
                Vector3 directionPush2 = new Vector3(-1, 0, 1);
                Vector3 directionPush3 = new Vector3(-1, 0, -1);
                Vector3 directionPush4 = new Vector3(1, 0, -1);

                switch(random)
                {
                    case 1:
                        target.AddForce(Vector3.right * pushForce, ForceMode.Impulse);
                        break;
                    case 2:
                        target.AddForce(Vector3.left * pushForce, ForceMode.Impulse);
                        break;
                    case 3:
                        target.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
                        break;
                    case 4:
                        target.AddForce(Vector3.back * pushForce, ForceMode.Impulse);
                        break;
                    case 5:
                        target.AddForce(directionPush1 * pushForce, ForceMode.Impulse);
                        break;
                    case 6:
                        target.AddForce(directionPush2 * pushForce, ForceMode.Impulse);
                        break;
                    case 7:
                        target.AddForce(directionPush3 * pushForce, ForceMode.Impulse);
                        break;
                    case 8:
                        target.AddForce(directionPush4 * pushForce, ForceMode.Impulse);
                        break;
                }
                attack = false;
            }

            if(other.CompareTag("player2"))
            {
                int random = UnityEngine.Random.Range(1, 8);
                //Direcciones de empuje
                Vector3 directionPush1 = new Vector3(1, 0, 1);
                Vector3 directionPush2 = new Vector3(-1, 0, 1);
                Vector3 directionPush3 = new Vector3(-1, 0, -1);
                Vector3 directionPush4 = new Vector3(1, 0, -1);

                switch(random)
                {
                    case 1:
                        target.AddForce(Vector3.right * pushForce, ForceMode.Impulse);
                        break;
                    case 2:
                        target.AddForce(Vector3.left * pushForce, ForceMode.Impulse);
                        break;
                    case 3:
                        target.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
                        break;
                    case 4:
                        target.AddForce(Vector3.back * pushForce, ForceMode.Impulse);
                        break;
                    case 5:
                        target.AddForce(directionPush1 * pushForce, ForceMode.Impulse);
                        break;
                    case 6:
                        target.AddForce(directionPush2 * pushForce, ForceMode.Impulse);
                        break;
                    case 7:
                        target.AddForce(directionPush3 * pushForce, ForceMode.Impulse);
                        break;
                    case 8:
                        target.AddForce(directionPush4 * pushForce, ForceMode.Impulse);
                        break;
                }
                attack = false;
            }
        }
    }
}