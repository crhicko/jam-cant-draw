using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private Sprite _disabledSprite;
    private SpriteRenderer spriteRenderer;
    public bool isEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name.Contains("Puck")) {
            if(other.gameObject.GetComponent<TeamController>().GetTeam() == Team.Player) {
                if(isEnabled) {
                    GameManager.Instance._disabledPortalList.Add(gameObject);
                    isEnabled = false;
                    spriteRenderer.sprite = _disabledSprite;
                }
            }
            Destroy(other.gameObject);
        }
    }
}
