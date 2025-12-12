
using UnityEngine;

public class JumpBehaviour
{
    private readonly JumpConfig _config;
    private readonly Rigidbody2D _rb;
    public int _jumpCount = 0;

    public JumpBehaviour(JumpConfig config, Rigidbody2D rb)
    {
        _config = config;
        _rb = rb;
    }


    public bool Jump(bool isGrounded,bool isCoyote)
    {
        bool canUseGround = isGrounded || isCoyote;
        bool canDoubleJump = !isGrounded && _jumpCount < _config.MultiJumpCount;

        if (canUseGround || canDoubleJump)
        {
            if(isGrounded&&isCoyote)
            {
                _jumpCount = 0;
            }
            Vector2 currentVelocity = _rb.linearVelocity;
            currentVelocity.y = _config.JumpForce;
            _rb.linearVelocity = currentVelocity;
            _jumpCount++;

            return true;
        }
        else
        {
            return false;
        }        
    } 
}
