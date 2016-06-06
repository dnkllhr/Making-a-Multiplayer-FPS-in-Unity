using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensitvity = 5f;

    private PlayerMotor motor;

    void Start ()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        //Final Movement Vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Now Apply Movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector (only the y rotation will effect position because it turns the player around)
        //rotations in other directions would mess up movement if allowed to affect position
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitvity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Now we can calculate camera rotation which will involve the player looking up and down
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitvity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotation);


    }
}
