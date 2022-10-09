using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Oyunun ana ekranýnýn index'i 0. Level1'in index'i 1. Start'a basýnca 0'dan 1'e geçecek. Mantýk bu.
    }
    public void Quit()
    {
        Application.Quit();//Oyundan çýk fonksiyonu.
    }
}
