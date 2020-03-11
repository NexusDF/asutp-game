using UnityEngine;

public class PipeDirectionController : MonoBehaviour
{
    public Vector3 Position;
    public FixedJoystick joystick;

    [Range(0, 1)]
    public float spaceBetweenPipe = 0.5f;

    [Range(0, 10)]
    public float delay;

    [Range(0, 10)]
    public float sensitivity;

    public bool IsDown { get; set; }
    public bool IsEnterPlast { get; set; }

    private DeathZone _deadZone;

    private float _secondCounter = 0;
    private Pipes _pipes;

    private float dx = 0; 
    private float dz = 0;

    void Start()
    {
        _secondCounter = 0;
        _pipes = GetComponent<Pipes>();
        _deadZone = GameObject.Find("GameOver").GetComponent<DeathZone>();
    }

    void FixedUpdate()
    {
        if (IsDown)
        {
            _secondCounter += Time.deltaTime;
            if (_secondCounter >= delay)
            {
                if (IsEnterPlast)
                {
                    sensitivity = 2f;
                    dx += joystick.Vertical * sensitivity * Time.deltaTime;
                    dz += joystick.Horizontal * sensitivity * Time.deltaTime;
                }
                else
                {
                    dx = joystick.Vertical * sensitivity * Time.deltaTime;
                    dz = joystick.Horizontal * sensitivity * Time.deltaTime;
                }

                Vector3 direction = new Vector3(Position.x + dx, Position.y - spaceBetweenPipe, Position.z + dz);
                Position = direction;
                _pipes.CreatePipe(direction, Quaternion.identity);

                _deadZone.GetOut(direction);

                _secondCounter = 0;
            }
        }
    }

    public void PipeStart()
    {
        _pipes.CreatePipe(Position, Quaternion.identity);
    }
}
