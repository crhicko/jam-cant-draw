using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _spawn;
    [SerializeField]
    private Vector2 _spawnZoneDimensions;
    private Vector2 _spawnDimensions;


    // Start is called before the first frame update
    void Start()
    {
        // _spawnDimensions = _spawn.GetComponent<Collider2D>().bounds.center
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Spawn() {
        return Instantiate(_spawn, gameObject.transform.position, Quaternion.identity);
    }
}
