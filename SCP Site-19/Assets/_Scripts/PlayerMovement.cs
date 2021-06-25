using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight;
    [SerializeField] private float x;
    [SerializeField] private float z;

    [Header("Ausdauer")]
    public Slider staminaSlider;
    public TMP_Text staminaText;
    public float maxStamina;
    [SerializeField]private float currentStamina;
    public float staminaFallRate;
    public float staminaRegRate;

    public bool canJump;
    public bool isRunning;
    public bool isMakingSteps;
    [SerializeField]private bool isGrounded;

    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    [SerializeField]private Vector3 velocity;

    [Header("Sprung und Lande Sounds")]
    public AudioSource Sprung;
    public AudioSource Landung;

    [Header("Lauf Sounds")]
    public AudioSource audioSource;
    public AudioClip[] walk;
    public AudioClip[] sprint;
    [SerializeField] AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaSlider.value = currentStamina;
        staminaText.text = currentStamina.ToString("F0") + "%";
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Sprung.Play();
        }

        velocity.y += gravity * Time.deltaTime;

        if (isGrounded && !isRunning && x != 0f || isGrounded && !isRunning && z != 0f)
            StartCoroutine(Walking());

        if (isGrounded && isRunning && x != 0f || isGrounded && isRunning && z != 0f)
            StartCoroutine(Running());

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f && x != 0f || Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f && z != 0f)
        {
            isRunning = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }

     void FixedUpdate()
    {
        Vector3 move = transform.right * x + transform.forward * z;
        move = move.normalized;

        controller.Move(velocity * Time.fixedDeltaTime);

        if (!isRunning)
        {
            controller.Move(move * speed * Time.fixedDeltaTime);
            if (currentStamina <= maxStamina)
                currentStamina += staminaRegRate * Time.fixedDeltaTime;
        }
        else
        {
            controller.Move(move * runSpeed * Time.fixedDeltaTime);
            currentStamina -= staminaFallRate * Time.fixedDeltaTime;
            if (currentStamina <= 0f)
            {
                isRunning = false;
            }
        }
    }

    IEnumerator Walking()
    {
        if (!isMakingSteps)
        {
            isMakingSteps = true;
            int index = Random.Range(0, walk.Length);
            clip = walk[index];
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(0.8f);
            isMakingSteps = false;
        }
    }

    IEnumerator Running()
    {
        if (!isMakingSteps)
        {
            isMakingSteps = true;
            int index = Random.Range(0, sprint.Length);
            clip = sprint[index];
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(0.6f);
            isMakingSteps = false;
        }
    }
}
