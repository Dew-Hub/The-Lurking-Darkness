using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MimicSpace
{
    /// <summary>
    /// This is a very basic movement script, if you want to replace it
    /// Just don't forget to update the Mimic's velocity vector with a Vector3(x, 0, z)
    /// </summary>
    public class Movement : MonoBehaviour
    {
        [Header("Controls")]
        [Tooltip("Body Height from ground")]
        [Range(0.5f, 5f)]
        public float height = 0.8f;
        public float speed = 5f;
        Vector3 velocity = Vector3.zero;
        public float velocityLerpCoef = 4f;
        Mimic myMimic;
        private Transform playerTransform;
        public GameObject playerPos;

        private void Start()
        {
            playerTransform = playerPos.transform;
            myMimic = GetComponent<Mimic>();
        }

        void Update()
        {
            // Calculate the direction and distance to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            // If the Mimic is facing the player, move quickly towards them
            if (Vector3.Dot(transform.forward, directionToPlayer) > 0)
            {
                velocity = directionToPlayer.normalized * speed;
            }
            // If the Mimic is not facing the player, move slowly towards them
            else
            {
                velocity = directionToPlayer.normalized * speed * 0.5f;
            }

            // Assigning velocity to the mimic to assure great leg placement
            myMimic.velocity = velocity;
            
            transform.position = transform.position + velocity * Time.deltaTime;
            RaycastHit hit;
            Vector3 destHeight = transform.position;
            if (Physics.Raycast(transform.position + Vector3.up * 5f, -Vector3.up, out hit))
                destHeight = new Vector3(transform.position.x, hit.point.y + height, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destHeight, velocityLerpCoef * Time.deltaTime);
        }
    }
}
