using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float _fadeOutTime;
    public Material _material;
    private Material _localMaterial;
    private bool _canDissolve = false;
    public Sprite _dissolvingSprite;

    public void DestroyWithFadeOut() {
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        spr.material = _material;
        spr.sprite = _dissolvingSprite;
        _localMaterial = spr.material;
        StartCoroutine(FadeOutStep());
    }

    // void Update() {
    //     if(_canDissolve == true)
    //         ;
    // }




    private IEnumerator FadeOutStep() {
        float dissolveAmount = 1f;
        Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.zero;
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = false;

        while(dissolveAmount <= 1f && dissolveAmount > 0f) {
            dissolveAmount -= 0.02f;
            _localMaterial.SetFloat("_DissolveAmount", dissolveAmount);
            Debug.Log("Dissolving");
            yield return new WaitForSeconds(_fadeOutTime/50f);
        }
        Destroy(gameObject);
        // _spawnInstantiation = Instantiate(_spawn, gameObject.transform.position, Quaternion.identity);
    }
}
