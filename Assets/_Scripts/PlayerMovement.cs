using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Fuerza de Movimiento del personaje caminando en m/s")]
    [SerializeField]
    private float speed = 400;
    
    [Tooltip("Fuerza de Movimiento del personaje corriendo en m/s")]
    [SerializeField]
    private float runSpeed = 1000;

    [Tooltip("Fuerza de Rotacion del personaje en grados/seg")]
    [Range(0, 360)]
    public float rotationSpeed;

    private Rigidbody _rb;

    private Animator _animator;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time > 8.0f)
        {
            float space;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(horizontal, 0, vertical);

            float angle = rotationSpeed * Time.deltaTime;
            float mouseX = Input.GetAxis("Mouse X");
        
            _animator.SetFloat("MoveX", horizontal);
            _animator.SetFloat("MoveY", vertical);
        
            if (Input.GetKey(KeyCode.LeftShift))
            {
                space = runSpeed * Time.deltaTime;
            }
            else
            {
                space = speed * Time.deltaTime;
            }
            _animator.SetFloat("Velocity", _rb.velocity.magnitude);
            _rb.AddRelativeForce(dir.normalized * space); //FUERZA DE TRANSLACIÓN
            _rb.AddRelativeTorque(0, mouseX * angle, 0); //FUERZA DE ROTACIÓN O TORQUE
        }
    }
}
