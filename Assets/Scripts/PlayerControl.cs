using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("How fast player moves")]
    private float m_Speed;

    [SerializeField]
    [Tooltip("Player's initial health")]
    private int m_MaxHealth;

    [SerializeField]
    [Tooltip("Upper boundary of player movement")]
    private float m_UpBoundary;

    [SerializeField]
    [Tooltip("Lower boundary of player movement")]
    private float m_LowBoundary;
    #endregion

    #region Private Variables
    private float p_CurrHealth;
    private bool p_HasShield;
    //private GameObject player;
    Rigidbody2D player;
    private int score;
    #endregion

    #region Initialization
    private void Awake()
    {
        
        p_CurrHealth = m_MaxHealth;
        p_HasShield = false;
    }
    #endregion

    #region Main Updates
    private void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical") * m_Speed * Time.fixedDeltaTime;
        if(player == null)
        {
            //player = GameObject.FindGameObjectWithTag("Player");
            player = GetComponent<Rigidbody2D>();
            
        }
        if(player.transform.position.y + verticalMovement >= m_UpBoundary)
        {
            verticalMovement = 0;
        }
        if (player.transform.position.y + verticalMovement <= m_LowBoundary)
        {
            verticalMovement = 0;
        }
        transform.Translate(Vector2.up * verticalMovement);
    }

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.CompareTag("Shield"))
        {
            p_HasShield = true;
            Debug.Log("has shield now");
            Destroy(collision.transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && p_HasShield)
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>().IncreaseScore();
            Debug.Log("shield destroyed an enemy");
            score += 1;
            Destroy(collision.transform.gameObject);
        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>().DecreaseHealth();
            p_CurrHealth -= 1;
            Debug.Log("player lost a health");
        }
    }

    public void TakeDamage(float value)
    {
        p_CurrHealth -= value;
        Debug.Log("Health is now " + p_CurrHealth.ToString());

        if (p_CurrHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

}
