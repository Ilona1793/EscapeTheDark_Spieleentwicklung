using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject BackgroundObjectPrefab;

    public Vector3 center;
    public Vector3 size;

    public int spawnAmount = 1000;
    public Material[] materials;

    public int spawnCounter = 0;

    void Start()
    {
        center = transform.position;

        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnBackgroundObjects();
           
        }
    }


    public void SpawnBackgroundObjects()
    {
        Vector3 pos = center + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2), UnityEngine.Random.Range(-size.y / 2, size.y / 2), UnityEngine.Random.Range(-size.z / 2, size.z / 2));

        if (!checkForObjectsBelow(pos))
        {
            var temp = Instantiate(BackgroundObjectPrefab, pos, BackgroundObjectPrefab.transform.rotation);

            int randomIndex = UnityEngine.Random.Range(0, materials.Length);

            MeshRenderer meshRenderer = temp.GetComponent<MeshRenderer>();
            meshRenderer.material = materials[randomIndex];
            spawnCounter++;
        }
    }

    private bool checkForObjectsBelow(Vector3 pos)
    {
        return Physics.Raycast(pos, Vector3.down, 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 5f);
        Gizmos.DrawCube(center, size);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DestroyObject"))
        {
            Destroy(this.gameObject);
        }
    }
 }


