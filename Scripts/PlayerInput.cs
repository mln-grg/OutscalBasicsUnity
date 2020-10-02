using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontalInput;
    private bool verticalInput;
    private bool crouchbutton = false;
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetKeyDown(KeyCode.Space);
        crouchbutton = Input.GetKey(KeyCode.LeftControl);
    }
    
    public float returnHorizontalInput()
    {
        return horizontalInput;
    }
    
    public bool returnVerticalInput()
    {
        return verticalInput;
    }
    
    public bool returnCrouchInput()
    {
        return crouchbutton;
    }
}
