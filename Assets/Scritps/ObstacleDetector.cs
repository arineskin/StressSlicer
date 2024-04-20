using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    public GameObject Knife;
    public Animator animator;
    private bool boosterActivated = false; // Для отслеживания активации бустера

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit))
        {
            if (hit.collider.tag == "MetalObstacle" && Knife.GetComponent<Knife>().IsCutting)
            {
                if (!GameSystem.System.LEVEL.ignoreMetalObstacles)
                {
                    animator.SetBool("IsHit", true);
                }
            }
            else if (hit.collider.tag == "BoosterObstacle" && Knife.GetComponent<Knife>().IsCutting)
            {
                if (!boosterActivated) // Проверяем, был ли уже активирован бустер
                {
                    GameSystem.System.LEVEL.ActivateBoosters();
                    boosterActivated = true; // Устанавливаем флаг активации
                }
            }
            else
            {
                boosterActivated = false; // Сброс при выходе из контакта с BoosterObstacle
            }
        }
    }
}