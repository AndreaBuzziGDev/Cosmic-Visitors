using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipPlayer : Spaceship
{
    //DATA

    //POSITION ETC
    public Vector3 InitialPosition = new Vector3(-10, 0, 0);
    [SerializeField] private float MoveSpeed = 5;
    Rigidbody2D rb2D;


    //INPUT - EVENT-DRIVEN IMPLEMENTATION
    private PlayerInput Input = null;
    private float MovementInputFactor = 0.0f;

    //AUDIO
    public AudioClip CratePickupAudio;


    //SPACESHIP EQUIPMENT
    [SerializeField] SpaceshipEquipment SmallCannonTop;
    [SerializeField] SpaceshipEquipment SmallCannonBottom;
    [SerializeField] SpaceshipEquipment BigCannon;

    [SerializeField] SpaceshipEquipment Barrier;

    [SerializeField] SpaceshipEquipment ThrusterTop;
    [SerializeField] SpaceshipEquipment ThrusterBottom;

    //TODO: SHIELD WILL BE ITS OWN TYPE OF THING
    [SerializeField] Shield PlayerShield;






    //METHODS

    //TECHNICAL
    protected override void Awake()
    {
        base.Awake();
        Input = new PlayerInput();
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        transform.position = InitialPosition;
    }

    protected override void Update()
    {
        base.Update();
        if (!GameStateController.Instance.IsPaused)
        {
            Move(new Vector2(0, MovementInputFactor));
        }
    }




    //INPUT - EVENT-DRIVEN IMPLEMENTATION
    //TODO: IMPLEMENT EVENT DRIVEN CODE LOGIC IN A DEDICATED INPUT HANDLER?
    private void OnEnable()
    {
        //ENABLE INPUT WHEN OBJECT ENABLED
        Input.Enable();

        //ACTION SUBSCRIPTIONS
        //MOVEMENT
        Input.Player.Movement.performed += OnMovementPerformed;
        Input.Player.Movement.canceled += OnMovementCanceled;

        //SHOOT
        ///SMALL CANNONS
        Input.Player.ShootMainCannon.performed += OnSmallCannonsPerformed;

        ///BIG CANNON
        Input.Player.ShootAdditionalCannon.performed += OnSecondaryCannonPerformed;

        ///SHIELD


        ///BARRIER


        ///THRUSTER





        //ESCAPE
        Input.Player.Escape.performed += OnEscapePerformed;
    }

    private void OnDisable()
    {
        //DISABLE INPUT WHEN OBJECT DISABLED
        Input.Disable();

        //MOVEMENT
        Input.Player.Movement.performed -= OnMovementPerformed;
        Input.Player.Movement.canceled -= OnMovementCanceled;

        //SHOOT
        ///SMALL CANNONS
        Input.Player.ShootMainCannon.performed -= OnSmallCannonsPerformed;

        ///BIG CANNON
        Input.Player.ShootAdditionalCannon.performed -= OnSecondaryCannonPerformed;

        ///SHIELD


        ///BARRIER


        ///THRUSTER





        //ESCAPE
        Input.Player.Escape.performed -= OnEscapePerformed;

    }

    //MOVEMENT
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        MovementInputFactor = value.ReadValue<float>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        MovementInputFactor = value.ReadValue<float>();
    }

    //SHOOT
    //MAIN CANNON
    private void OnSmallCannonsPerformed(InputAction.CallbackContext value)
    {
        //TODO: VALUES MIGHT HELP IN DETERMINING FEASIBILITY OF FULL-AUTO MANAGEMENT
        Debug.Log("OnSmallCannonsPerformed - value: " + value);
        if (GameStateController.Instance.IsStrictlyPlaying)
        {
            SmallCannonTop.Use();
            SmallCannonBottom.Use();
        }
    }

    //SECONDARY CANNON
    private void OnSecondaryCannonPerformed(InputAction.CallbackContext value)
    {
        //TODO: VALUES MIGHT HELP IN DETERMINING FEASIBILITY OF FULL-AUTO MANAGEMENT
        Debug.Log("OnSmallCannonsPerformed - value: " + value);
        if (GameStateController.Instance.IsStrictlyPlaying)
        {
            BigCannon.Use();
        }
    }

    //SHIELD, BARRIER, EVASION 
    //TODO: IMPLEMENT



    //ESCAPE
    private void OnEscapePerformed(InputAction.CallbackContext value)
    {
        UIController.Instance.NavigateBack();
    }






    //FUNCTIONALITIES
    public void Move(Vector2 direction)
    {
        rb2D.velocity = (direction) * MoveSpeed;
        //rb2D.AddForce(direction * MoveSpeed);
    }



    //RESET - USEFUL IN EDITOR
    public void Reset() => transform.position = InitialPosition;


    //OVERRIDES
    public override void ReceiveDamage(int damage)
    {
        base.ReceiveDamage(PlayerShield.TakeDamage(damage));
    }

    public override void HandleDamageReceived()
    {
        //TODO: MAKE SPACESHIP SPRITE FLICKER


        //TODO: GIVE INVINCIBILITY FOR A SMALL FRACTION OF TIME

        //UPDATE GUI HEALTH BAR
        UpdateHealthBar();

        //BASE BEHAVIOUR
        base.HandleDamageReceived();
    }

    public override void HandleZeroHP()
    {
        //UPDATE GUI HEALTH BAR
        UpdateHealthBar();

        //BASE BEHAVIOUR
        base.HandleZeroHP();

        //HANDLE LIVES
        GameController.Instance.LifeLoss();
    }





    //UTILITIES
    public void ReloadWeaponSystem(Crate crate)
    {
        //PLAY AUDIO
        AudioController.Instance.PlayClip(CratePickupAudio);

        //
        switch (crate.CrateContentType)
        {
            case Crate.eCrateContentType.SmallCannonEquip:
                //WON'T BE ACTUALLY USED
                SmallCannonTop.Reload(crate.ResourceAmount);
                SmallCannonBottom.Reload(crate.ResourceAmount);
                break;

            case Crate.eCrateContentType.BigCannonEquip:
                BigCannon.Reload(crate.ResourceAmount);
                break;

            case Crate.eCrateContentType.ShieldCharge:
                //TODO: IMPLEMENT
                //THIS WILL EFFECTIVELY RECHARGE THE SHIELD IMMEDIATELY BY RESOURCEAMOUNT

                break;

            case Crate.eCrateContentType.BarrierEquip:
                //TODO: IMPLEMENT

                break;

            case Crate.eCrateContentType.ThrusterEquip:
                //WILL NOT IMPLEMENT

                break;

            case Crate.eCrateContentType.Health:
                currentHealthPoints += crate.ResourceAmount;
                if (currentHealthPoints > maxHealthPoints) currentHealthPoints = maxHealthPoints;
                UpdateHealthBar();
                break;

        }
    }


    public void UpdateHealthBar()
    {
        UIController.Instance.HealthBar.UpdateHealthBar(this);
    }








}
