using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private Animator animator;
    private bool KeyPickedUp = false;
    //private SpriteRenderer sprite;
    public GameObject LevelCompleteFlag;

    private void Awake()
    {
        //LevelCompleteFlag = this.transform.Find("LevelOverFlag").GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
    }

    public void KeyStatus(bool status)
    {
        KeyPickedUp = status;
    }
    private void Update()
    {
        if(KeyPickedUp == false)
        {
            LevelCompleteFlag.SetActive(false);
            //sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 134);
            
        }
        else
        {
            LevelCompleteFlag.SetActive(true);
            //sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255);
        }

        animator.SetBool("PickedUpKey", KeyPickedUp);
    }
}
