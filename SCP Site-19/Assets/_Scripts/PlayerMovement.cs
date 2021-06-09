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

    [Header("Ausdauer")]
    public Slider staminaSlider;
    public TMP_Text staminaText;
    public float maxStamina;
    private float currentStamina;
    public float staminaFallRate;
    public float staminaRegRate;

    public bool canJump;
    public bool isRunning;
    public bool isMakingSteps;
    private bool isGrounded;

    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    private Vector3 velocity;

    [Header("Sprung und Lande Sounds")]
    public AudioSource Sprung;
    public AudioSource Landung;

    #region Lauf Sounds
    [Header("Lauf Sounds")]
    public AudioSource Step1;
    public AudioSource Step2;
    public AudioSource Step3;
    public AudioSource Step4;
    public AudioSource Step5;
    public AudioSource Step6;
    public AudioSource Step7;
    public AudioSource Step8;

    [Header("Renn Sounds")]
    public AudioSource Run1;
    public AudioSource Run2;
    public AudioSource Run3;
    public AudioSource Run4;
    public AudioSource Run5;
    public AudioSource Run6;
    public AudioSource Run7;
    public AudioSource Run8;
    #endregion

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

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move = move.normalized;

        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Sprung.Play();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (!isRunning)
        {
            controller.Move(move * speed * Time.deltaTime);
            if (currentStamina <= maxStamina)
                currentStamina += staminaRegRate * Time.deltaTime;
        }
        else
        {
            controller.Move(move * runSpeed * Time.deltaTime);
            currentStamina -= staminaFallRate * Time.deltaTime;
            if (currentStamina <= 0f)
            {
                isRunning = false;
            }
        }

        if (isGrounded && !isRunning && x != 0 || isGrounded && !isRunning && z != 0)
            StartCoroutine(Walking());

        if (isGrounded && isRunning && x != 0 || isGrounded && isRunning && z != 0)
            StartCoroutine(Running());

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f && x != 0 || Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f && z != 0)
        {
            isRunning = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }

    IEnumerator Walking()
    {
        if (Random.value <= 0.1f && !isMakingSteps)
        {
            isMakingSteps = true;
            Step1.Play();
            yield return new WaitForSeconds(0.8f);
            isMakingSteps = false;
        }
        else
        {
            if (Random.value <= 0.2f && !isMakingSteps)
            {
                isMakingSteps = true;
                Step2.Play();
                yield return new WaitForSeconds(0.8f);
                isMakingSteps = false;
            }
            else
            {
                if (Random.value <= 0.3f && !isMakingSteps)
                {
                    isMakingSteps = true;
                    Step3.Play();
                    yield return new WaitForSeconds(0.8f);
                    isMakingSteps = false;
                }
                else
                {
                    if (Random.value <= 0.4f && !isMakingSteps)
                    {
                        isMakingSteps = true;
                        Step4.Play();
                        yield return new WaitForSeconds(0.8f);
                        isMakingSteps = false;
                    }
                    else
                    {
                        if (Random.value <= 0.4f && !isMakingSteps)
                        {
                            isMakingSteps = true;
                            Step5.Play();
                            yield return new WaitForSeconds(0.8f);
                            isMakingSteps = false;
                        }
                        else
                        {
                            if (Random.value <= 0.5f && !isMakingSteps)
                            {
                                isMakingSteps = true;
                                Step6.Play();
                                yield return new WaitForSeconds(0.8f);
                                isMakingSteps = false;
                            }
                            else
                            {
                                if (Random.value <= 0.6f && !isMakingSteps)
                                {
                                    isMakingSteps = true;
                                    Step7.Play();
                                    yield return new WaitForSeconds(0.8f);
                                    isMakingSteps = false;
                                }
                                else
                                {
                                    if (Random.value <= 1f && !isMakingSteps)
                                    {
                                        isMakingSteps = true;
                                        Step8.Play();
                                        yield return new WaitForSeconds(0.8f);
                                        isMakingSteps = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator Running()
    {
        if (Random.value <= 0.1f && !isMakingSteps)
        {
            isMakingSteps = true;
            Run1.Play();
            yield return new WaitForSeconds(0.6f);
            isMakingSteps = false;
        }
        else
        {
            if (Random.value <= 0.2f && !isMakingSteps)
            {
                isMakingSteps = true;
                Run2.Play();
                yield return new WaitForSeconds(0.6f);
                isMakingSteps = false;
            }
            else
            {
                if (Random.value <= 0.3f && !isMakingSteps)
                {
                    isMakingSteps = true;
                    Run3.Play();
                    yield return new WaitForSeconds(0.6f);
                    isMakingSteps = false;
                }
                else
                {
                    if (Random.value <= 0.4f && !isMakingSteps)
                    {
                        isMakingSteps = true;
                        Run4.Play();
                        yield return new WaitForSeconds(0.6f);
                        isMakingSteps = false;
                    }
                    else
                    {
                        if (Random.value <= 0.4f && !isMakingSteps)
                        {
                            isMakingSteps = true;
                            Run5.Play();
                            yield return new WaitForSeconds(0.6f);
                            isMakingSteps = false;
                        }
                        else
                        {
                            if (Random.value <= 0.5f && !isMakingSteps)
                            {
                                isMakingSteps = true;
                                Run6.Play();
                                yield return new WaitForSeconds(0.6f);
                                isMakingSteps = false;
                            }
                            else
                            {
                                if (Random.value <= 0.6f && !isMakingSteps)
                                {
                                    isMakingSteps = true;
                                    Run7.Play();
                                    yield return new WaitForSeconds(0.6f);
                                    isMakingSteps = false;
                                }
                                else
                                {
                                    if (Random.value <= 1f && !isMakingSteps)
                                    {
                                        isMakingSteps = true;
                                        Run8.Play();
                                        yield return new WaitForSeconds(0.6f);
                                        isMakingSteps = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
