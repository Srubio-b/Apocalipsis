using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;        // Referencia al transform del jugador
    public float moveSpeed = 3f;    // Velocidad de movimiento del enemigo
    public float chaseRange = 10f; // Rango máximo a partir del cual el enemigo empieza a perseguir
    public float stopRange = 1.5f;
    public Rigidbody rigidenemy;

    public void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rigidenemy = transform.GetComponent <Rigidbody> ();
    }
    private void Update()
    {
        // Comprobar la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de persecución, el enemigo lo persigue
        if (distanceToPlayer <= chaseRange)
        {
            if(distanceToPlayer > stopRange) ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
 
        // Calcular la dirección hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        //Vector3 target = transform.position + direction * moveSpeed * Time.deltaTime;
        Vector3 target = Vector3.MoveTowards(transform.position, player.position, moveSpeed* Time.deltaTime);
        rigidenemy.MovePosition(target);

        transform.forward = direction;
    }
}