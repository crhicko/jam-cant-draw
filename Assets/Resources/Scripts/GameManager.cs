using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> _puckList = new List<GameObject>();
    public List<GameObject> _enemyList = new List<GameObject>();
    public List<GameObject> _portalList = new List<GameObject>();

    public int _maxEnemyNum;
    public int _enemiesPerSpawner;

    public List<GameObject> _disabledPortalList = new List<GameObject>();

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
        if(_disabledPortalList.Count == _portalList.Count) {
            Debug.Log("VICTORY");
        }

        if(_enemyList.Count < _maxEnemyNum) {

            GameObject spawnedObj = GetRandomPortal().transform.GetChild(0).GetComponent<Spawner>().Spawn();
            _enemyList.Add(spawnedObj);
        }

    }

    private GameObject GetRandomPortal() {
        GameObject portal;
        List<GameObject> tempList;
        tempList = _portalList.Except(_disabledPortalList).ToList();
        do {
            portal = tempList[Random.Range(0, tempList.Count)];
        } while(!portal.GetComponent<PortalController>().isEnabled);
        return portal;
    }



}
