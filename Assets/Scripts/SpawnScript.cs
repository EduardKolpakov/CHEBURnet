using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnScript : MonoBehaviour
{
    public GameObject OrangePrefab;
    public List<Transform> spawnPoints;
    public float initialSpawnTime = 2f;
    private float currentSpawnTime;
    private float orangeSpeed = 2f;
    private bool isSpawning = true;

    void Start()
    {
        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("����� ��������� �� ���������!");
            return;
        }

        currentSpawnTime = initialSpawnTime;
        StartCoroutine(SpawnOranges());
    }

    IEnumerator SpawnOranges()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(currentSpawnTime);
            SpawnOrange();
        }
    }

    void SpawnOrange()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[spawnPointIndex];
        GameObject orange = Instantiate(OrangePrefab, spawnPoint.position, spawnPoint.rotation);
        //    OrangeMovement orangeMovement = orange.GetComponent<OrangeMovement>();
        //    if (orangeMovement != null)
        //    {
        //        orangeMovement.SetSpeed(orangeSpeed);
        //    }
    }
    public void SetSpawnRate(float newSpawnTime)
    {
        if (newSpawnTime > 0)
        {
            currentSpawnTime = newSpawnTime;
        }
        else
        {
            Debug.LogWarning("������������ �������� �������� ������!");
        }
    }
    public void SetOrangeSpeed(float newSpeed)
    {
        orangeSpeed = newSpeed;
    }
    public void StopSpawning()
    {
        isSpawning = false;
    }

    public void ResumeSpawning()
    {
        isSpawning = true;
        StartCoroutine(SpawnOranges());
    }
    public float GetSpawnRate()
    {
        return currentSpawnTime;
    }
}
