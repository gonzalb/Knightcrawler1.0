using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnRate = 1f;   

    private void OnEnable()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke("Spawn");
    }

    private void Spawn()
    {
        int i = (int)Random.Range(0,100) % prefab.Length;
        Instantiate(prefab[i], prefab[i].transform.position, Quaternion.identity);
    }
}