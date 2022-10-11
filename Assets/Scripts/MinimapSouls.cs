using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapSouls : MonoBehaviour
{
    public RectTransform soulsInMap;
    //private GameObject soulpoint;
    private RectTransform map2dEnd;
    private GameObject map2dEndpoint;
    private Transform map3dParent;
    private GameObject map3dParentpoint;
    private Transform map3dEnd;
    private GameObject map3dEndpoint;

    private Vector3 normalized, mapped;

    private void Start() {
        //soulpoint = GameObject.Find("SoulMini");
        //soulsInMap = soulpoint.GetComponent<RectTransform>();

        map2dEndpoint = GameObject.Find("MiniSoulEnd");
        map2dEnd = map2dEndpoint.GetComponent<RectTransform>();

        map3dParentpoint = GameObject.Find("Map");
        map3dParent = map3dParentpoint.GetComponent<Transform>();

        map3dEndpoint = GameObject.Find("MapEnd");
        map3dEnd = map3dEndpoint.GetComponent<Transform>();
    }

    private void Update()
    {
        normalized = Divide(
                map3dParent.InverseTransformPoint(this.transform.position),
                map3dEnd.position - map3dParent.position
            );
        normalized.y = normalized.z;
        mapped = Multiply(normalized, map2dEnd.localPosition);
        mapped.z = 0;
        soulsInMap.localPosition = mapped;
    }

    private static Vector3 Divide(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    private static Vector3 Multiply(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
}