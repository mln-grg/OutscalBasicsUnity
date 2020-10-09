using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite Emptyheart;
   
    [Range(0, 3)] [SerializeField] private int health=3;
    [Range(0, 3)] [SerializeField] private int numberofhearts=3;
    private void Update()
    {
        
        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = Emptyheart;
            }
            if (health > numberofhearts)
            {
                numberofhearts = health;
            }
            if (i < numberofhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public int ReturnPlayerHealth()
    {
        return health;
    }
    public void TakeDamage()
    {
        if (health > 0)
        {
            health--;
        }
        
        
    }
}
