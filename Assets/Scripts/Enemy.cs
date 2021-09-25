using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    #endregion

    #region Physics_components
    Rigidbody2D EnemyRB;
    #endregion

    #region Heath_variables
    public float maxHealth;
    float currHealth;
    #endregion

    #region Unity_functions

    private void Awake()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
    }

    private void Update()
    {
        if (EnemyRB.transform.position.x < -3)
        {
            Destroy(this.gameObject);
        }
        EnemyRB.transform.position += Vector3.left * movespeed * Time.deltaTime;
    }
    #endregion

    #region Movement_functions

   
    #endregion

    #region Attack_functions

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerControl>().TakeDamage(1);
        }
    }
    #endregion

    #region Health_functions

    public void TakeDamage(float value)
    {
        currHealth -= value;
        Debug.Log("Health is now " + currHealth.ToString());

        if (currHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    #endregion
}

