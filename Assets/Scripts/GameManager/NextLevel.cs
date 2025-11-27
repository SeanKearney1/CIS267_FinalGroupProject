using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [Header("--Level Select--")]
    [Header("1 = Elven, 2 = Dwarven, 3 = Orc")]
    [Range(1, 3)]
    public int level;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(level);
        }
    }
}
