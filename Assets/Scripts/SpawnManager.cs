using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] dogPrefabs; 

    // Update is called once per frame
    void Update()
    {
        float x =Random.Range(10,-10);
        int index = Random.Range(0,dogPrefabs.Length);
        

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (dogPrefabs[index] != null)
            {
                var dog = Instantiate(dogPrefabs[index], new Vector3(x, 0, 20), Quaternion.Euler(0, 180, 0));
                Destroy(dog, 10f);
            }
            else
            {
                Debug.LogWarning("Dog prefab at index " + index + " is not assigned.");
            }
        }
    }
}
