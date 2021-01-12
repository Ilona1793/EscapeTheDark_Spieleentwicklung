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

    // Start is called before the first frame update
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
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        var temp = Instantiate(BackgroundObjectPrefab, pos, BackgroundObjectPrefab.transform.rotation);

        int randomIndex = Random.Range(0, materials.Length);

        MeshRenderer meshRenderer = temp.GetComponent<MeshRenderer>();
        meshRenderer.material = materials[randomIndex];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 5f);
        Gizmos.DrawCube(center, size);
    }
}
