using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public PlayerController player;
    public Bullet bullet;
    public Text text;
    public bool attack;
    public bool hp;
    public bool speed;

    public void States()
    {
        if (attack)
        {
            string Attack = text.text;
            if (int.Parse(Attack) < 2)
            {
                bullet.damage = 1;
            }
            else
            {
                bullet.damage = 1 + int.Parse(Attack) / 2;
            }
        }
        else if (hp)
        {
            string HP = text.text;
            player.maxHP = 1 + int.Parse(HP) / 5;
        }
        else if (speed)
        {
            string Speed = text.text;
            player.speed = 2.5f + float.Parse(Speed) / 40;
        }
    }
}
