using UnityEngine;



public class MoveBehaviour
{

    private readonly MoveConfig _config;
    private readonly Rigidbody2D _rb;
    private bool _isGrounded = false;

    public MoveBehaviour(MoveConfig config, Rigidbody2D rb)
    {
        _config = config;
        _rb = rb;
    }

    //TODO velocitySmoothing and airBehaviour
    public void Move(float inputX)
    {
        Vector2 velocity;
        if (_isGrounded)
        {
            velocity = OnGround(inputX);
        }
        else
        {
            velocity = InAir(inputX);
        }
        _rb.linearVelocity = velocity;
    }

    public Vector2 OnGround(float inputX)
    {
        float targetSpeed = inputX * _config.MaxSpeed;
        var currentVelocity = _rb.linearVelocity;
        if (inputX != 0)
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, targetSpeed, _config.Acceleration * Time.fixedDeltaTime);
        }
        else
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, 0, _config.Deceleration * Time.fixedDeltaTime);
        }
        currentVelocity.x = Mathf.Clamp(currentVelocity.x, -_config.MaxSpeed, _config.MaxSpeed);
        return currentVelocity;
    }

    private Vector2 InAir(float InputX)
    {
        float airMaxSpeed=_config.MaxSpeed*_config.AirControlFactor; 
        float targetspeed = InputX * airMaxSpeed;
        var currentVelocity = _rb.linearVelocity;
        if (InputX != 0)
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, targetspeed, _config.AirAcceleration * Time.fixedDeltaTime);
        }
        else
        {
            currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, 0, _config.AirDeceleration * Time.fixedDeltaTime);
        }
        currentVelocity.x = Mathf.Clamp(currentVelocity.x, -airMaxSpeed, airMaxSpeed);
        return currentVelocity;
    }
    public void SetGroundedState(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }
}
