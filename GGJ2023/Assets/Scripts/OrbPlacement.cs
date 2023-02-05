using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPlacement : MonoBehaviour
{
    [SerializeField] GameObject orb;
    [SerializeField] List<GameObject> fog = new List<GameObject>();

    Vector2 orbPos;

    // Start is called before the first frame update
    void Start()
    {
        orbPos = fog[Random.Range(0, fog.Count)].transform.position;
        Instantiate(orb, orbPos, Quaternion.identity);
    }
}
