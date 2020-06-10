using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _spawn;
    [SerializeField]
    private Vector2 _spawnZoneDimensions;
    private Vector2 _spawnDimensions;

    public float _spawnTime;

    public GameObject _spawnInstantiation;


    // Start is called before the first frame update
    void Start()
    {
        // _spawnDimensions = _spawn.GetComponent<Collider2D>().bounds.center
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn() {
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer() {
        yield return new WaitForSeconds(_spawnTime);
        _spawnInstantiation = Instantiate(_spawn, gameObject.transform.position, Quaternion.identity);
        GameManager.Instance.AddSpawn(_spawnInstantiation);
    }
}
