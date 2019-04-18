using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SPM.CustomPhysics
{
    public class PhysicsComponent : MonoBehaviour
    {
        [Header("Gravity")]
        public bool useGravity;
        [Range(0,1)]
        public float buffer;

        private Collider collider;
        private Vector3 force;

        public Vector3 GetForce() { return force; }

        public void SetupDependencies()
        {

            collider = GetComponent<Collider>();

        }

        public void Awake()
        {
            SetupDependencies();
        }

        public void Update()
        {
            if (!useGravity)
                return;

            ResetForce();
            DetectCollision();
           
        }

        public void LateUpdate()
        {
            if (!useGravity)
                return;

            HandleForces();
        }

        public void HandleForces() {

            transform.position += force;

        }


        public void ResetForce() {

         
                force = PhysicsManager.Gravity();

        }


        public void DetectCollision()
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, Vector3.down, Color.blue, collider.bounds.extents.y * Time.deltaTime + buffer);
            Physics.BoxCast(transform.position, transform.localScale/2, Vector3.down, out hit, transform.rotation, collider.bounds.extents.y * Time.deltaTime + buffer);

            if (!hit.collider)
                return;

            CollisionReaction(hit.collider.gameObject);
             

        }

        public void SetForce(Vector3 force) {
            this.force = force;
        }

        public void CollisionReaction(GameObject other) {

            
                if (other.layer.Equals(LayerMask.NameToLayer("Ground")))
                {
                    force += PhysicsManager.GroundPush();
                }
                else
                {
                    force += other.GetComponent<PhysicsComponent>().GetForce();
                }

            

        }



    }
}