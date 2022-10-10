using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotation;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotation);
    }
}
