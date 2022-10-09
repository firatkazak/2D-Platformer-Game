using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Oyunun ana ekran�n�n index'i 0. Level1'in index'i 1. Start'a bas�nca 0'dan 1'e ge�ecek. Mant�k bu.
    }
    public void Quit()
    {
        Application.Quit();//Oyundan ��k fonksiyonu.
    }
}
