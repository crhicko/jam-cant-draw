using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> _puckList = new List<GameObject>();
    public List<GameObject> _enemyList = new List<GameObject>();
    public List<GameObject> _portalList = new List<GameObject>();

    public int _maxEnemyNum;

    void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyList.Count < _maxEnemyNum) {
            GameObject spawnedObj = _portalList[0].transform.GetChild(0).GetComponent<Spawner>().Spawn();
            _enemyList.Add(spawnedObj);
        }

    }


}
