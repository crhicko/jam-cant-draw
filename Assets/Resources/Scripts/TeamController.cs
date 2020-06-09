using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Player,
    Enemy
}

public class TeamController : MonoBehaviour
{
    [SerializeField]
    private Team _team;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTeam(Team team) {
        _team = team;
    }

    public Team GetTeam() {
        return _team;
    }

}
