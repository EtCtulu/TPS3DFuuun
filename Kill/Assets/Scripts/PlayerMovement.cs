using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement s_singletonPlayer;

    #region Public fields

    // Les touches
    [Header("Keys")] 
    public KeyCode forwardPositive = KeyCode.Z;
    public KeyCode forwardNegative = KeyCode.S;
    public KeyCode rightPositive = KeyCode.D;
    public KeyCode rightNegative = KeyCode.Q;
    
    // Variables Vie / Shield / FireRate / FOV
    [Header("HP / Shield / Fire Rate Settings")]
    public int hp = 100;
    public int shield = 0;
    public float fireRate = 0.25f;
    public float mFieldOfView = 60;
    private float nextFire;
    
    // Les settings de marche ou de run
    [Header("Walk / Run Settings")] 
    public float runSpeed;
    
    // La vitesse actuelle
    [Header("Current Speed")] 
    public float currentSpeed;

    // Les options de saut
    [Header("Jump Settings")] 
    public float playerJumpForce;
    public ForceMode appliedForceMode;
    public bool playerIsJumping;
    
    // Les usables et le gunpoint
    [Header("Usable Settings")] 
    public GameObject playerSprite;
    public GameObject arrow;
    public GameObject poids;
    private bool isArrowOn = true;

    private int _mineCount = 0;
    public GameObject mine;
    public Transform gunPoint;
    
    // Angle d'utilisation des projectiles a angle
    [Header("Angle Projectile Settings")]
    [Range(0, 1000)] public float power = 30;
    [Range(0, 1000)] public float angle = 70;
    
    // Les sfx et les anims
    [Header("SFX / VFX Settings")]
    public Animator anim;

    #endregion

    #region Private fields

    // Reférence les axes X et Z
    private float _xAxis;
    private float _zAxis;
    
    // Référence du rigidbody
    private Rigidbody _rb;
    
    // Check du collider avec le sol
    private RaycastHit _hit;
    private Vector3 _groundLocation;
    private bool _isCapslockPressedDown;
    

    #endregion

    #region Monodevelop Routines
    
    
    private void Awake()
    {
        #region Initialize


        // Déclaration du singleton du joueur
        if (s_singletonPlayer != null)
        {
            Destroy(this);
        }
        else
        {
            s_singletonPlayer = this;
            _rb = GetComponent<Rigidbody>();
        }
        
        #endregion
    }

    #endregion

    void Update()
    {
        #region Input region

        // Déclaration de l'axe
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");

        // Player swap weapon
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isArrowOn == false)
            {
                isArrowOn = true;
                return;
            }
            else
            {
                isArrowOn = false;
            }
        }
        
        // Player Shot
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && isArrowOn == true)
        {
            nextFire = Time.time + +fireRate;
            Destroy( Instantiate(arrow, gunPoint), 15f);
        }
        
        // Player Axe
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && isArrowOn == false)
        {
            nextFire = Time.time + +fireRate;
            GameObject alter = Instantiate(poids, gunPoint);
            Vector3 projection = new Vector3(alter.transform.position.x,  Mathf.Abs(power * Mathf.Sin(angle)), Mathf.Abs(power * Mathf.Tan(angle)));
            alter.GetComponent<Rigidbody>().AddForce(projection, ForceMode.Force);
            
        }
        
        //Player Aim
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Color tmp = playerSprite.GetComponent<SpriteRenderer>().color;
            tmp.a = 0.05f;
            playerSprite.GetComponent<SpriteRenderer>().color = tmp;
            Camera.main.fieldOfView = mFieldOfView - 30;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Color tmp = playerSprite.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            playerSprite.GetComponent<SpriteRenderer>().color = tmp;
            Camera.main.fieldOfView = mFieldOfView + 30;
        }

        //Player Mine1
        if (Input.GetKeyDown(KeyCode.G) && _mineCount >= 1)
        {
            GameObject themine = Instantiate(mine, gunPoint);
            themine.transform.parent = null;
            _mineCount--;
        }

            // Le quaternion euler est comme un .rotation sauf que l'on peut changer indépendament les valeurs xyz
            // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.rotation.eulerAngles.z);
        
            #endregion
            
            
            
    }

    private void FixedUpdate()
    {
        #region Move Player

        _rb.MovePosition(transform.position + Time.deltaTime * currentSpeed * 
            transform.TransformDirection(_xAxis, 0f, _zAxis));

        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mine Collectible"))
        {
            _mineCount++;
            Destroy(other.gameObject);
            
        }
        if (other.CompareTag("Attack"))
        {
            var attack = 20;
                
            if (shield >= 15)
            {
                attack = attack - 5;
                shield = shield - 15;
            }

            hp = hp - attack;
            Debug.Log("Vie : " + hp );
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
