using UnityEngine;
using System.Collections;

public class CombatScript : MonoBehaviour {
    public float health = 100;

    private bool isInLag = false;
    private Animator animator;
    private WeaponScript weapon;

    void Start() {
        animator = GetComponent<Animator>();
        weapon = GetComponentInChildren<WeaponScript>();
    }

    void Update() {
        if(Input.GetMouseButtonDown(0) && !isInLag) {
            animator.Play("attackSword", 1);
            startInputLag(weapon.lag);
            Debug.Log("to attack");
        }
    }

    public void receiveDamage(float damage) {
        //damage calc here
        health = health - damage;
        if(health <= 0) {
            Debug.Log("I'm dead: " + this.gameObject.ToString());
            Destroy(this.gameObject);
        }
    }

    public bool isCharacterInLag() {
        return isInLag;
    }

    public void startInputLag(float duration) {
        StartCoroutine(lagTimer(duration));
    }
    private IEnumerator lagTimer(float duration) {
        isInLag = true;
        weapon.setActiveHitbox(true);
        yield return new WaitForSeconds(duration);
        isInLag = false;
        weapon.setActiveHitbox(false);
    }
}
