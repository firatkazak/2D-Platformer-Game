using UnityEngine;
public class Rotate : MonoBehaviour
{
    private float speed = 5.0f;//Býçaðýn dönme hýzý.
    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        //Bunu Býçaklara atadýk. Býçak dönüyormuþ efekti vermek için yaptýk. 360 derece dönecek.
    }
}
