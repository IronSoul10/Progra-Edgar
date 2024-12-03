using UnityEngine;

/// <summary>
/// Un movimiento que requiere fisica se debe de hacer con rigidbody
/// 
/// Un movimiento que unicamente es lateral, salto, y ya, Usas CharacterController
/// 
/// Un movimiento con Transform puedes hacer de todo, pero requiere más trabajo
/// 
/// Inputs
/// Ridigbody
/// 3 Velocidades
/// 
/// </summary>
/// 
namespace Angie
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float crouchSpeed = 3;
        [SerializeField] private float walkSpeed = 5;
        [SerializeField] private float runSpeed = 7;

        private Rigidbody rb;

        private Corrutinas corrutinas;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            corrutinas = GetComponent<Corrutinas>();
        }

        private void Start()
        {
        }

        private void FixedUpdate()
        {
            Move();
        }

        CharacterController cc;

        private void Move()
        {
            rb.velocity = transform.rotation * new Vector3(HorizontalMove(), 0, VerticalMove()) * ActualSpeed();
        }

        private float ActualSpeed()
        {
            return IsRunning() ? runSpeed : IsCrouching() ? crouchSpeed : walkSpeed; // Operador ternario
        }

        public float HorizontalMove()
        {
            return Input.GetAxis("Horizontal");
        }

        public float VerticalMove()
        {
            return Input.GetAxis("Vertical");
        }

        public bool IsMoving()
        {
            if (HorizontalMove() != 0 || VerticalMove() != 0)
            {
                
                return true;
            }
            else
            {
                
                return false;
            }
        }

        public bool IsRunning()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        private bool IsCrouching()
        {
            return Input.GetKey(KeyCode.LeftControl);
        }

    }
}