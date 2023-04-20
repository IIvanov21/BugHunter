using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private List<Collider2D> alreadyCollidedWith = new List<Collider2D>();
    [SerializeField] private Collider2D myCollider;
    private int attackDamage;
    private float knockback;
    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == myCollider) return;
        if (alreadyCollidedWith.Contains(other)) return;
        alreadyCollidedWith.Add(other);
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealtDamage(attackDamage);
        }
        if (other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver))
        {
            Vector2 force = (other.transform.position - myCollider.transform.position).normalized;
            forceReceiver.AddForce(force * knockback);
        }

    }

    public void SetAttack(int damage, float knockback)
    {
        attackDamage = damage;
        this.knockback = knockback;
    }
}
