using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontalInput;
    private bool verticalInput;
    private bool crouchbutton = false;

    public float HorizontalInput { get { return horizontalInput; } }
    public bool VerticalInput { get { return verticalInput; } }
    public bool Crouchbutton  { get { return crouchbutton; } }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetKeyDown(KeyCode.Space);
        crouchbutton = Input.GetKey(KeyCode.LeftControl);
        
    }
    
}
