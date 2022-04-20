using UnityEngine;
using Mirror;

public class PlayerStats : NetworkBehaviour
{
    [Header("Health & Stamina")]
    public int maxHealth;
    [SyncVar] public int currentHealth;
    [SerializeField] AudioClip deathSound;
    bool playerDead = false;

    [Space]
    public float maxStamina;
    public float currentStamina;
    public float staminaDrainSpeed;

    // Other
    public AccessTypes[] accessTypes;

    void Start()
    {
        SetupHealth(maxHealth);
        SetupStamina(maxStamina);
    }

    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        if (currentHealth <= 0 && !playerDead)
            KillPlayer();

        if (playerDead)
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(-90f, transform.localRotation.y, transform.localRotation.z),
                Time.deltaTime * 2f);
    }

    #region Health
    void SetupHealth(int newMaxHealth)
    {
        PlayerInterface.Singleton.lerpedHealth = newMaxHealth;
        PlayerInterface.Singleton.healthSlider.maxValue = newMaxHealth;

        CmdSetHealth(newMaxHealth);
    }

    [Command]
    public void CmdSetHealth(int newHealth) => currentHealth = newHealth;

    public void DamageHealth(int damage) => CmdSetHealth(currentHealth - damage);

    public void KillPlayer()
    {
        playerDead = true;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;

        AudioSource source = GetComponent<AudioSource>();
        source.clip = deathSound;
        source.Play();
    }
    #endregion

    #region Stamina
    void SetupStamina(float newMaxStamina)
    {
        PlayerInterface.Singleton.lerpedStamina = newMaxStamina;
        PlayerInterface.Singleton.staminaSlider.maxValue = newMaxStamina;

        SetStamina(newMaxStamina);
    }

    public void SetStamina(float newStamina) => currentStamina = newStamina;
    #endregion
}
