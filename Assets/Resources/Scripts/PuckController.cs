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
    [SerializeField]
    private int _maxNumHits;

    public GameObject Player;


    private int _numHits = 0;

    // Start is called before the first frame update
    void Awake()
    {
        cldr = GetComponent<CircleCollider2D>();
        _teamController = GetComponent<TeamController>();
        _spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collisition Detected with " + other.gameObject.name);
        // if(_teamController.GetTeam() == Team.Enemy) {
        //     if(other.gameObject.GetComponent<TeamController>() != null && other.gameObject.GetComponent<TeamController>().GetTeam() == Team.Player)
        //         ChangeTeam(Team.Player);
        // }
        if(_teamController.GetTeam() == Team.Enemy && other.gameObject.name.Contains("Player")) {
            other.gameObject.GetComponent<PlayerShotController>().AddAmmo(1);
            Destroy(gameObject);
        }

        _numHits++;
        if(_numHits == _maxNumHits) {
            Debug.Log("going to fade");
            GetComponent<FadeOut>().DestroyWithFadeOut();
        }
    }

    public void ChangeTeam(Team team) {
        Debug.Log("Changing Team to " + team + _teamController);
        _teamController.SetTeam(team);
        if(team == Team.Player) {
            gameObject.layer = 11;
            _spr.sprite = _playerPuck;
            // Physics2D.IgnoreCollision(Player.GetComponent<BoxCollider2D>(), cldr);
        }
        else if(team == Team.Enemy) {
            _spr.sprite = _enemyPuck;
            //If things arent colliding on this you need to change the layer
        }
    }
}



