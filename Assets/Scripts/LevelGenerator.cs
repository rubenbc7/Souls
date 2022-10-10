using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] int[] roomPositionVariation;
    List<int> listRoomPositionVariation;

    [SerializeField] GameObject[] room;
    [SerializeField] GameObject[] spawnPoint;

    int random;

    void Start()
    {
        listRoomPositionVariation = new List<int>(new int[roomPositionVariation.Length]);

        for (int i = 0; i < roomPositionVariation.Length; i ++)
        {
            random = UnityEngine.Random.Range(1, (roomPositionVariation.Length) + 1);

            while (listRoomPositionVariation.Contains(random))
            {
                random = UnityEngine.Random.Range(1, (roomPositionVariation.Length) + 1);
            }

            listRoomPositionVariation[i] = random;

            //Aqui el listRoomPosition contiene un valor random entre 1 a n, dependiendo del numero sale un case y se crea el cuarto dependiento de la iteracion
            switch (listRoomPositionVariation[i])
            {
                //Para rotar objeto: Instantiate(room[i], new Vector3(-5, 0, 5), Quaternion.Euler(new Vector3(0, 45, 0)));
                case 1:
                    Instantiate(room[i], new Vector3(spawnPoint[0].transform.position.x, spawnPoint[0].transform.position.y, spawnPoint[0].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 2:
                    Instantiate(room[i], new Vector3(spawnPoint[1].transform.position.x, spawnPoint[1].transform.position.y, spawnPoint[1].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 3:
                    Instantiate(room[i], new Vector3(spawnPoint[2].transform.position.x, spawnPoint[2].transform.position.y, spawnPoint[2].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 4:
                    Instantiate(room[i], new Vector3(spawnPoint[3].transform.position.x, spawnPoint[3].transform.position.y, spawnPoint[3].transform.position.z), Quaternion.Euler(new Vector3(0, -0, 0)));
                    break;
                case 5:
                    Instantiate(room[i], new Vector3(spawnPoint[4].transform.position.x, spawnPoint[4].transform.position.y, spawnPoint[4].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 6:
                    Instantiate(room[i], new Vector3(spawnPoint[5].transform.position.x, spawnPoint[5].transform.position.y, spawnPoint[5].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 7:
                    Instantiate(room[i], new Vector3(spawnPoint[6].transform.position.x, spawnPoint[6].transform.position.y, spawnPoint[6].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 8:
                    Instantiate(room[i], new Vector3(spawnPoint[7].transform.position.x, spawnPoint[7].transform.position.y, spawnPoint[7].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 9:
                    Instantiate(room[i], new Vector3(spawnPoint[8].transform.position.x, spawnPoint[8].transform.position.y, spawnPoint[8].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
            }
            
        }
    }
}
