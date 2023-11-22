using NaughtyAttributes;
using UnityEngine;
using Unity.Netcode;

namespace BaranovskyStudio
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [AddComponentMenu("Arcade Idle Components/Player Movement", 0)]

    public class PlayerMovement : NetworkBehaviour
    {
        [BoxGroup("CONTROLS")] [SerializeField] [Required("Drag and drop joystick here.")]
        private VariableJoystick joystick;

        [BoxGroup("MOVEMENT")] [SerializeField]
        private float _movementSpeed = 10f;
        [BoxGroup("MOVEMENT")] [SerializeField]
        private float _rotationSpeed = 6f;

        private Rigidbody playerRb;
        private Animator animator;
        private bool isGrounded;
        public SpecialBackpack specialBackpack;
        public Vector3 lastCheckPoint;
        public LayerMask groundMask;

        [Button]
        private void TryFindJoystick()
        {
            joystick = FindObjectOfType<VariableJoystick>();
        }

        private void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!IsOwner)
            {
                return;
            }

            CheckDrag();
        }

        public void GameOverScreen()
        {
            SpawnManager.instance.gameOverScreen.SetActive(true);
        }

        public void WinScreen()
        {
            SpawnManager.instance.winScreen.SetActive(true);
        }

        private void CheckDrag()
        {
            isGrounded = Physics.OverlapSphere(transform.position + new Vector3(0, 0.2f, 0), 0.7f, groundMask).Length >= 1;
            if (isGrounded)
            {
                _movementSpeed = 10;
                playerRb.drag = 12;
            }
            else
            {
                Debug.Log("Not Grounded");
                _movementSpeed = 1;
                playerRb.drag = 0;
            }
        }

        private void OnDrawGizmos()
        {
            //Gizmos.DrawSphere(transform.position + new Vector3(0, 0.2f, 0) , 0.7f);
        }

        private void FixedUpdate()
        {
            if (!joystick || !IsOwner)
            {
                return;
            }
            Vector3 direction = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y); //Convert direction to Vector3

            if ( (direction.x != 0 || direction.y != 0)  && isGrounded) //If direction.x or direction.y is 0 means joystick isn't using
            {
                RotateAndMove(direction, direction.magnitude);
            }
            animator.SetFloat("SpeedMultiplier", direction.magnitude);
        }

        private void RotateAndMove(Vector3 direction, float speedMultiplier)
        {
            playerRb.velocity = transform.forward * _movementSpeed * speedMultiplier;
            playerRb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed));
        }
    }
}
