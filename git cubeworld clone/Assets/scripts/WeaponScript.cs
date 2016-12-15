using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
    public float lag;
    public float damage;
    public string weaponName;
    private bool activeHitbox = false;

    public void setActiveHitbox(bool active) {
        activeHitbox = active;
    }

    void OnTriggerEnter(Collider other) {
        if(activeHitbox) {
            CombatScript opponent =  other.gameObject.GetComponent<CombatScript>();
            if(opponent != null) {
                opponent.receiveDamage(damage);
                Debug.Log(opponent.health);
            }
        }
    }
}
