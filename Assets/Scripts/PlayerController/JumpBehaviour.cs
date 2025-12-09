using UnityEngine;

public class JumpBehaviour
{
    private readonly JumpConfig _config;
    private readonly Rigidbody2D _rb;
    public int _jumpCount = -1;
    
    
    


    public JumpBehaviour(JumpConfig config,Rigidbody2D rb)
    {
        _config = config;
        _rb=rb;
    }

    public void Jump()
    {
        if (_jumpCount < _config.MultiJumpCount)
        {
            Vector2 currentVelocity = _rb.linearVelocity;
            currentVelocity.y = _config.JumpForce;
            _rb.linearVelocity = currentVelocity;
            _jumpCount++;
        }

    }


}
