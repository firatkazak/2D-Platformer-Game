using UnityEngine;
public class Rotate : MonoBehaviour
{
    private float speed = 5.0f;//B��a��n d�nme h�z�.
    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        //Bunu B��aklara atad�k. B��ak d�n�yormu� efekti vermek i�in yapt�k. 360 derece d�necek.
    }
}
