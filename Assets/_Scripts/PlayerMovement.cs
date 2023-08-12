using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Fuerza de Movimiento del personaje en m/s")]
    [Range(0, 1000)]
    public float speed;

    [Tooltip("Fuerza de Rotacion del personaje en grados/seg")]
    [Range(0, 360)]
    public float rotationSpeed;

    private Rigidbody rb;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float space = speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        //transform.Translate(dir.normalized * space);

        float angle = rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(0, mouseX * angle, 0);
        
        //FUERZA DE TRANSLACIÓN
        rb.AddRelativeForce(dir.normalized * space);
        
        //FUERZA DE ROTACIÓN O TORQUE
        rb.AddRelativeTorque(0, mouseX * angle, 0);
        
        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0,0,space);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0,0,-space);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-space,0,0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(space,0,0);
        }*/

    }
}
