using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;//Player'in Rigidbody'si.
    private Animator playerAnimator;//Player'in Animator'ü.
    private SpriteRenderer playerSprite;//Player'in Sprite Renderer'i.
    private BoxCollider2D playerCollider;//Player'in collider'ý.
    public LayerMask jumpableGround;//Zýplanabilir Layer Mask alaný.
    private float horizontalInput;//Horizontal input.
    private float moveSpeed = 7.0f;//Hareket hýzý.
    private float jumpForce = 10.0f;//Zýplama hýzý.
    public AudioSource jumpSoundEffect;//Zýplama sesi.
    private enum MovementState { idle, running, jumping, falling }//Animasyonlarýmýza isim yerine numara verdik.
    //Animator ekranýnda idle 0, running 1, jumping 2 falling de 3 yaptýk. Çünkü burada 0'dan baþlayarak sýralama o þekilde.
    //Enum burada bir týpký Rigidbody, Animator, AudioSource vb. gibi bir Data Type'a dönüþüyor.
    //RigidBody, AudioSource gibi isim verip MovementState'ten 1 tane yaratacaðýz.(Aþaðýda "state" isminde 1 tane yarattýk.)
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
        //Komponent atamalarý.
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");//Horizontal Input atamasý.
        playerRb.velocity = new Vector2(horizontalInput * moveSpeed, playerRb.velocity.y);
        //Player'in rigidbody'sinin Velocity'sine, X'i horizontal þekilde, moveSpeed hýzýnda Y'si Player'in rigidbody'sinin Velocity'sinin Y'sinde atama yap.
        //Yani sað sol hareket etmemizi saðlayacak. Yukarý aþaðý hareket etmeyeceðimiz için playerRb.velocity.y mevcut konum ne ise ayný kalacak.
        if (Input.GetButtonDown("Jump") && IsGrounded())
        //Eðer Jump'a basýlmýþsa ve Player yere temas ediyorsa(Havada 1 daha zýplamasýný önlemek için.)
        {
            jumpSoundEffect.Play();//Zýplama sesini oynat.
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            //Player'in rigidbody'sinin Velocity'sine, Player'in rigidbody'sinin Velocity'sinin X'ini ve Jumpforce'u ata.
            //Velocity: Nesnenin yönünü de belirleyerek oluþan hýz. Daha gerçekçi hareket için.
            //Mantýk: Burada her space'e bastýðýmýzda X'i 10 birim yukarý taþýyacak, bunu da velocity ile gerçekçi biçimde yapacak.
            //Sonra yer çekimi devreye girecek ve yine velocity kullandýðýmýz için fizik kurallarýna uygun biçimde inecek.
        }
        Animations();//Animasyonlarý oynat.
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
        //Box collider'in ayný ölçülerinde hayali bir kutu yaratýyor. Terrain'e(Alanýmýz) Ground layer'ini verdik.
        //Yani bu kod ile zemine temas edip etmediðimizi kontrol edecek.
    }
    private void Animations()
    {
        MovementState state;//Yukarýda yarattýðýmýz MovementState data tipimizden state adýnda 1 tane yarattýk.
        if (horizontalInput > 0)//Horizontal çýkýþ 0'dan büyük ise, yani saða doðru hareket ediyorsa;
        {
            state = MovementState.running;//running animasyonunu state'e ata,
            playerSprite.flipX = false;//flipX'i false yap. yani flip yapma. yani yönü sabit kalsýn.
        }
        else if (horizontalInput < 0)//Horizontal çýkýþ 0'dan küçük ise, yani sola doðru hareket ediyorsa;
        {
            state = MovementState.running;//running animasyonunu state'e ata,
            playerSprite.flipX = true;//flipX'i true yap. yani flip yap. yani yüzüü sola baksýn.
        }
        else//0'dan büyük ya da küçük deðilse, yani 0 ise, yani hareket yoksa
        {
            state = MovementState.idle;//Ýdle animasyonunu state'e ata.
        }
        if (playerRb.velocity.y > 0.1f)//player'in Rigidbody'sinin velocity'sinin Y'si 0.1'den büyük ise
        {
            state = MovementState.jumping;//Zýplama animasyonunu oynat.
        }
        //Zýplama animasyonu baþladýðý an, yani 10 birim zýplamaya baþlandýðýnda, mevcut konumundan 0.1 artýnca(yani zýplamaya baþlayýnca) zýplama animasyonu oynayacak.
        else if (playerRb.velocity.y < -0.1f)//player'in Rigidbody'sinin velocity'sinin Y'si 0.1'den küçük ise;
        {
            state = MovementState.falling;//Düþme animasyonunu oynat.
        }
        //Zýplama animasyonu bittiði an, yani 10 birim zýplandýðýnda, mevcut konumundan 0.1 azalýnca(yani düþmeye baþlayýnca) düþme animasyonu oynayacak.
        playerAnimator.SetInteger("state", (int)state);//String olarak yazýlan state Animator'da yarattýðýmýz state parametresi. 2. state burada yarattýðýmýz int parametre.
        //string "state"'i, int state'e çevir dedik. Böylece enumu çalýþtýracak.
    }
}
