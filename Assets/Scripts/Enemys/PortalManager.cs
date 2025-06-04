using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static PortalManager instance;
    public GameObject portalPrefab;

    void Awake() => instance = this;

    public void SpawnPortal(Vector3 pos)
    {
        Instantiate(portalPrefab, pos + Vector3.up * 1f, Quaternion.identity);
    }
}
