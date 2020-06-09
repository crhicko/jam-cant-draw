using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    Collider2D cldr;
    private TeamController _teamController;
    SpriteRenderer _spr;
    [SerializeField]
    private Sprite _enemyPuck;
    [SerializeField]
    private Sprite _playerPuck;
    // Start is called before the first frame update
    void Start()
    {
        cldr = GetComponent<CircleCollider2D>();
        _teamController = GetComponent<TeamController>();
        _spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if(_teamController.GetTeam() == Team.Enemy) {

        }
        else if(_teamController.GetTeam() == Team.Player) {

        }
    }

    private void ChangeTeam(Team team) {
        _teamController.SetTeam(team);
        if(team == Team.Player) {
            _spr.sprite = _playerPuck;
        }
        else if(team == Team.Enemy) {
            _spr.sprite = _enemyPuck;
        }
    }
}


