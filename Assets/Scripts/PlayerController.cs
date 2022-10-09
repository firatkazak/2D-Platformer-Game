using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;//Player'in Rigidbody'si.
    private Animator playerAnimator;//Player'in Animator'�.
    private SpriteRenderer playerSprite;//Player'in Sprite Renderer'i.
    private BoxCollider2D playerCollider;//Player'in collider'�.
    public LayerMask jumpableGround;//Z�planabilir Layer Mask alan�.
    private float horizontalInput;//Horizontal input.
    private float moveSpeed = 7.0f;//Hareket h�z�.
    private float jumpForce = 10.0f;//Z�plama h�z�.
    public AudioSource jumpSoundEffect;//Z�plama sesi.
    private enum MovementState { idle, running, jumping, falling }//Animasyonlar�m�za isim yerine numara verdik.
    //Animator ekran�nda idle 0, running 1, jumping 2 falling de 3 yapt�k. ��nk� burada 0'dan ba�layarak s�ralama o �ekilde.
    //Enum burada bir t�pk� Rigidbody, Animator, AudioSource vb. gibi bir Data Type'a d�n���yor.
    //RigidBody, AudioSource gibi isim verip MovementState'ten 1 tane yarataca��z.(A�a��da "state" isminde 1 tane yaratt�k.)
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
        //Komponent atamalar�.
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");//Horizontal Input atamas�.
        playerRb.velocity = new Vector2(horizontalInput * moveSpeed, playerRb.velocity.y);
        //Player'in rigidbody'sinin Velocity'sine, X'i horizontal �ekilde, moveSpeed h�z�nda Y'si Player'in rigidbody'sinin Velocity'sinin Y'sinde atama yap.
        //Yani sa� sol hareket etmemizi sa�layacak. Yukar� a�a�� hareket etmeyece�imiz i�in playerRb.velocity.y mevcut konum ne ise ayn� kalacak.
        if (Input.GetButtonDown("Jump") && IsGrounded())
        //E�er Jump'a bas�lm��sa ve Player yere temas ediyorsa(Havada 1 daha z�plamas�n� �nlemek i�in.)
        {
            jumpSoundEffect.Play();//Z�plama sesini oynat.
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            //Player'in rigidbody'sinin Velocity'sine, Player'in rigidbody'sinin Velocity'sinin X'ini ve Jumpforce'u ata.
            //Velocity: Nesnenin y�n�n� de belirleyerek olu�an h�z. Daha ger�ek�i hareket i�in.
            //Mant�k: Burada her space'e bast���m�zda X'i 10 birim yukar� ta��yacak, bunu da velocity ile ger�ek�i bi�imde yapacak.
            //Sonra yer �ekimi devreye girecek ve yine velocity kulland���m�z i�in fizik kurallar�na uygun bi�imde inecek.
        }
        Animations();//Animasyonlar� oynat.
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
        //Box collider'in ayn� �l��lerinde hayali bir kutu yarat�yor. Terrain'e(Alan�m�z) Ground layer'ini verdik.
        //Yani bu kod ile zemine temas edip etmedi�imizi kontrol edecek.
    }
    private void Animations()
    {
        MovementState state;//Yukar�da yaratt���m�z MovementState data tipimizden state ad�nda 1 tane yaratt�k.
        if (horizontalInput > 0)//Horizontal ��k�� 0'dan b�y�k ise, yani sa�a do�ru hareket ediyorsa;
        {
            state = MovementState.running;//running animasyonunu state'e ata,
            playerSprite.flipX = false;//flipX'i false yap. yani flip yapma. yani y�n� sabit kals�n.
        }
        else if (horizontalInput < 0)//Horizontal ��k�� 0'dan k���k ise, yani sola do�ru hareket ediyorsa;
        {
            state = MovementState.running;//running animasyonunu state'e ata,
            playerSprite.flipX = true;//flipX'i true yap. yani flip yap. yani y�z�� sola baks�n.
        }
        else//0'dan b�y�k ya da k���k de�ilse, yani 0 ise, yani hareket yoksa
        {
            state = MovementState.idle;//�dle animasyonunu state'e ata.
        }
        if (playerRb.velocity.y > 0.1f)//player'in Rigidbody'sinin velocity'sinin Y'si 0.1'den b�y�k ise
        {
            state = MovementState.jumping;//Z�plama animasyonunu oynat.
        }
        //Z�plama animasyonu ba�lad��� an, yani 10 birim z�plamaya ba�land���nda, mevcut konumundan 0.1 art�nca(yani z�plamaya ba�lay�nca) z�plama animasyonu oynayacak.
        else if (playerRb.velocity.y < -0.1f)//player'in Rigidbody'sinin velocity'sinin Y'si 0.1'den k���k ise;
        {
            state = MovementState.falling;//D��me animasyonunu oynat.
        }
        //Z�plama animasyonu bitti�i an, yani 10 birim z�pland���nda, mevcut konumundan 0.1 azal�nca(yani d��meye ba�lay�nca) d��me animasyonu oynayacak.
        playerAnimator.SetInteger("state", (int)state);//String olarak yaz�lan state Animator'da yaratt���m�z state parametresi. 2. state burada yaratt���m�z int parametre.
        //string "state"'i, int state'e �evir dedik. B�ylece enumu �al��t�racak.
    }
}
