using UnityEngine;

public class EconPOIPannelController : MonoBehaviour
{
    public GameObject ShopPanel;
    private bool playerInShop = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShopPanel.SetActive(false);
    }
    private void Update()
    {
        openMenuInput();
    }

    private void openMenuInput()
    {
        if (playerInShop)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShopPanel.SetActive(true);
            }
        }
    }
    // track if player can open the shop menu ============
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInShop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInShop = false;
            ShopPanel.SetActive(false);
        }
    }
}
