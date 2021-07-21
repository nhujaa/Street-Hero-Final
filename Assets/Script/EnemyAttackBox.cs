using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    public GameObject attack1Box, attack2Box;

    public void Attack()
    {
        attack1Box.gameObject.SetActive(true);
    }

    public void Attack2()
    {
        attack2Box.gameObject.SetActive(true);
    }

    public void DeactivateAttackBoxes()
    {
        attack1Box.gameObject.SetActive(false);
        attack2Box.gameObject.SetActive(false);
    }
}
