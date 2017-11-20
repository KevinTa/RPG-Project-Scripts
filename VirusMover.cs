using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMover : MonoBehaviour
{
    //[SerializeField]
    private Transform Player;
    //public GameObject Player;
    float MoveSpeed = 4;
    float MaxDist = 10;
    float MinDist = 5;
    public float TimeBetweenAttacks = 0.3f;
    public int attackDamage = 10;
    GameObject p1;
    PlayerHealth playerhealth;
    float timer;
    bool playerattacked;
    /// ;<summary>
    /// //////////////////
    [SerializeField]
    private GameObject hitParticles;
    CapsuleCollider capsuleCollider;
	[SerializeField]
    private int hitPoints = 10;
    
    /// </summary>
    // Use this for initialization
    private void Awake()
    {
        p1 = GameObject.FindGameObjectWithTag("Player");
        playerhealth = p1.GetComponent<PlayerHealth>();
        //hitParticles = GetComponentInChildren<ParticleSystem>();
        
    }
    //////
    public void LaserHit()
    {
        Debug.Log("I've been hit by a lazer");
        hitPoints--;
        if (hitPoints <= 0)
        {
            SpawnManager.instance.KilledEnemy(this);
            Destroy(gameObject);
        }

		//hitParticles.Play();
    }
		
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Laser") {
            Destroy(other.gameObject);
            hitParticles.SetActive(true);
			Invoke("LaserHit", 0.4f);
		}

        //for virus attacking
        if (other.tag=="Player") {
            playerattacked = true;
            Attack();
        }
        //for virus attacking
	}
    /*IEnumerator WaitToExplode()
      {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
            yield return null;
      }*/

    /////
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        SpawnManager.instance.RegisterEnemy(this);
    }



    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
        }
    }

        /// <summary>
    /// ///////////////for virus attacking/////////////////////////////
    /// </summary>
    void Attack()
    {
        timer = 0;
        if (playerhealth.currentHealth > 0)
        {

            playerhealth.TakeDamage(attackDamage);
        }
        else
        {
            PlayerHealth.Death();
        }
        playerattacked = false;
    }
    //for virus attacking
}