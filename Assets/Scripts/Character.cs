using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum State
    {
        Idle,
        RunningFromEnemy,
        RunningToEnemy,
        
        BeginBat,
        BeginFist,
        BeginPistol,
        AttackAnimation,
        
        ActBat,
        ActFist,
        ActPistol,

        Hited,
        DeadAnimation,
        Dead
    }

    public enum Weapon
    {
        Pistol,
        Bat,
        Fist
    }

    public Weapon weapon;
    public float runSpeed;
    public float colliderRadius;
    public Character target;

    Animator animator;

    public string characterName
    { get; private set; }
    public bool isAlive
    { get; private set; }

    State state;
    Quaternion startRotation;
    Vector3 startPosition;


    public bool IsIdle()
    {
        return state == State.Idle;
    }
    public bool IsDead()
    {
        return state == State.Dead;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        characterName = this.name;
        isAlive = true;
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        
        startRotation = transform.rotation;
        startPosition = transform.position;

        state = State.Idle;
    }

 
    public void AttackEnemy()
    {
        Character targetCh = target;
        if (targetCh.isAlive && state == State.Idle && targetCh != this) 
        {
            switch (weapon)
            {
                case Weapon.Bat:
                    //Debug.Log($"{characterName}: Bat attack start");
                    state = State.RunningToEnemy;
                    break;

                case Weapon.Pistol:
                    //Debug.Log($"{characterName}: Pistol attack start");
                    state = State.BeginPistol;
                    break;

                case Weapon.Fist:
                    //Debug.Log($"{characterName}: Fist attack start");
                    state = State.RunningToEnemy;
                break;
            }
        }

    }

    public void SetState(State p_state)
    {
        state = p_state;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case State.Idle:
                //Debug.Log($"{characterName}: state idle");
                animator.SetFloat("speed", 0.0f);
                transform.rotation = startRotation;
                break;


            case State.RunningToEnemy:
        
                //Debug.Log($"{characterName}: state running to enemy");
                animator.SetFloat("speed", runSpeed);
                if (RunTowards(target.transform.position, colliderRadius) == true)
                {
                    switch (weapon) {
                        case Weapon.Bat:
                            state = State.BeginBat;
                            break;

                        case Weapon.Fist:
                            state = State.BeginFist;
                            break;

                        case Weapon.Pistol:
                        default:
                            Debug.Log($"ERROR: {characterName}: wrong weapon");
                            break;
                    }
                }
                break;

            case State.RunningFromEnemy:
                //Debug.Log($"{characterName}: state running from enemy");
                animator.SetFloat("speed", runSpeed);
                if (RunTowards(startPosition, 0.0f) == true)
                {
                    state = State.Idle;
                }
                break;


            case State.BeginBat:
                //Debug.Log($"{characterName}: state begin bat attack");
                animator.SetFloat("speed", 0.0f);
                animator.SetTrigger("bat");
                state = State.AttackAnimation;
                break;

            case State.BeginPistol:
                //Debug.Log($"{characterName}: state begin pistol attack");
                RotateTowards(target.transform.position);
                animator.SetFloat("speed", 0.0f);
                animator.SetTrigger("pistol");
                state = State.AttackAnimation;
                break;

            case State.BeginFist:
                //Debug.Log($"{characterName}: state begin fist attack");
                animator.SetFloat("speed", 0.0f);
                animator.SetTrigger("fist");
                state = State.AttackAnimation;
                break;


            case State.AttackAnimation:
                //Debug.Log($"{characterName}: state attack");
                animator.SetFloat("speed", 0.0f);
                break;


            case State.ActBat:
                PlayHitSound();
                CalculateDamage();
                target.SetState(Character.State.Hited);
                state = State.AttackAnimation;
                break;

            case State.ActPistol:
                PlayHitSound();
                PlayGunSmokeAnimation();
                CalculateDamage();
                target.SetState(Character.State.Hited);
                state = State.AttackAnimation;
                break;

            case State.ActFist:
                PlayHitSound();
                CalculateDamage();
                target.SetState(Character.State.Hited);
                state = State.AttackAnimation;
                break;


            case State.Hited:
                PlayHitedAnimation();

                CharacterParams charParams = GetComponent<CharacterParams>();
                
                if (charParams.Health >= 1.0f)
                {
                    //Debug.Log($"{characterName}: deal {damage} damage to {target.name}");
                    GetComponentInChildren<CharacterSounds>().PlayWoundSound();
                    state = State.Idle;
                    break;
                }

                isAlive = false;
                GetComponentInChildren<CharacterSounds>().PlayDeathSound();
                //Debug.Log($"{characterName}: state dead start");
                animator.SetFloat("speed", 0.0f);
                animator.SetTrigger("dead");

                state = State.DeadAnimation;
                break;


            case State.DeadAnimation:
                //Debug.Log($"{characterName}: state dead animation");
                animator.SetFloat("speed", 0.0f);
                break;

            case State.Dead:
                isAlive = false;
                //Debug.Log($"{characterName}: state dead");
                animator.enabled = false;
                break;

            default:
                Debug.Log($"ERROR: {characterName} wrong state");
                break;
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 distance = targetPosition - transform.position;
        transform.rotation = Quaternion.LookRotation(distance);
    }

    bool RunTowards(Vector3 targetPosition, float radius)
    {
        Vector3 distance = targetPosition - transform.position;
        Vector3 direction = distance.normalized;
        transform.rotation = Quaternion.LookRotation(direction);

        Vector3 vector = direction * runSpeed;

        if (vector.magnitude < distance.magnitude - radius)
        {
            transform.position += vector;
            return false;
        }

        transform.position = targetPosition - direction * radius;
        return true;
    }

    void PlayHitSound()
    {
        GetComponentInChildren<CharacterSounds>().PlayHitSound();
    }

    void CalculateDamage()
    {
        CharacterParams targetHealth = target.GetComponent<CharacterParams>();
        float damage = GetComponent<CharacterParams>().Damage;
        targetHealth.ApplyDamage(damage);
    }
    void PlayGunSmokeAnimation()
    {
        GunSmokeAnimation gunSmoke = GetComponentInChildren<GunSmokeAnimation>();
        gunSmoke.PlayEffect();
    }
    void PlayHitedAnimation()
    {
        HitEffectAnimation hitEffect = GetComponentInChildren<HitEffectAnimation>();
        hitEffect.PlayEffect();
    }
}
